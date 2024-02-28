using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float followSpeed = 5f; // Adjust the speed of following
    public float distanceFromTarget = 5f; // Adjust the initial distance from the animated object
    public Transform target; // The object to follow
    [SerializeField]
    float heightOffset = 5f;

    void Update()
    {


        // Follow the animated object if it is not null
        if (target != null)
        {
            // Calculate the desired position for the camera
            Vector3 desiredPosition = target.position + target.right * distanceFromTarget;
            desiredPosition.y += heightOffset;

            // Move towards the desired position using Lerp for smooth movement
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

            // Rotate the camera to match the rotation of the target object
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation *  Quaternion.Euler(0, -90, 0), followSpeed * Time.deltaTime);
        }
    }
}
