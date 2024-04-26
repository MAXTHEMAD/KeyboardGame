using System.Collections;
using UnityEngine;

public class StageLights : MonoBehaviour
{
    public Light targetLight;
    public float minIntensity = 0f;
    public float maxIntensity = 1000f;
    public float flashDuration = 1f;
    public float interval = 1f;

    private void Start()
    {
        StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        while (true)
        {
            targetLight.intensity = maxIntensity;
            yield return new WaitForSeconds(flashDuration);

            targetLight.intensity = minIntensity;
            yield return new WaitForSeconds(interval);
        }
    }
}
