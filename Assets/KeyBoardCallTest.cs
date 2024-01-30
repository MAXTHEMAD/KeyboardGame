using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardCallTest : MonoBehaviour
{
    [SerializeField]
    KeyBoard keyBoard;
    // Start is called before the first frame update
    void Start()
    {
        keyBoard.StartSong("Funk");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
