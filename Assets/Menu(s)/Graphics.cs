using TMPro;
using UnityEngine;

public class Graphics : MonoBehaviour
{
    public TMP_Text qualityText;
    private int qualityLevel = 0; // 0 is low, 1 is high

    private void Start()
    {
        UpdateQualityText();
    }

    private void UpdateQualityText()
    {
        qualityText.text = "Quality = " + (qualityLevel == 0 ? "Low" : "High");
    }

    public void ToggleQuality()
    {
        qualityLevel = 1 - qualityLevel; // Toggles between 0 and 1
        UpdateQualityText();
    }

    public void ApplySettings()
    {
        QualitySettings.SetQualityLevel(qualityLevel, true);
    }
}
