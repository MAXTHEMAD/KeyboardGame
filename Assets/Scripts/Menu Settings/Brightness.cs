using UnityEngine;
using UnityEngine.UI;

public class Brightness : MonoBehaviour
{
    public Slider brightnessSlider;

    void Start()
    {
        // Load brightness PlayerPrefs
        float savedBrightness = PlayerPrefs.GetFloat("Brightness", 1f);

        // Set the slider value to the saved brightness value
        brightnessSlider.value = savedBrightness;

        // Attach listener to the slider's value change event
        brightnessSlider.onValueChanged.AddListener(AdjustSceneBrightness);

        // Adjust scene brightness based on the saved value
        AdjustSceneBrightness(savedBrightness);
    }

    void AdjustSceneBrightness(float value)
    {
        // Set brightness value in PlayerPrefs
        PlayerPrefs.SetFloat("Brightness", value);

        // Map slider value to brightness linearly
        float adjustedValue = value; // No need for non-linear mapping

        // Get all lights in the scene
        Light[] lights = FindObjectsOfType
        <Light>();

        // Loop through each light and adjust its intensity
        foreach (Light light in lights)
        {
            // Adjust the intensity of the light based on the adjusted slider value
            light.intensity = adjustedValue;

            if (light.type == LightType.Spot || light.type == LightType.Point)
            {
                // Adjust the range of the light based on the adjusted slider value
                light.range *= Mathf.Sqrt(adjustedValue);
            }
        }
    }
}
