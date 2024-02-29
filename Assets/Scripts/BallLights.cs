using System.Collections;
using UnityEngine;

public class BallLights : MonoBehaviour
{
    public Light[] targetLights;
    public float minIntensity = 0f;
    public float maxIntensity = 1000f;
    public float flashDuration = 1f;
    public float interval = 1f;
    public int lightsPerGroup = 2;

    private bool playerEntered = false;
    private Coroutine flashCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AnimatedObject"))
        {
            playerEntered = true;
            if (flashCoroutine == null)
            {
                flashCoroutine = StartCoroutine(Flash());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AnimatedObject"))
        {
            playerEntered = false;
            if (flashCoroutine != null)
            {
                StopCoroutine(flashCoroutine);
                flashCoroutine = null;
                foreach (var light in targetLights)
                {
                    light.intensity = minIntensity;
                }
            }
        }
    }

    private IEnumerator Flash()
    {
        while (playerEntered)
        {
            for (int i = 0; i < targetLights.Length; i += lightsPerGroup)
            {
                for (int j = 0; j < lightsPerGroup; j++)
                {
                    if (i + j < targetLights.Length)
                    {
                        targetLights[i + j].intensity = maxIntensity;
                    }
                }
                yield return new WaitForSeconds(flashDuration);
                for (int j = 0; j < lightsPerGroup; j++)
                {
                    if (i + j < targetLights.Length)
                    {
                        targetLights[i + j].intensity = minIntensity;
                    }
                }
            }
            yield return new WaitForSeconds(interval);
        }
    }
}
