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

            // Get the FontManager instance
            FontManager fontManager = FindObjectOfType<FontManager>();

            // Apply the font to the textDisplay using FontManager
            if (fontManager != null && textDisplay != null)
            {
                textDisplay.font = fontManager.GetSelectedFont();
            }
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
