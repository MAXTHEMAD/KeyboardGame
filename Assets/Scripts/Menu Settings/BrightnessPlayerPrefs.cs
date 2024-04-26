using UnityEngine;
using UnityEngine.SceneManagement;

public class BrightnessPlayerPrefs : MonoBehaviour
{

    void Start()
    {
        // Load the brightness 
        float savedBrightness = PlayerPrefs.GetFloat("Brightness", 1f);

        // Get all lights in the scene
        Light[] lights = FindObjectsOfType<Light>();

        // Loop through each light 
        foreach (Light light in lights)
        {
            // Adjust the intensity of the light 
            light.intensity = savedBrightness;

            if (light.type == LightType.Spot || light.type == LightType.Point)
            {
               
                light.range *= Mathf.Sqrt(savedBrightness);
            }
        }
    }


    public void LoadDanTesterSplineScene()
    {
        // Load Funk
        SceneManager.LoadScene("Funk");
    }
}
