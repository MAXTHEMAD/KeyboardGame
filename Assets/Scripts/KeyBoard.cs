using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class KeyBoard : MonoBehaviour
{
    public GameObject keyCubePrefab;
    public Keys keys;
    [SerializeField] float timingWindow = 0.5f;
    [SerializeField] int score;
    public UnityEvent OnSongSuccess;
    public UnityEvent OnSongFailed;

    UnityEngine.UI.Slider healthBar;

    const byte panelDelay = 8;
    float timeing;
    int noteSpawnIndex;
    float health = 100;
    
    List<Song.note> notesOnboard = new List<Song.note>();
                      
    Song.note[] currentSong;

    private void Awake()
    {
        healthBar = GameObject.Find("HealthSlider").GetComponent<UnityEngine.UI.Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartSong("Funk");
    }

    // Update is called once per frame
    private void Update()
    {
        
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

                if (timeing > notesOnboard[i].start + timingWindow && !keys.keysObj[notesOnboard[i].key].KeyDown())
                {
                    MissedNote(notesOnboard[i]);
                }
            }
            if (health < 100)
            {
                health = Time.deltaTime * 4 + health > 100 ? 100 : Time.deltaTime * 4 + health;
                healthBar.value = health * 0.01f;
            }
            else if (health < 0)
            {
                SongFailed();
            }
            yield return null;
        }
        OnSongSuccess.Invoke();
    }

    private void SongFailed()
    {
        StopAllCoroutines();
        foreach (Song.note note in notesOnboard)
        {
            DestroyNote(note);
        }

        Debug.Log("Failed Song");
        OnSongFailed.Invoke();
    }

    public void KeyState(int key, bool active)
    {
        Song.note noteEffected = notesOnboard.FirstOrDefault(x => x.key == key);
        if (object.Equals(noteEffected, null))
            return;
        float timeingDiffrence = active ? Mathf.Abs(noteEffected.start - timeing) : Mathf.Abs(noteEffected.end - timeing);
        if (timeingDiffrence < timingWindow)
        {
            score += (int)((((timeingDiffrence / timingWindow) - 1) * -1) * 128);//replace magic with score var
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
    public void StartSong(int songIndex) {
        StopAllCoroutines();
        currentSong = Song.LoadSong(songIndex);
        noteSpawnIndex = 0;
        timeing = -panelDelay;
        notesOnboard.Clear();
        StartCoroutine(SongPlaying());
    }
    public void StartSong(string songName)
    {
        StopAllCoroutines();
        currentSong = Song.LoadSong(songName);
        noteSpawnIndex = 0;
        timeing = -panelDelay;
        notesOnboard.Clear();
        StartCoroutine(SongPlaying());
    }
            
    
    void MissedNote(Song.note note)
    {
        DestroyNote(note);
        health -= 25;
        healthBar.value = health * 0.01f;
    }
    void DestroyNote(Song.note note)
    {
        Destroy(note.keyCube);
        notesOnboard.Remove(note);
    }
    void KeyCube(ref Song.note note)
    {
        //Instantiate(keyCubePrefab,Vector3.forward * note.key,Quaternion.identity,transform.Find("Plane"),instantiateInWorldSpace:false);
        GameObject prefab = Instantiate(keyCubePrefab, transform.Find("Plane"));
        int[] nonSharp = { 0, 2, 4, 5, 7, 9, 11, 12, 14,16,17,19,21,23,24 };//all the white keys
        int[] sharp = { 1, 3, 6, 8, 10, 13, 15, 18, 20, 22 };//all the black keys
        if (Array.IndexOf(sharp, note.key) != -1)
        {
            prefab.transform.localPosition = (Vector3.right * Array.IndexOf(nonSharp, note.key - 1)) + (Vector3.right * 0.75f);
            prefab.transform.localScale = new Vector3(0.5f, 1, (note.end - note.start));
        }
        else if (Array.IndexOf(nonSharp, note.key) != -1)
        {
            prefab.transform.localPosition = Vector3.right * Array.IndexOf(nonSharp, note.key);
            prefab.transform.localScale = new Vector3(1, 1, (note.end - note.start));
        }
        else
        {
            Destroy(prefab);
            return;
        }
        note.keyCube = prefab;
        notesOnboard.Add(note);
    }
}



//legasy 
//for (int i = 0; i < notesOnboard.Count; i++)
//            {
//                if (timeing >= notesOnboard[i].end)
//                {
//                    Destroy(notesOnboard[i].keyCube);
//                    notesOnboard.Remove(notesOnboard[i]);
//                    i--;
//                    continue;
//                }
//                if (timeing >= notesOnboard[i].start - timingWindow)
//                {
//                    if (keys.keysObj[(int)notesOnboard[i].key].keyDown())
//                    {
//                        Debug.Log("good");

//                    }
//                    else if (timeing >= notesOnboard[i].start + timingWindow)
//                    {
//                        Destroy(notesOnboard[i].keyCube); 
//                        notesOnboard.Remove(notesOnboard[i]);
//                        i--;
//                        Debug.Log("Bad");
//                    }
//                }
//            }