using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyBoard : MonoBehaviour
{
    public GameObject keyCubePrefab;
    public Keys keys;

    const byte panelDelay = 8;
    bool playing;
    float timeing;
    int noteSpawnIndex;

    List<note> notesOnboard = new List<note>();
    struct note
    {
        public float start;
        public float end;
        public float key;
        public float dynamics;
        public GameObject keyCube;
        public note(float iStart, float iEnd, float iKey, float iDynamics = 0)
        {
            start = iStart;
            end = iEnd;
            key = iKey;
            dynamics = iDynamics;
            keyCube = null;
        }
    }                  

    note[] songOne = { new note(1, 4, 0, 0.75f), new note(2, 4, 4, 0.75f), new note(3, 4, 5, 0.75f), new note(6, 10, 2, 0.75f), new note(11, 12, 0, 0.75f), new note(11, 12, 5, 0.75f)};


    note[] currentSong;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        StartSong(songOne);
    }

    // Update is called once per frame
    private void Update()
    {
        if (playing)
        {
            timeing += Time.deltaTime;
            if (noteSpawnIndex < currentSong.Length)
            {
                if (timeing >= currentSong[noteSpawnIndex].start - panelDelay)
                {
                    KeyCube(ref currentSong[noteSpawnIndex]);
                    notesOnboard.Add(currentSong[noteSpawnIndex]);
                    noteSpawnIndex++;
                }
            }
            for (int i = 0; i < notesOnboard.Count; i++)
            {
                if (timeing >= notesOnboard[i].end)
                {
                    Destroy(notesOnboard[i].keyCube);
                    notesOnboard.Remove(notesOnboard[i]);
                    i--;
                    continue;
                }
                if (timeing >= notesOnboard[i].start)
                {
                    if (keys.keyStrengths[(int)notesOnboard[i].key] > 0)
                    {
                        Debug.Log("good");

                    }
                    else
                    {
                        Debug.Log("Bad");
                    }
                }
            }
            if (timeing >= currentSong.Last().end) playing = false;
        }
    }

    void StartSong(note[] song) {
        currentSong = song;
        noteSpawnIndex = 0;
        timeing = -panelDelay;
        playing = true;
    }


    void KeyCube(ref note note)
    {
        //Instantiate(keyCubePrefab,Vector3.forward * note.key,Quaternion.identity,transform.Find("Plane"),instantiateInWorldSpace:false);
        GameObject prefab = Instantiate(keyCubePrefab, transform.Find("Plane"));
        prefab.transform.localPosition = Vector3.right * note.key;
        prefab.transform.localScale = new Vector3(1,1,(note.end - note.start));
        note.keyCube = prefab;
    }
}
