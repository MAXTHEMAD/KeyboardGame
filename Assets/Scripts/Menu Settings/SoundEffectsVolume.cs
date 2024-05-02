using UnityEngine;
using UnityEngine.UI;

public class SoundEffectsVolume : MonoBehaviour
{
    public Slider slider;

    private SoundEffectsManager soundEffectsManager;
    private string soundEffectsVolumePlayerPrefsKey = "SoundEffectsVolume";

    private void Start()
    {
        soundEffectsManager = FindObjectOfType<SoundEffectsManager>();

        // Load sound effects volume preference when the scene starts
        if (PlayerPrefs.HasKey(soundEffectsVolumePlayerPrefsKey))
        {
            float savedVolume = PlayerPrefs.GetFloat(soundEffectsVolumePlayerPrefsKey);
            slider.value = savedVolume;
            ApplySoundEffectsVolume(savedVolume); // Apply loaded volume
        }
        else
        {
            // If no preference saved, use default value
            ApplySoundEffectsVolume(slider.value);
        }

        slider.onValueChanged.AddListener(ApplySoundEffectsVolume);
    }

    public void ApplySoundEffectsVolume(float value)
    {
        // Set sound effects volume
        soundEffectsManager.SetSoundEffectsVolume(value);

        // Save sound effects volume preference when volume changes
        PlayerPrefs.SetFloat(soundEffectsVolumePlayerPrefsKey, value);
        PlayerPrefs.Save();
    }
}
