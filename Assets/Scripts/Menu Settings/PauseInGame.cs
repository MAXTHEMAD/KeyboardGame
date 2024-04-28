using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseInGame : MonoBehaviour
{
    public GameObject optionsMenuCanvas; // Reference to your options menu canvas
    public AudioSource[] musicAudioSources; // Reference to the audio sources playing music
    private bool isPaused = false;

    void Update()
    {
        // Check if the "Pause" input key is pressed
        if (Input.GetButtonDown("Pause"))
        {
            ToggleOptionsMenu();
        }
    }

    void ToggleOptionsMenu()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f; // Pause or resume the game

        // Pause or unpause music
        foreach (AudioSource audioSource in musicAudioSources)
        {
            if (isPaused)
            {
                audioSource.Pause();
            }
            else
            {
                audioSource.UnPause();
            }
        }

        // Toggle the visibility of the options menu canvas
        optionsMenuCanvas.SetActive(isPaused);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reset pause state when a new scene is loaded
        isPaused = false;
        Time.timeScale = 1f; // Ensure time scale is set to normal
        optionsMenuCanvas.SetActive(false); // Hide options menu canvas
        // Ensure all music audio sources are unpaused
        foreach (AudioSource audioSource in musicAudioSources)
        {
            audioSource.UnPause();
        }
    }
}
