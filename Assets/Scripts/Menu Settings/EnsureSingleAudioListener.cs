using UnityEngine;

public class EnsureSingleAudioListener : MonoBehaviour
{
    private void Awake()
    {
        // Find all audio listeners in the scene
        AudioListener[] audioListeners = FindObjectsOfType<AudioListener>();

        // If there's more than one audio listener, remove the extras 
        if (audioListeners.Length > 1)
        {
            for (int i = 1; i < audioListeners.Length; i++)
            {
                Debug.LogWarning("Additional audio listener found on GameObject: " + audioListeners[i].gameObject.name);
                Destroy(audioListeners[i].gameObject);
            }
        }
    }
}
