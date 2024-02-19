using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameispaused = false;

    public GameObject pausemenuui;
    
    void Update()
    { if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameispaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
        
    }

    void Resume()
    {
        pausemenuui.SetActive(false);
        Time.timeScale = 1f;
        gameispaused = false;
    }
    void Pause()
    {
        pausemenuui.SetActive(true);
        Time.timeScale = 0f;
        gameispaused = true;
    }
}
