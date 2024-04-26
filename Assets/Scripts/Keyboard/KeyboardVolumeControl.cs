using UnityEngine;
using UnityEngine.UI;

public class KeyboardVolumeControl : MonoBehaviour
{
    public Slider volumeSlider; 
    public GameObject keyboardPrefab; 
    private AudioSource keyboardAudioSource; 

    private void Start()
    {
        // Find the AudioSource 
        keyboardAudioSource = keyboardPrefab.GetComponent<AudioSource>();

        // Set the slider's value to the initial volume of the keyboard
        volumeSlider.value = keyboardAudioSource.volume;

        // Add listener 
        volumeSlider.onValueChanged.AddListener(HandleVolumeChanged);
    }

    private void HandleVolumeChanged(float value)
    {
        // Update the volume 
        keyboardAudioSource.volume = value;
    }
}
