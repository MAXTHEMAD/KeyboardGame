using UnityEngine;
using UnityEngine.UI;

public class KeyboardVolume : MonoBehaviour
{
    public Slider volumeSlider;
    public Keys keysScript;

    private string volumePlayerPrefsKey = "Volume";

    void Start()
    {
        // Load volume preference when the scene starts
        if (PlayerPrefs.HasKey(volumePlayerPrefsKey))
        {
            float savedVolume = PlayerPrefs.GetFloat(volumePlayerPrefsKey);
            volumeSlider.value = savedVolume;
            keysScript.volume = savedVolume; // Update volume in Keys script
        }
        else
        {
            // If no preference saved, use default value
            volumeSlider.value = keysScript.volume;
        }

        volumeSlider.onValueChanged.AddListener(HandleVolumeChanged);
    }

    void HandleVolumeChanged(float value)
    {
        // Update volume in Keys script
        keysScript.volume = value;

        // Save volume preference when volume changes
        PlayerPrefs.SetFloat(volumePlayerPrefsKey, value);
        PlayerPrefs.Save();
    }
}
