using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Rendering;

public class Oscillator : MonoBehaviour
{
    public double frequency = 440;
    public double gain = 0;
    
    public OscillatorManager manager;
    

    private double increment;
    private double phase;
    private double sampling_frequency = 48000;
    public double volume = 0.1;

    public void Awake()
    {
        frequency = 440 * Mathf.Pow(2, ((float)(48 + transform.GetSiblingIndex()) - 69f) / 12f);
    }
    public void Go(float dynamics)
    {
        gain = volume * dynamics;
    }

    public void Stop()
    {
        gain = 0;
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        // update increment in case frequency has changed
        increment = frequency * 2 * Mathf.PI / sampling_frequency;
        for (int i = 0; i < data.Length; i = i + channels)
        {
            phase += increment;
            data[i] = (float)(gain * Mathf.Sin((float)phase)) * manager.sineWeight;
            if(gain * Mathf.Sin((float)phase) >= 0 * gain)
            {
                data[i] += (float)gain * 0.6f * manager.squareWeight;
            }
            else
            {
                data[i] += (-(float)gain) * 0.6f * manager.squareWeight;
                        
            }
            data[i] += (float)(gain * (double)Mathf.PingPong((float)phase, 1.0f)) * manager.triangleWeight;
            data[i] /= manager.sineWeight + manager.squareWeight + manager.triangleWeight;
            if (channels == 2) 
                data[i+1] = data[i];
            if (phase > 2 * Mathf.PI)
                phase -= Mathf.PI * 2;
        }
    }
} 

