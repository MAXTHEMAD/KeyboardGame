using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MidiCube : MonoBehaviour
{
    [SerializeField]
    private InputActionReference midiInputs;

    Vector3 startPos;
    [SerializeField]
    float rkey;
    public bool rdown;

    private void Awake()
    {
        midiInputs.action.performed += context => rkey = context.action.ReadValue<float>();
        midiInputs.action.Enable();
        startPos = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rkey = Input.GetKeyDown(KeyCode.R) ? 1 : 0;
        /*if (rkey == 1)
        {
            if (!rdown)
            {
                transform.position += transform.up * 0.05f;
            }
        }
        else if (rkey == 0)
        {
            transform.position = startPos;
            rdown = false;
        }*/
        transform.position += transform.up * rkey;
        Debug.Log(rkey);
    }


}
