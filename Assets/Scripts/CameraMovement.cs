using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 2.0f; // Adjust the speed of camera movement
    public float followSpeed = 5f; // Adjust the speed of following
    public float distanceFromTarget = 5f; // Adjust the initial distance from the animated object
    public Transform target; // The object to follow

    void Update()
    {
        // Move the camera forward based on the speed and time
        Vector3 newPosition = transform.position + Vector3.forward * speed * Time.deltaTime;
        transform.position = newPosition;

        // Follow the animated object if it is not null
        if (target != null)
        {
            // Calculate the desired position for the camera
            Vector3 desiredPosition = target.position + target.right * distanceFromTarget;
            desiredPosition.y = transform.position.y;

            // Move towards the desired position using Lerp for smooth movement
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

            // Rotate the camera to match the rotation of the target object
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation *  Quaternion.Euler(0, -90, 0), followSpeed * Time.deltaTime);
        }
    }
}
