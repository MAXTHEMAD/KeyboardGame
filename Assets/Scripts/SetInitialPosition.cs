using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SetInitialPosition : MonoBehaviour
{
    public Vector3 initialPosition = new Vector3(111.8005f, 29.9945f, 120.4367f); // Set the desired initial position in the Inspector

    void Start()

    {
       
        // Set the initial position of the object
        transform.position = initialPosition;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0f, transform.rotation.eulerAngles.z);
    }
}
