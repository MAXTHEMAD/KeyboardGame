using System.Collections;
using UnityEngine;

[System.Serializable]
public class StrobeLightSettings
{
    public Light strobeLight; // Reference to the light component
    public float flashInterval = 1f; // Time interval between flashes
    public Color[] flashColors; // Array of colors for the strobe light
    public float intensity = 90f; // Intensity of the strobe light
}

public class DiscoLights : MonoBehaviour
{
    public StrobeLightSettings[] strobeLights; // Array of strobe light settings
    public float spinSpeed = 100f; // Adjust the spin speed as needed

    public float moveDownDistance = 0.5f; // Distance to move down on activation
    public float moveUpDistance = 0.5f; // Distance to move up on deactivation
    private Vector3 originalPosition; // Original position of the disco ball

    private bool isAnimatedObjectInside = false;

    private void Start()
    {
        originalPosition = transform.position; // Store the original position of the disco ball
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
            StartCoroutine(MoveDownAndSpin()); // Start the coroutine to move down and spin
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AnimatedObject"))
        {
            isAnimatedObjectInside = false;
            enabled = false; // Disable the script when the AnimatedObject exits
            StopAllCoroutines(); // Stop all coroutines when the object exits
            ResetStrobeLights(); // Reset the strobe lights when the object exits
            SetStrobeLightsVisibility(false); // Hide the strobe lights when the object exits
            StartCoroutine(MoveUp()); // Move the disco ball back to its original position
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
            settings.strobeLight.intensity = 5000f; // Adjust the intensity as needed

        }
    }

    IEnumerator MoveDownAndSpin()
    {
        // Move down
        Vector3 initialPosition = transform.position;
        Vector3 targetPosition = initialPosition - new Vector3(0f, moveDownDistance, 0f);
        float elapsedTime = 0f;
        float moveDuration = 1f; // Adjust the duration as needed

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the object is at the target position
        transform.position = targetPosition;

        // Start spinning and strobing
        StartCoroutine(SpinAndStrobe());
    }

    IEnumerator MoveUp()
    {
        // Move up
        float elapsedTime = 0f;
        float moveDuration = 1f; // Adjust the duration as needed
        Vector3 targetPosition = originalPosition;
        Vector3 initialPosition = transform.position;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the object is at the target position
        transform.position = targetPosition;
    }

    IEnumerator SpinAndStrobe()
    {
        while (isAnimatedObjectInside)
        {
            // Increase the rotation speed by adjusting the spinSpeed value
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
        settings.strobeLight.intensity = 80f;

        // Wait for the specified flash interval
        yield return new WaitForSeconds(settings.flashInterval);
    }
}
