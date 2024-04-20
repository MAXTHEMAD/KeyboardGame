using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Key : MonoBehaviour
{
    public bool audioIn = false;
    float dynamics;
    bool sharp;
    [HideInInspector]
    public Material strMaterial;
    private void Awake()
    {
        sharp = transform.localRotation.x != 0;
        strMaterial = GetComponent<MeshRenderer>().material;
    }

    public void KeyPressed(float Strength) {
        //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - Strength, transform.localScale.z);
        transform.localRotation = Quaternion.Euler( new Vector3(sharp ? -(Strength * 4 - 1) : -(Strength * 4),0,0));
        dynamics = Strength; //Debug.Log("keyDown");
        if (audioIn)
        {
            GetComponent<Oscillator>().Go(Strength);
        } else
        {
            StopAllCoroutines();
            GetComponent<AudioSource>().volume = Strength * transform.parent.GetComponent<Keys>().volume;
            GetComponent<AudioSource>().Play();
        }
        
    }
    public void KeyReleased() {
        //transform.localScale = new Vector3(transform.localScale.x, (int)transform.localScale.y + 1, transform.localScale.z);
        transform.localRotation = Quaternion.Euler(new Vector3(sharp ? -1 : 0 , 0 , 0));
        //Debug.Log("keyUp");
        if (audioIn)
        {
            GetComponent<Oscillator>().Stop();
        }
        else
        {
            StartCoroutine(stopSound());
        }
        dynamics = 0;
    }

    public bool KeyDown()
    {
        return dynamics > 0;
    }

    IEnumerator stopSound(float duration = 0.7f)
    {
        duration = duration < dynamics ? duration : dynamics;
        //float time = Mathf.InverseLerp(0, duration, dynamics);
        float time = duration;
        //Debug.Log(time);
        //Debug.Log(dynamics);
        while (time > 0)
        {
            time -= Time.deltaTime;
            GetComponent<AudioSource>().volume = Mathf.Lerp(0f,duration,time) * transform.parent.GetComponent<Keys>().volume;
            yield return null;
        }
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().volume = 1;
    }
}
