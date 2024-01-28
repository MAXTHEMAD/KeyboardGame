using System.Collections;
using UnityEngine;

[System.Serializable]
public class StrobeLightSettings
{
    public Light strobeLight; // Reference to the light component
    public float flashInterval = 1f; // Time interval between flashes
    public Color[] flashColors; // Array of colors for the strobe light
    public float intensity = 1f; // Intensity of the strobe light
}

public class DiscoLights : MonoBehaviour
{
    public StrobeLightSettings[] strobeLights; // Array of strobe light settings
    public float spinSpeed = 30f; // Sphere spin speed in degrees per second

    private bool isAnimatedObjectInside = false;

    private void Start()
    {
        // Disable the script initially
        enabled = false;

        // Hide the strobe lights
        SetStrobeLightsVisibility(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AnimatedObject"))
        {
            isAnimatedObjectInside = true;
            enabled = true; // Enable the script when the AnimatedObject enters
            SetStrobeLightsVisibility(true); // Show the strobe lights when the object enters
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AnimatedObject"))
        {
            isAnimatedObjectInside = false;
            enabled = false; // Disable the script when the AnimatedObject exits
            StopCoroutine(SpinAndStrobe()); // Stop the coroutine when the object exits
            ResetStrobeLights(); // Reset the strobe lights when the object exits
            SetStrobeLightsVisibility(false); // Hide the strobe lights when the object exits
        }
    }

    private void SetStrobeLightsVisibility(bool isVisible)
    {
        foreach (var settings in strobeLights)
        {
            settings.strobeLight.enabled = isVisible;

            // If making lights visible, set their color to a random flash color
            if (isVisible && settings.flashColors.Length > 0)
            {
                Color randomColor = settings.flashColors[Random.Range(0, settings.flashColors.Length)];
                settings.strobeLight.color = randomColor;
            }
        }
    }

    private void ResetStrobeLights()
    {
        foreach (var settings in strobeLights)
        {
            settings.strobeLight.enabled = false;
            settings.strobeLight.intensity = 1f;
        }
    }

    IEnumerator SpinAndStrobe()
    {
        while (true)
        {
            // Spin the sphere
            transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);

            // Flash each strobe light
            foreach (var settings in strobeLights)
            {
                yield return StartCoroutine(FlashStrobeLight(settings));
            }

            yield return null;
        }
    }

    IEnumerator FlashStrobeLight(StrobeLightSettings settings)
    {
        // Choose a random color from the flashColors array
        Color randomColor = settings.flashColors[Random.Range(0, settings.flashColors.Length)];

        // Set the strobe light color and intensity
        settings.strobeLight.color = randomColor;
        settings.strobeLight.intensity = settings.intensity;

        // Turn on the strobe light
        settings.strobeLight.enabled = true;

        // Wait for a short duration
        yield return new WaitForSeconds(0.1f);

        // Turn off the strobe light
        settings.strobeLight.enabled = false;

        // Reset intensity to its original value
        settings.strobeLight.intensity = 1f;

        // Wait for the specified flash interval
        yield return new WaitForSeconds(settings.flashInterval);
    }
}
