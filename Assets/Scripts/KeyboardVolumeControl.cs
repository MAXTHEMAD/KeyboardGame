using UnityEngine;
using UnityEngine.UI;

public class KeyboardVolumeControl : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the UI slider
    public GameObject keyboardPrefab; // Reference to the musical keyboard prefab
    private AudioSource keyboardAudioSource; // Reference to the AudioSource component of the keyboard prefab

    private void Start()
    {
        // Find the AudioSource component in the keyboard prefab
        keyboardAudioSource = keyboardPrefab.GetComponent<AudioSource>();

        // Set the slider's value to the initial volume of the keyboard
        volumeSlider.value = keyboardAudioSource.volume;

        // Add listener to the slider's value change event
        volumeSlider.onValueChanged.AddListener(HandleVolumeChanged);
    }

    private void HandleVolumeChanged(float value)
    {
        // Update the volume of the keyboard prefab's AudioSource
        keyboardAudioSource.volume = value;
    }
}
