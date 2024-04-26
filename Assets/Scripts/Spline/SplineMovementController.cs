using UnityEngine;

public class SplineMovementController : MonoBehaviour
{
    public BezierSpline spline;
    public float duration = 10f;
    private bool shouldMove = false;

    private float progress;

    public void StartSplineMovement()
    {
        progress = 0f;
        shouldMove = true;
    }

    public void StopSplineMovement()
    {
        shouldMove = false;
    }

    private void Update()
    {
        if (shouldMove && progress < 1f)
        {
            progress += Time.deltaTime / duration;
            Vector3 position = spline.GetPoint(progress);
            // Do something with the position (e.g., move the object to that position)
        }
    }
}
