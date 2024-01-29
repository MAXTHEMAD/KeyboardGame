using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ConversationTrigger : MonoBehaviour
{
    
    public float displayDuration = 3.0f;
    public GameObject conversationPanel;
    public TextMeshProUGUI textDisplay;

    private void Start()
    {
        if (conversationPanel != null)
        {
            conversationPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AnimatedObject"))
        {
            Debug.Log("AnimatedObject entered the trigger zone.");
            StartConversation();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AnimatedObject"))
        {
            Debug.Log("AnimatedObject exited the trigger zone.");
            EndConversation();
        }
    }

    private void StartConversation()
    {
        if (conversationPanel != null)
        {
            Debug.Log("Starting conversation.");
           
            conversationPanel.SetActive(true);
            Invoke("EndConversation", displayDuration);
        }
    }

    private void EndConversation()
    {
        if (conversationPanel != null)
        {
            Debug.Log("Ending conversation.");
            conversationPanel.SetActive(false);
        }
    }
}
