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

    // This method should be called when the player wants to switch fonts
    public void ToggleFont()
    {
        if (fontManager != null)
        {
            fontManager.ToggleFont(); // Toggle between default and dyslexic fonts
        }
        else
        {
            Debug.LogWarning("FontManager is null. Font switching failed.");
        }
    }
}
