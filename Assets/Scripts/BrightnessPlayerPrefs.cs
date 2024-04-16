using UnityEngine;
using UnityEngine.SceneManagement;

public class BrightnessPlayerPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Load the brightness value from PlayerPrefs
        float savedBrightness = PlayerPrefs.GetFloat("Brightness", 1f);

        // Get all lights in the scene
        Light[] lights = FindObjectsOfType<Light>();

        // Loop through each light and adjust its intensity
        foreach (Light light in lights)
        {
            // Adjust the intensity of the light based on the saved brightness value
            light.intensity = savedBrightness;

            // Additionally, you may want to handle spotlights and point lights differently
            if (light.type == LightType.Spot || light.type == LightType.Point)
            {
                // Adjust the range of spotlights and point lights based on the saved brightness value
                light.range *= Mathf.Sqrt(savedBrightness);
            }
        }
    }

    // Method to load the DanTesterSpline scene
    public void LoadDanTesterSplineScene()
    {
        // Load the DanTesterSpline scene
        SceneManager.LoadScene("DanTesterSpline");
    }
}
