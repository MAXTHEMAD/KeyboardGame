using UnityEngine;

public class FontSwitcher : MonoBehaviour
{
    private FontManager fontManager;

    private void Start()
    {
        fontManager = FindObjectOfType<FontManager>();
        if (fontManager == null)
        {
            Debug.LogError("FontManager not found in the scene!");
        }
    }

    
    public void ToggleFont()
    {
        if (fontManager != null)
        {
            fontManager.ToggleFont(); 
        }
        else
        {
            Debug.LogWarning("FontManager is null. Font switching failed.");
        }
    }
}
