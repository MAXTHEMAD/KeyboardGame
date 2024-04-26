using UnityEngine;
using TMPro;

public class Graphics : MonoBehaviour
{
    public TMP_Text qualityText; 
    private string[] qualityLevels = { "Very Low", "Low", "Medium", "High", "Very High", "Ultra" };
    private int qualityLevelIndex = 0; // track current quality level

    
    public GameObject[] waterElements;
    public Renderer[] shaders;

    private void Start()
    {
        UpdateQualityText();
    }

    private void UpdateQualityText()
    {
        qualityText.text = "Quality: " + qualityLevels[qualityLevelIndex];
    }

    public void ToggleQuality()
    {
        qualityLevelIndex = (qualityLevelIndex + 1) % qualityLevels.Length; // Cycle through quality levels
        ApplySettings();
        UpdateQualityText();
    }

    public void ApplySettings()
    {
        if (qualityLevels[qualityLevelIndex] == "Ultra")
        {
            // Apply ultra settings
            foreach (GameObject waterElement in waterElements)
            {
                waterElement.SetActive(true); // Activate all water elements
            }
            foreach (Renderer shader in shaders)
            {
                shader.enabled = true; // Enable all shaders
            }
        }
        else
        {
            QualitySettings.SetQualityLevel(qualityLevelIndex, true); // Set quality level
        }
    }
}
