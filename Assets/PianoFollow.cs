using UnityEngine;

public class PianoFollow : MonoBehaviour

{ 
    public Transform target; // The object to follow (the animated object)
    public float followSpeed = 5f; // Adjust the speed of following
    public float distanceBehind = 2f; // Adjust the distance behind the animated object

    void Update()
    {
        if (target != null)
        {
            // Calculate the desired position behind the target object
            Vector3 targetPosition = target.position - target.forward * distanceBehind;

            // Adjust the y-coordinate of the target position based on the piano's height
            targetPosition.y = transform.position.y;

            // Set the position directly without using Lerp
            transform.position = targetPosition;
        }
    }
}
