using UnityEngine;
using TMPro;

public class PanelConvo : MonoBehaviour
{
    public GameObject conversationPanel;
    public TextMeshProUGUI textDisplay;
    public TMP_FontAsset normalFont;
    public TMP_FontAsset easyReadFont;
    public float displayDuration = 3.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AnimatedObject"))
        {
            StartConversation();
        }
    }

    private void StartConversation()
    {
        if (conversationPanel != null && textDisplay != null)
        {
            conversationPanel.SetActive(true);

            // Copy text from TextMeshProUGUI component to textDisplay
            TextMeshProUGUI textMesh = conversationPanel.GetComponent<TextMeshProUGUI>();
            if (textMesh != null)
            {
                textDisplay.text = textMesh.text;
            }

            // Apply font based on the current setting
            FontManager fontManager = FindObjectOfType<FontManager>();
            if (fontManager != null)
            {
                textDisplay.font = fontManager.IsEasyReadMode ? easyReadFont : normalFont;
            }

            // End conversation after display duration
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
