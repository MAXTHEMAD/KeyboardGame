using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool audioIn = false;
    float dynamics;
    bool sharp;
    private void Awake()
    {
        sharp = transform.localRotation.z != 0;
    }

    public void KeyPressed(float Strength) {
        //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - Strength, transform.localScale.z);
        transform.localRotation = Quaternion.Euler( new Vector3(0,0, sharp ? Strength * 3 - 1 : Strength * 4));
        dynamics = Strength; Debug.Log("keyDown");
        if (audioIn)
        {
            GetComponent<Oscillator>().Go(Strength);
        }
        
    }
    public void KeyReleased() {
        //transform.localScale = new Vector3(transform.localScale.x, (int)transform.localScale.y + 1, transform.localScale.z);
        transform.localRotation = Quaternion.Euler(new Vector3(0,0, sharp ? -1 : 0));
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
