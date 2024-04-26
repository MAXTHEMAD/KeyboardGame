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

       
        brightnessSlider.onValueChanged.AddListener(AdjustSceneBrightness);
    }

    
    void AdjustSceneBrightness(float value)
    {
        // Set brightness value in PlayerPrefs
        PlayerPrefs.SetFloat("Brightness", value);

        // Get all lights in the scene
        Light[] lights = FindObjectsOfType<Light>();

        // Loop through each light and adjust its intensity
        foreach (Light light in lights)
        {
            // Adjust the intensity of the light based on the slider value
            light.intensity = value;

           
            if (light.type == LightType.Spot || light.type == LightType.Point)
            {
                
                light.range *= Mathf.Sqrt(value);
            }
        }
    }
}
