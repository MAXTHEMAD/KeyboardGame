using System.Collections;
using UnityEngine;

public class MoveObjectBetweenPoints : MonoBehaviour
{
    // References to the start, middle, and end points
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;

    // Movement speed in units per second
    public float speed = 2f;

    // Delay before movement starts in seconds
    public float delaySeconds = 1f;

    private bool isMoving;

    void Start()
    {
        // Start the movement coroutine
        StartCoroutine(MoveObjectCoroutine());
    }

    IEnumerator MoveObjectCoroutine()
    {
        // Wait for the specified delay before starting movement
        yield return new WaitForSeconds(delaySeconds);

        // Set the start time and begin movement from A to B
        float startTime = Time.time;
        float journeyLengthAB = Vector3.Distance(pointA.position, pointB.position);
        float journeyLengthBC = Vector3.Distance(pointB.position, pointC.position);
        float journeyLength = journeyLengthAB;

        while (true)
        {
            // Calculate the current distance traveled
            float distanceCovered = (Time.time - startTime) * speed;

            // Calculate the fraction of the journey completed
            float fractionOfJourney = distanceCovered / journeyLength;

            // Move the object a fraction of the distance between the two points
            transform.position = Vector3.Lerp(pointA.position, pointB.position, fractionOfJourney);

            // Check if reached the destination
            if (transform.position == pointB.position)
            {
                // If the object has reached point B, start moving to point C
                startTime = Time.time;
                journeyLength = journeyLengthBC;
                pointA = pointB;
                pointB = pointC;
            }
            else if (transform.position == pointC.position)
            {
                // If the object has reached point C, stop moving
                break;
            }

            // Yield to the next frame
            yield return null;
        }
    }
}
