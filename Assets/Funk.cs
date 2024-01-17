using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    struct note
    {
        public float start;
        public float end;
        public int key;
        public float dynamics;
        public GameObject keyCube;
        public note(float iStart, float iEnd, int iKey, float iDynamics = 0)
        {
            start = iStart;
            end = iEnd;
            key = iKey;
            dynamics = iDynamics;
            keyCube = null;
        }
    }

    note[] songOne = { new note(10.676f, 11.944f, 4), new note(12f, 13.352f, 0), new note(13.328f, 14.704f, 2), new note(14.676f, 15.891f, -1), new note(16.008f, 17.284f, 3), new note(17.333f, 18.666f, 0), new note(18.677f, 20.006f, 2), new note(20.016f, 20.892f, -1),
                       new note(21.350f, 22.602f, 4), new note(22.667f, 24.020f, 0), new note(24f, 25.364f, 2), new note(25.339f, 26.557f, -1), new note(26.675f, 27.945f, 3), new note(27.997f, 29.341f, 0), new note(29.338f, 30.675f, 2), new note(30.695f, 31.566f, -1),
                       new note(31.991f, 32.320f, 12), new note(32.315f, 32.644f, 15), new note(32.640f, 32.913f, 12), new note(32.890f, 33.136f, 10), new note(33.043f, 33.437f, 7), new note(33.367f, 33.557f, 10), new note(33.682f, 33.900f, 5), new note(34.025f, 34.132f, 7),
                       new note(34.948f, 35.161f, 7), new note(35.258f, 35.411f, 7), new note(35.467f, 35.587f, 10), new note(35.634f, 35.814f, 12), new note(36.009f, 36.185f, 12), new note(36.343f, 36.519f, 12), new note(36.667f, 36.848f, 12),
                       new note(38.062f, 38.487f, 12), new note(38.567f, 39.035f, 10), new note(39.021f, 39.522f, 7), new note(40.713f, 41.255f, 12), new note(41.167f, 41.607f, 10), new note(41.667f, 42.353f, 7),
                       new note(42.655f, 42.984f, 7), new note(35.258f, 35.411f, 7), new note(35.467f, 35.587f, 10), new note(35.634f, 35.814f, 12), new note(36.009f, 36.185f, 12), new note(36.343f, 36.519f, 12), new note(36.667f, 36.848f, 12),};
}
