using UnityEngine;
using TMPro;

public class PopupTextController : MonoBehaviour
{
    public Canvas popupCanvas;
    public TextMeshProUGUI popupText; // Change the type to TextMeshProUGUI

    void Start()
    {
        // Disable the canvas and text initially
        popupCanvas.enabled = false;
        popupText.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered");
        if (other.CompareTag("AnimatedObject"))
        {
            Debug.Log("AnimatedObject Entered Trigger");

            // Activate the canvas and set the text content
            popupText.text = "Hello There!";
            popupCanvas.enabled = true;
            popupText.enabled = true;

            // Additional debug logs
            Debug.Log("Canvas Enabled: " + popupCanvas.enabled);
            Debug.Log("Text Enabled: " + popupText.enabled);
        
    

}
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the animated object
        if (other.CompareTag("AnimatedObject"))
        {
            // Deactivate the canvas and text
            popupCanvas.enabled = false;
            popupText.enabled = false;

            // Debug log for debugging purposes
            Debug.Log("Trigger Exited");
        }
    }
}
