using UnityEngine;
using UnityEngine.UI;

public class FXVolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource[] fxSounds;

    private float defaultVolume = 1.0f;

    private void Start()
    {
        // Set the slider value to the default volume
        volumeSlider.value = defaultVolume;
        // Set up listener for volume changes
        volumeSlider.onValueChanged.AddListener(delegate { SetFXVolume(); });
        // Initialize FX sounds array
        fxSounds = GameObject.FindObjectsOfType<AudioSource>();
    }

    private void SetFXVolume()
    {
        // Iterate through all FX sounds and adjust their volume
        foreach (AudioSource fxSound in fxSounds)
        {
            if (fxSound.tag == "FX") // Assuming FX sounds are tagged appropriately
            {
                fxSound.volume = volumeSlider.value;
            }
        }
    }
}
