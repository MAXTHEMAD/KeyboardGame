using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool audioIn = false;
    float dynamics;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KeyPressed(float Strength) {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - Strength, transform.localScale.z);
        dynamics = Strength; Debug.Log("keyDown");
        if (audioIn)
        {
            GetComponent<Oscillator>().Go();
        }
        
    }
    public void KeyReleased() {
        transform.localScale = new Vector3(transform.localScale.x, (int)transform.localScale.y + 1, transform.localScale.z);
        dynamics = 0;  Debug.Log("keyUp");
        if (audioIn)
        {
            GetComponent<Oscillator>().Stop();
        }
    }

    public bool KeyDown()
    {
        return dynamics > 0;
    }
}
