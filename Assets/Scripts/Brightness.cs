using UnityEngine;
using UnityEngine.UI;

public class Brightness : MonoBehaviour
{
    // Reference to the slider UI component for brightness
    public Slider brightnessSlider;

    // Start is called before the first frame update
    void Start()
    {
        // Load the brightness value from PlayerPrefs
        float savedBrightness = PlayerPrefs.GetFloat("Brightness", 1f);

        // Set the slider value to the saved brightness value
        brightnessSlider.value = savedBrightness;

        // Add a listener to the brightness slider
        brightnessSlider.onValueChanged.AddListener(AdjustSceneBrightness);
    }

    // Method to adjust the brightness of the scene
    void AdjustSceneBrightness(float value)
    {
        // Set the brightness value in PlayerPrefs
        PlayerPrefs.SetFloat("Brightness", value);

        // Get all lights in the scene
        Light[] lights = FindObjectsOfType<Light>();

        // Loop through each light and adjust its intensity
        foreach (Light light in lights)
        {
            // Adjust the intensity of the light based on the slider value
            light.intensity = value;

            // Additionally, you may want to handle spotlights and point lights differently
            if (light.type == LightType.Spot || light.type == LightType.Point)
            {
                // Adjust the range of spotlights and point lights based on the slider value
                light.range *= Mathf.Sqrt(value);
            }
        }
    }
}
