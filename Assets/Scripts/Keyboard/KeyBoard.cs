using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class KeyBoard : MonoBehaviour
{
    public GameObject keyCubePrefab;
    Keys keys;
    [SerializeField] FeedBackText feedBackText;
    [SerializeField] float timingWindow = 0.5f;
    [SerializeField] float panelDelay = 16;
    [SerializeField] int score;
    public UnityEvent OnSongSuccess;
    public UnityEvent OnSongFailed;

    Transform plane;
    HUD hud;

    private float timeing;
    private int noteSpawnIndex;
    private float health = 100;
    private const int maxScore = 128;
    
    List<Song.note> notesOnboard = new List<Song.note>();
                      
    Song.note[] currentSong;
    string songName;

    private void Awake()
    {
        hud = GameObject.Find("Canvas").GetComponent<HUD>();
        keys = GetComponentInChildren<Keys>();
        plane = transform.Find("Plane");
        //panelDelay *= transform.lossyScale.x;
    }

    private void Update()
    {
        Debug.DrawLine(plane.position - (plane.forward * panelDelay), (plane.position - (plane.forward * panelDelay)) + plane.right * panelDelay*2.4f,Color.red);
    }

    IEnumerator SongPlaying()
    {
        while (timeing < currentSong.Last().end )
        {
            timeing += Time.deltaTime;
            if (noteSpawnIndex < currentSong.Length)
            {
                if (timeing >= currentSong[noteSpawnIndex].start - panelDelay)
                {
                    KeyCube(ref currentSong[noteSpawnIndex]);
                    
                    noteSpawnIndex++;
                }
            }
            for (int i = 0; i < notesOnboard.Count; i++)
            {
                try
                {
                    if (timeing > notesOnboard[i].start + timingWindow && !keys.keysObj[notesOnboard[i].key].KeyDown())
                    {
                        MissedNote(notesOnboard[i]);
                    }
                }catch (Exception e)
                {
                    Debug.LogWarning(e.ToString());
                    Debug.LogWarning(":((((((  failed at index: " + i);
                }
            }
            if (health < 100)
            {
                health = Time.deltaTime * 4 + health > 100 ? 100 : Time.deltaTime * 4 + health;
                hud.SetHealth(health);
            }
            if (health <= 0)
            {
                SongFailed();
            }                         
            yield return null;
        }
        Debug.Log(noteSpawnIndex);
        SongSuccesded();
    }
    IEnumerator AudioDelay()
    {
        yield return new WaitForSeconds(panelDelay);
        GetComponent<AudioSource>().Play();
    }

    private void SongSuccesded()
    {
        Scores.transferScore(score,songName);
        OnSongSuccess.Invoke();
    }
    private void SongFailed()
    {
        StopAllCoroutines();
        foreach (Song.note note in notesOnboard)
        {
            Destroy(note.keyCube);
            
        }
        notesOnboard.Clear();
        GetComponent<AudioSource>().Stop();
        Debug.Log("Failed Song");
        OnSongFailed.Invoke();
    }

    public void KeyState(int key, bool active)
    {
        if (!active)
        {
            int[] sharp = { 1, 3, 6, 8, 10, 13, 15, 18, 20, 22 };//all the black keys
            if (Array.IndexOf(sharp, key) == -1)
            {
                keys.keysObj[key].transform.GetComponent<MeshRenderer>().material = keys.keysObj[key].strMaterial;
            }
            else
            {
                keys.keysObj[key].transform.GetComponent<MeshRenderer>().material = keys.keysObj[key].strMaterial;
            }
        }
        Song.note noteEffected = notesOnboard.FirstOrDefault(x => x.key == key);
        if (noteEffected.end == 0)//(object.Equals(noteEffected, null))
        {
            if(active)
                keys.keysObj[key].transform.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Red");
            return;
        }
        //Debug.Log(noteEffected.start + " hehe " + noteEffected.end);
        float timeingDiffrence = active ? Mathf.Abs(noteEffected.start - timeing) : Mathf.Abs(noteEffected.end - timeing);
        if (timeingDiffrence < timingWindow)
        {
            int scoreDiff = (int)((((timeingDiffrence / timingWindow) - 1) * -1) * maxScore);//128 is perfect
            score += scoreDiff;
            hud.SetScore(score);
            Debug.Log(scoreDiff);
            //Debug.Log(scoreDiff);
            int scoreBand = 0;
            if (scoreDiff > 112)     //getting over 112 means you were within an eith of the timing window
            {
                scoreBand = 1;
            }
            else if (scoreDiff > 96) //getting over 96 means you were within an quarter of the timing window
            {
                scoreBand = 2;
            }
            else if (scoreDiff > 64) //getting over 64 means you were within an half of the timing window
            {
                scoreBand = 3;
            }
            else
            {
                scoreBand = 0;
            }
            feedBackText.feedback(scoreBand);
            if (active)
            {
                try
                {
                    noteEffected.keyCube.transform.GetChild(0).GetComponent<MeshRenderer>().material = (Material)Resources.Load("scoreCol" + scoreBand);
                    keys.keysObj[key].transform.GetComponent<MeshRenderer>().material = (Material)Resources.Load("scoreCol" + scoreBand);
                }
                catch (Exception e)
                {
                    Debug.LogWarning(e);
                }

            }
            if (!active)
            {
                DestroyNote(noteEffected);
            }
        }
        else
        {
            MissedNote(noteEffected);
        }
        
    }
    public void StartSong(string songName)
    {
        StopAllCoroutines();
        currentSong = Song.LoadSong(songName);
        this.songName = songName;
        noteSpawnIndex = 0;
        timeing = -panelDelay;
        hud.Setup(currentSong.Length * 256);
        notesOnboard.Clear();
        StartCoroutine(AudioDelay());
        StartCoroutine(SongPlaying());
    }
            
    
    void MissedNote(Song.note note)
    {
        DestroyNote(note);
        health -= 22;
        hud.SetHealth(health);
    }
    void DestroyNote(Song.note note)
    {
        Destroy(note.keyCube);
        notesOnboard.Remove(note);
    }
    /// <summary>
    /// Spawns in a keyindicator
    /// </summary>
    /// <param name="note"></param>
    void KeyCube(ref Song.note note)
    {
        
        GameObject prefab = Instantiate(keyCubePrefab, plane);
        int[] nonSharp = { 0, 2, 4, 5, 7, 9, 11, 12, 14,16,17,19,21,23,24 };//all the white keys
        int[] sharp = { 1, 3, 6, 8, 10, 13, 15, 18, 20, 22 };//all the black keys
        if (Array.IndexOf(sharp, note.key) != -1)
        {
            prefab.transform.localPosition = (Vector3.right * Array.IndexOf(nonSharp, note.key - 1)) + (Vector3.right * 0.75f);
            prefab.transform.GetChild(0).localScale = new Vector3(0.5f, 1, (note.end - note.start));
            prefab.transform.GetChild(0).GetComponent<MeshRenderer>().material = (Material)Resources.Load("BlackCube");
        }
        else if (Array.IndexOf(nonSharp, note.key) != -1)
        {
            prefab.transform.localPosition = Vector3.right * Array.IndexOf(nonSharp, note.key);
            prefab.transform.GetChild(0).localScale = new Vector3(1, 1, (note.end - note.start));
        }
        else
        {
            Destroy(prefab);
            return;
        }
        prefab.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = (new string[25] { "C","C#","D","D#","E","F","F#","G","G#","A","A#","B"
                                                                                                        , "C","C#","D","D#","E","F","F#","G","G#","A","A#","B","C"})[note.key];
        prefab.layer = 7;
        note.keyCube = prefab;
        notesOnboard.Add(note);
    }
}
