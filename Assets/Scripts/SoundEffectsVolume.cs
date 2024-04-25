using UnityEngine;
using UnityEngine.UI;

public class SoundEffectsVolume : MonoBehaviour
{
    public Slider slider; // Slider to control sound effects volume

    private SoundEffectsManager soundEffectsManager;

    private void Start()
    {
        soundEffectsManager = FindObjectOfType<SoundEffectsManager>();

        // Assign the ApplySoundEffectsVolume method to the slider's onValueChanged event
        slider.onValueChanged.AddListener(ApplySoundEffectsVolume);
    }

    public void ApplySoundEffectsVolume(float value)
    {
        // Pass the slider value to the sound effects manager to adjust volume
        soundEffectsManager.SetSoundEffectsVolume(value);
    }
}
