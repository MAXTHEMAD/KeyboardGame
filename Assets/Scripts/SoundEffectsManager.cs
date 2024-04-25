using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    private AudioSource[] soundEffectAudioSources;

    private void Awake()
    {
        // Find all audio sources tagged as "SoundEffect"
        GameObject[] soundEffectGameObjects = GameObject.FindGameObjectsWithTag("SoundEffect");
        soundEffectAudioSources = new AudioSource[soundEffectGameObjects.Length];

        for (int i = 0; i < soundEffectGameObjects.Length; i++)
        {
            soundEffectAudioSources[i] = soundEffectGameObjects[i].GetComponent<AudioSource>();
        }
    }

    public void SetSoundEffectsVolume(float volume)
    {
        foreach (var audioSource in soundEffectAudioSources)
        {
            audioSource.volume = volume;
        }
    }
}
