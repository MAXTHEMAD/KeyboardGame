using UnityEngine;
using UnityEngine.UI;

public class SoundEffectsVolume : MonoBehaviour
{
    public Slider slider; 

    private SoundEffectsManager soundEffectsManager;

    private void Start()
    {
        soundEffectsManager = FindObjectOfType<SoundEffectsManager>();

       
        slider.onValueChanged.AddListener(ApplySoundEffectsVolume);
    }

    public void ApplySoundEffectsVolume(float value)
    {
       
        soundEffectsManager.SetSoundEffectsVolume(value);
    }
}
