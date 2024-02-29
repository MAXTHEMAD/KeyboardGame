using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelConvo : MonoBehaviour
{
    public GameObject conversationPanel;
    public TextMeshProUGUI textDisplay;
    public float displayDuration = 3.0f;

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
            StartConversation();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AnimatedObject"))
        {
            EndConversation();
        }
    }

    private void StartConversation()
    {
        if (conversationPanel != null)
        {
            conversationPanel.SetActive(true);
            textDisplay.text = "Argh! You'll never defeat us!";
            Invoke("EndConversation", displayDuration);
        }
    }

    private void EndConversation()
    {
        if (conversationPanel != null)
        {
            conversationPanel.SetActive(false);
        }
    }
}
