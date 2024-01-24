using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target; // The object to follow
    public float followSpeed = 5f; // Adjust the speed of following

    private float originalY;

    void Start()
    {
        // Store the original y value
        originalY = transform.position.y;
    }

    void Update()
    {
        if (target != null)
        {
            // Get the current position of the target object
            Vector3 targetPosition = target.position;

            // Calculate the desired position for this object to move towards the target
            Vector3 desiredPosition = new Vector3(targetPosition.x, originalY, targetPosition.z);

            // Move towards the desired position using Lerp for smooth movement
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

            // Calculate the direction to the target (ignoring changes in y-direction)
            Vector3 directionToTarget = target.position - transform.position;
            directionToTarget.y = 0;

            // Rotate to face the target on the x-axis
            if (directionToTarget != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                transform.rotation = Quaternion.Euler(targetRotation.eulerAngles.x, 0, 0);
            }
        }
    }
}
