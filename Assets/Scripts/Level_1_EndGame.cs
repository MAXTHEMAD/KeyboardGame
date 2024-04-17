using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_1_EndGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("AnimatedObject"))
        {
            // Load the main menu scene
            SceneManager.LoadScene("Level_1_EndScreen");
        }
    }

}
