using UnityEngine;
using UnityEngine.UI;

public class KeyboardVolume : MonoBehaviour
{
    public Slider volumeSlider;
    public Keys keysScript;

    void Start()
    {
       
        volumeSlider.value = keysScript.volume;

        
        volumeSlider.onValueChanged.AddListener(HandleVolumeChanged);
    }

    void HandleVolumeChanged(float value)
    {
     
        keysScript.volume = value;
    }
}
