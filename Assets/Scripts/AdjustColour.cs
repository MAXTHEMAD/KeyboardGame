using UnityEngine;
using UnityEngine.UI;

public class AdjustColour : MonoBehaviour
{
    // Reference to the colors used in the game (you can add more as needed)
    public Color normalColor;
    public Color colorblindColor;

    // Method to adjust colors based on colorblind mode status
    public void AdjustColors(bool enableColorblindMode)
    {
        // Get all game objects with a renderer component (you may need to adjust this based on your game structure)
        Renderer[] renderers = FindObjectsOfType<Renderer>();

        // Loop through each renderer and adjust its material color
        foreach (Renderer renderer in renderers)
        {
            // Check if the renderer's material has a color property
            if (renderer.material.HasProperty("_Color"))
            {
                // Get the original color of the material
                Color originalColor = renderer.material.color;

                // Set the new color based on colorblind mode status
                Color newColor = enableColorblindMode ? colorblindColor : normalColor;

                // Apply the new color to the material
                renderer.material.color = newColor;
            }
        }
    }
}
