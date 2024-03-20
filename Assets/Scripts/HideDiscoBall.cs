using UnityEngine;
using System.Collections;

public class HideDiscoBall : MonoBehaviour
{
    public GameObject objectToShow; // Reference to the object you want to appear

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AnimatedObject"))
        {
            ShowObject();
        }
    }


    private void ShowObject()
    {
        if (objectToShow != null)
        {
            objectToShow.SetActive(true);
        }
    }
}
