using System.Collections;
using UnityEngine;

public class MoveObjectBetweenPoints : MonoBehaviour
{
    // References to the start, middle, and end points
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;

    
    public float speed = 2f;

   
    public float delaySeconds = 1f;

    private bool isMoving;

    void Start()
    {
       
        StartCoroutine(MoveObjectCoroutine());
    }

    IEnumerator MoveObjectCoroutine()
    {
        // Wait for delay before starting movement
        yield return new WaitForSeconds(delaySeconds);

        // Set the start time and begin movement from A to B
        float startTime = Time.time;
        float journeyLengthAB = Vector3.Distance(pointA.position, pointB.position);
        float journeyLengthBC = Vector3.Distance(pointB.position, pointC.position);
        float journeyLength = journeyLengthAB;

        while (true)
        {
            
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;

           
            transform.position = Vector3.Lerp(pointA.position, pointB.position, fractionOfJourney);

         
            if (transform.position == pointB.position)
            {
                
                startTime = Time.time;
                journeyLength = journeyLengthBC;
                pointA = pointB;
                pointB = pointC;
            }
            else if (transform.position == pointC.position)
            {
                
                break;
            }

            
            yield return null;
        }
    }
}
