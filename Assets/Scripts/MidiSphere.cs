using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class MidiSphere : MonoBehaviour
{
    public InputActionAsset actions;

    InputAction[] keys;



    private void Awake()
    {
        actions.Enable();
        keys = actions.FindActionMap("Midi").actions.ToArray();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            transform.GetChild(i).GetComponent<RectTransform>().localScale = new Vector3(1,(1) - keys[i].ReadValue<float>(), 1);
        }
        //Debug.Log(keys[1].IsPressed());
        /*foreach (InputAction key in keys)
        {
            Debug.Log(key.ToString() + "  V:" + key.ReadValue<float>());
        }*/
    }
}
