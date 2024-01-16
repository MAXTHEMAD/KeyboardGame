using UnityEngine;
using System.Collections;

public class LightAnimationTrigger : MonoBehaviour
{
    public Light[] lights; // Assign the Lights in the Inspector
    public float animationDuration = 2f; // Duration of the custom light animation in seconds
    public float maxIntensity = 10f; // Desired maximum intensity
    public float timeBetweenBlinks = 0.5f; // Time between each blink

    private bool hasEntered = false;

    void Start()
    {
        // Initialize lights with intensity 0
        foreach (Light lightObject in lights)
        {
            if (lightObject != null)
            {
                lightObject.intensity = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasEntered && other.CompareTag("AnimatedObject"))
        {
            hasEntered = true;
            Debug.Log("Motion detected! Triggering custom light animation.");

            StartCoroutine(BlinkLightsSequentially());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (hasEntered && other.CompareTag("AnimatedObject"))
        {
            hasEntered = false;
            Debug.Log("AnimatedObject exited. Stopping custom light animation.");

            StopAllCoroutines();

            // Reset lights to intensity 0
            foreach (Light lightObject in lights)
            {
                if (lightObject != null)
                {
                    lightObject.intensity = 0f;
                }
            }
        }
    }

    private void StopDefaultLightAnimation(Light lightObject)
    {
        // Implement logic to stop the default light animation, if applicable
        // For example, you might need to stop a built-in Unity animation or a specific component
    }

    private void TriggerCustomLightAnimation(Light lightObject)
    {
        StartCoroutine(BlinkLight(lightObject));
    }

    private IEnumerator BlinkLightsSequentially()
    {
        foreach (Light lightObject in lights)
        {
            if (lightObject != null)
            {
                StopDefaultLightAnimation(lightObject);
                TriggerCustomLightAnimation(lightObject);
                yield return new WaitForSeconds(timeBetweenBlinks);
            }
        }
    }

    private IEnumerator BlinkLight(Light lightObject)
    {
        int blinkCount = 5; // Adjust the number of blinks

        for (int i = 0; i < blinkCount; i++)
        {
            lightObject.intensity = maxIntensity * 80f; // Set intensity to the desired value (scaled by 8)
            yield return new WaitForSeconds(animationDuration / (blinkCount * 2));

            lightObject.intensity = 0f; // Set intensity back to 0
            yield return new WaitForSeconds(timeBetweenBlinks);
        }
    }
}
