using UnityEngine;
using TMPro;

public class PopupTextController : MonoBehaviour
{
    public Canvas popupCanvas;
    public TextMeshProUGUI popupText; 

    void Start()
    {
        // Disable the canvas 
        popupCanvas.enabled = false;
        popupText.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered");
        if (other.CompareTag("AnimatedObject"))
        {
            Debug.Log("AnimatedObject Entered Trigger");

            // Activate the canvas 
            popupText.text = "Hello There!";
            popupCanvas.enabled = true;
            popupText.enabled = true;
    

}
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the animated object
        if (other.CompareTag("AnimatedObject"))
        {
            // Deactivate 
            popupCanvas.enabled = false;
            popupText.enabled = false;

        
        }
    }
}
