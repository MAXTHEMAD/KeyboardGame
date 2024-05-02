using UnityEngine;
using UnityEngine.UI;

public class Brightness : MonoBehaviour
{
    public Slider brightnessSlider;

    private string brightnessPlayerPrefsKey = "Brightness";

    void Start()
    {
        // Load brightness PlayerPrefs
        if (PlayerPrefs.HasKey(brightnessPlayerPrefsKey))
        {
            float savedBrightness = PlayerPrefs.GetFloat(brightnessPlayerPrefsKey, 1f);
            brightnessSlider.value = savedBrightness;
            AdjustSceneBrightness(savedBrightness);
        }
        else
        {
            // If no preference saved, use default value
            AdjustSceneBrightness(1f);
        }

        brightnessSlider.onValueChanged.AddListener(AdjustSceneBrightness);
    }

    void AdjustSceneBrightness(float value)
    {
        // Set brightness value in PlayerPrefs
        PlayerPrefs.SetFloat(brightnessPlayerPrefsKey, value);
        PlayerPrefs.Save();

        float adjustedValue = value;

        // Get all lights in the scene
        Light[] lights = FindObjectsOfType<Light>();

        foreach (Light light in lights)
        {
            // Adjust light intensity
            light.intensity = adjustedValue;

            if (light.type == LightType.Spot || light.type == LightType.Point)
            {
                // Adjust light range for spot and point lights
                light.range *= Mathf.Sqrt(adjustedValue);
            }
        }
    }
}
