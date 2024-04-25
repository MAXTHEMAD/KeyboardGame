using UnityEngine;
using UnityEngine.UI;

public class KeyboardVolume : MonoBehaviour
{
    public Slider volumeSlider;
    public Keys keysScript;

    void Start()
    {
        // Set the initial value of the slider to match the initial volume
        volumeSlider.value = keysScript.volume;

        // Add listener to the slider's value change event
        volumeSlider.onValueChanged.AddListener(HandleVolumeChanged);
    }

    void HandleVolumeChanged(float value)
    {
        // Update the volume in the Keys script when the slider value changes
        keysScript.volume = value;
    }
}
