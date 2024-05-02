using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    private AudioSource[] audioSources;

    private string soundEffectsVolumePlayerPrefsKey = "SoundEffectsVolume";

    private void Start()
    {
        // Find all audio sources in the scene
        audioSources = FindObjectsOfType<AudioSource>();

        // Load sound effects volume preference when the scene starts
        if (PlayerPrefs.HasKey(soundEffectsVolumePlayerPrefsKey))
        {
            float savedVolume = PlayerPrefs.GetFloat(soundEffectsVolumePlayerPrefsKey);
            SetSoundEffectsVolume(savedVolume);
        }
    }

    public void SetSoundEffectsVolume(float volume)
    {
        // Set the volume of each audio source to the specified volume
        foreach (AudioSource source in audioSources)
        {
            source.volume = volume;
        }
    }
}
