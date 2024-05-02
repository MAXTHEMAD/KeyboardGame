using UnityEngine;
using TMPro;

public class DeathMenu : MonoBehaviour
{
    private FontManager fontManager;
    private TextMeshProUGUI[] textObjects;

    private void Start()
    {
        fontManager = FindObjectOfType<FontManager>();
        if (fontManager == null)
        {
            Debug.LogError("FontManager not found in the scene!");
            return;
        }

        textObjects = GetComponentsInChildren<TextMeshProUGUI>();
        ApplyFont();
    }

    private void ApplyFont()
    {
        if (fontManager != null)
        {
            fontManager.ApplyFontToTextObjects(textObjects);
        }
        else
        {
            Debug.LogWarning("FontManager is null. Font application failed.");
        }
    }

   
}
