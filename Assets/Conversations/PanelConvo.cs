using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelConvo : MonoBehaviour
{
    public GameObject conversationPanel;
    public TextMeshProUGUI textDisplay;
    public FontManager fontManager; // Reference to FontManager script

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

            // Apply the font to the textDisplay using FontManager
            if (fontManager != null && textDisplay != null)
            {
                // Debug log to track font assignment
                Debug.Log("Font before assignment: " + textDisplay.font.name);

                // Get the selected font from FontManager and apply it
                textDisplay.font = fontManager.selectedFont;

                // Debug log to verify font assignment
                Debug.Log("Font after assignment: " + textDisplay.font.name);
            }
            else
            {
                Debug.LogWarning("FontManager or textDisplay not found.");
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
