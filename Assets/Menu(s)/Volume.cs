using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider slider; // Slider to control volume
    public AudioSource audioSource; // Audio source to adjust volume

    private float initialVolume; // Store the initial volume level

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleValueChanged);
        initialVolume = audioSource.volume; // Store the initial volume level when the script is awake
    }

    private void HandleValueChanged(float value)
    {
        // Map the slider value from 0-1 to 1-10
        float mappedValue = Mathf.Lerp(1f, 10f, value);

        // Set the volume of the audio source
        audioSource.volume = mappedValue / 10f;
    }

    public void ApplyVolume()
    {
        // Apply the volume level from the slider
        audioSource.volume = slider.value;
    }
}
