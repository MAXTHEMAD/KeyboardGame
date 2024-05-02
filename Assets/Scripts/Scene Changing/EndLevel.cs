using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel: MonoBehaviour
{
    public string sceneName;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("AnimatedObject"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}
