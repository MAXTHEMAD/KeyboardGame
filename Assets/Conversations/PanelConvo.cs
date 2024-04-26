using UnityEngine;
using TMPro;

public class PanelConvo : MonoBehaviour
{
    public GameObject conversationPanel;
    public TextMeshProUGUI textDisplay;
    public float displayDuration = 3.0f;

    private FontManager fontManager;

    private void Start()
    {
        fontManager = FindObjectOfType<FontManager>();
        if (fontManager == null)
        {
            Debug.LogError("FontManager not found in the scene!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AnimatedObject"))
        {
            StartConversation();
        }
    }

    private void StartConversation()
    {
        if (conversationPanel != null && textDisplay != null && fontManager != null)
        {
            conversationPanel.SetActive(true);

            // Apply font based on the current setting
            textDisplay.font = fontManager.selectedFont;

            // End conversation after display duration
            Invoke("EndConversation", displayDuration);
        }
        else
        {
           
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
