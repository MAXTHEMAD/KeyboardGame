using UnityEngine;
using UnityEngine.UI;

public class Colourblindtoggle : MonoBehaviour
{
    // Reference to the toggle UI component
    public Toggle colorblindToggle;

    // Boolean to store the current colorblind mode status
    private bool isColorblindModeEnabled = false;

    // Method to toggle colorblind mode
    public void ToggleColorblindMode()
    {
        isColorblindModeEnabled = colorblindToggle.isOn;

        // Call a method to adjust colors based on the colorblind mode status
        AdjustColors(isColorblindModeEnabled);

        // Optionally, save the colorblind mode status to player preferences
        PlayerPrefs.SetInt("ColorblindModeEnabled", isColorblindModeEnabled ? 1 : 0);
    }

    // Method to adjust colors based on colorblind mode status
    private void AdjustColors(bool enableColorblindMode)
    {
        // Implement your logic here to adjust colors based on the colorblind mode status
        // For example, you can modify the color values of various game elements
        // based on a colorblind-friendly palette.
    }

    private void Start()
    {
        // Initialize the colorblind mode status based on player preferences
        isColorblindModeEnabled = PlayerPrefs.GetInt("ColorblindModeEnabled", 0) == 1;

        // Set the toggle's state based on the colorblind mode status
        colorblindToggle.isOn = isColorblindModeEnabled;

        // Optionally, adjust colors immediately based on the initial colorblind mode status
        AdjustColors(isColorblindModeEnabled);
    }
}
