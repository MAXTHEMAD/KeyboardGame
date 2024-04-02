using TMPro;
using UnityEngine;
using System;

public class Graphics : MonoBehaviour
{
    public TMP_Text qualityText;
    public TMP_FontAsset lowQualityFont;
    public TMP_FontAsset highQualityFont;

    private int qualityLevel = 0; // 0 is low, 1 is high
    private FontManager fontManager;

    private void Start()
    {
        fontManager = FindObjectOfType<FontManager>(); // Find the FontManager instance

        UpdateQualityText();
        UpdateFont();
    }

    private void UpdateQualityText()
    {
        qualityText.text = "Quality = " + (qualityLevel == 0 ? "Low" : "High");
    }

    private void UpdateFont()
    {
        if (fontManager != null)
        {
            fontManager.SetSelectedFont(qualityLevel == 0 ? lowQualityFont : highQualityFont);
        }
    }

    public void ToggleQuality()
    {
        qualityLevel = 1 - qualityLevel; // Toggles between 0 and 1
        UpdateQualityText();
        UpdateFont();
    }

    public void ApplySettings()
    {
        QualitySettings.SetQualityLevel(qualityLevel, true); // Apply graphics quality
        UpdateFont(); // Apply font
    }
}
