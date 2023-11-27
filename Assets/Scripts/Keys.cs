using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class Keys : MonoBehaviour
{
    public InputActionAsset actions;
    public Key[] keysObj;

    InputAction[] keysInput;
    public float[] keyStrengths;


    private void Awake()
    {
        actions.Enable();
        keysInput = actions.FindActionMap("Midi").actions.ToArray();
        keysObj = transform.GetComponentsInChildren<Key>();
        keyStrengths = new float[keysInput.Length];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < keysInput.Length; i++)
        {
            if (keysInput[i].ReadValue<float>() != keyStrengths[i])
            {
                if(keysInput[i].ReadValue<float>() > 0)
                {
                    keyStrengths[i] = keysInput[i].ReadValue<float>();
                    keysObj[i].keyPressed(keyStrengths[i]);
                } else
                {
                    keyStrengths[i] = keysInput[i].ReadValue<float>();
                    keysObj[i].keyReleased();
                }
            }
            //transform.GetChild(i).GetComponent<RectTransform>().localScale = new Vector3(1,(1) - keysInput[i].ReadValue<float>(), 1);
        }
    }
}
