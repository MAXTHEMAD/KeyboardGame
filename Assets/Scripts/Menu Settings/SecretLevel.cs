using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Scores.scoreOnSongs["Lofi"] <= 10000 && Scores.scoreOnSongs["Funk"] <= 10000)
        {
            gameObject.SetActive(false);
        }
    }
}
