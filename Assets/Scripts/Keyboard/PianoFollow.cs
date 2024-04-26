using UnityEngine;

public class PianoFollow : MonoBehaviour

{ 
    public Transform target; 
    public float followSpeed = 5f; 
    public float distanceBehind = 2f; 

    void Update()
    {
        if (target != null)
        {
            // Calculate position behind the target object
            Vector3 targetPosition = target.position - target.forward * distanceBehind;

            // Adjust y-coordinate based on the piano's height
            targetPosition.y = transform.position.y;

            // Set the position
            transform.position = targetPosition;
        }
    }
}
