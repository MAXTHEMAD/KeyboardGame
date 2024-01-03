using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 2.0f; // Adjust the speed of camera movement
    public Vector3 targetPosition; // Set the target position for the camera to stop

    void Update()
    {
        // Calculate the new position based on the speed and time
        Vector3 newPosition = transform.position + Vector3.forward * speed * Time.deltaTime;

        // Update the camera's position
        transform.position = newPosition;

        // Check if the camera has reached or passed the target position
        if (transform.position.z >= targetPosition.z)
        {
            // Set the camera's position to the target position
            transform.position = targetPosition;

            // Optionally, you may want to disable further updates or perform additional actions
            enabled = false; // Disable the script to stop further updates
        }
    }
}
