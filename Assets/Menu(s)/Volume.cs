using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider slider; // Slider to control volume
    public AudioSource audioSource; // Audio source to adjust volume

    private string volumePlayerPrefsKey = "MasterVolume"; // PlayerPrefs key for saving volume

    private float initialVolume; // Store initial volume level

    private void Awake()
    {
        // Load volume preference when the script is awake
        if (PlayerPrefs.HasKey(volumePlayerPrefsKey))
        {
            float savedVolume = PlayerPrefs.GetFloat(volumePlayerPrefsKey);
            slider.value = savedVolume;
            HandleValueChanged(savedVolume); // Apply loaded volume
        }
        else
        {
            // If no preference saved, use initial volume
            HandleValueChanged(slider.value);
        }

        slider.onValueChanged.AddListener(HandleValueChanged);
        initialVolume = audioSource.volume; // Store initial volume level
    }

    private void HandleValueChanged(float value)
    {
        // Map the slider value
        float mappedValue = Mathf.Lerp(0f, 1f, value);

        // Set the volume of the audio source
        audioSource.volume = mappedValue;

        // Save volume preference when volume changes
        PlayerPrefs.SetFloat(volumePlayerPrefsKey, mappedValue);
        PlayerPrefs.Save();
    }
}
