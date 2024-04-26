using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardCallTest : MonoBehaviour
{
    [SerializeField]
    KeyBoard keyBoard;
    public string song;
    // Start is called before the first frame update
    void Start()
    {
        keyBoard.StartSong(song);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextsong()
    {

    }
}
