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
    public KeyBoard Keyboard;
    public float volume = 1.0f;

    InputAction[] keysInput;
    float[] keyStrengths;
    private string volumePlayerPrefsKey = "PianoVolume"; // PlayerPrefs key for saving volume

    private void Awake()
    {
        actions.Enable();
        keysInput = actions.FindActionMap("Midi").actions.ToArray();
        keysObj = transform.GetComponentsInChildren<Key>();
        keyStrengths = new float[keysInput.Length];
    
    if (PlayerPrefs.HasKey(volumePlayerPrefsKey))
        {
            volume = PlayerPrefs.GetFloat(volumePlayerPrefsKey);
        }
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
                    keysObj[i].KeyPressed(keyStrengths[i]);
                    Keyboard.KeyState(i, true);
                } else
                {
                    keyStrengths[i] = keysInput[i].ReadValue<float>();
                    keysObj[i].KeyReleased();
                    Keyboard.KeyState(i, false);
                }
            }
            //transform.GetChild(i).GetComponent<RectTransform>().localScale = new Vector3(1,(1) - keysInput[i].ReadValue<float>(), 1);
        }
    }

private void OnDestroy()
{
    // Save volume preference when the script is destroyed
    PlayerPrefs.SetFloat(volumePlayerPrefsKey, volume);
    PlayerPrefs.Save();
}
}