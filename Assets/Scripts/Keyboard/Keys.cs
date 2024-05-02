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

    private void Awake()
    {
        actions.Enable();
        keysInput = actions.FindActionMap("Midi").actions.ToArray();
        keysObj = transform.GetComponentsInChildren<Key>();
        keyStrengths = new float[keysInput.Length];
    
        if (PlayerPrefs.HasKey("PianoVolume"))
            volume = PlayerPrefs.GetFloat("PianoVolume");
}

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
        }
    }

}