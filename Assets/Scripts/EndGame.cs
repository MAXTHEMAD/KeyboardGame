using UnityEngine;
using UnityEngine.SceneManagement;

public class PassThroughTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("AnimatedObject"))
        {
            // Load the main menu scene
            SceneManager.LoadScene("Menu");
        }
    }

}
