using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public float dynamics;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void keyPressed(float Strength) {
        transform.localScale = new Vector3(transform.localScale.x, 1 - Strength, transform.localScale.x);
        dynamics = Strength;
    }
    public void keyReleased() {
        transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.x);
        dynamics = 0;
    }
}
