using UnityEngine;
using TMPro;

public class FontSwitcher : MonoBehaviour
{
    public TMP_FontAsset normalFont;
    public TMP_FontAsset easyReadFont;

    private bool isEasyRead = false;

    public void ToggleFont()
    {
        isEasyRead = !isEasyRead;

        TextMeshProUGUI[] textObjects = FindObjectsOfType<TextMeshProUGUI>();

        foreach (TextMeshProUGUI textObject in textObjects)
        {
            if (textObject != null) // Check if the TextMeshProUGUI object is not null
            {
                if (isEasyRead)
                {
                    textObject.font = easyReadFont;
                }
                else
                {
                    textObject.font = normalFont;
                }
            }
            else
            {
                Debug.LogWarning("TextMeshProUGUI object is null.");
            }
        }
    }
}
