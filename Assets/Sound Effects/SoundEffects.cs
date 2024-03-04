using UnityEngine;
using System.Collections;

public class SoundEffects : MonoBehaviour
{
    public AudioClip soundToPlay; // The sound to play when the object enters the collider
    private AudioSource audioSource; // The audio source attached to the game object

    private string tagToDetect = "AnimatedObject"; // The tag of the object you want to detect

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToDetect))
        {
            // Check if the sound to play is set
            if (soundToPlay != null && audioSource != null)
            {
                audioSource.PlayOneShot(soundToPlay);
            }
        }
    }
}
