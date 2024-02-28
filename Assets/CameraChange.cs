using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Transform newCameraPosition; // Reference to the new camera position
    public Camera mainCamera; // Reference to the main camera GameObject

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Trigger");
        if (other.CompareTag("Player")) // Check if the collider that entered the trigger is the player
        {
            Debug.Log("Player Entered Trigger");
            Debug.Log("Before moving camera, Camera position: " + mainCamera.transform.position);
            mainCamera.transform.position = newCameraPosition.position; // Move the camera to the new position
            Debug.Log("After moving camera, Camera position: " + mainCamera.transform.position);
        }
    }
}
