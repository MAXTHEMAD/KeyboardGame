using UnityEngine;
using TMPro;

public class FontManager : MonoBehaviour
{
    private static FontManager instance;

    public TMP_FontAsset defaultFont;
    public TMP_FontAsset alternativeFont;
    public TMP_FontAsset selectedFont; // Change the access modifier to public

    private string selectedFontKey = "SelectedFont"; // Key for PlayerPrefs

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Load saved font preference or use default font
        if (PlayerPrefs.HasKey(selectedFontKey))
        {
            string fontName = PlayerPrefs.GetString(selectedFontKey);
            selectedFont = GetFontByName(fontName);
        }
        else
        {
            selectedFont = defaultFont;
        }

        ApplySelectedFontToTextMeshProText();

        // Debug log to track loaded font
        Debug.Log("Selected Font: " + selectedFont.name);
    }

    // Method to toggle between default and alternative fonts
    public void ToggleFont()
    {
        if (selectedFont == defaultFont)
        {
            selectedFont = alternativeFont;
        }
        else
        {
            selectedFont = defaultFont;
        }

        ApplySelectedFontToTextMeshProText();

        // Save selected font preference
        PlayerPrefs.SetString(selectedFontKey, selectedFont.name);
        PlayerPrefs.Save();

        // Debug log to track saved font
        Debug.Log("Saved Font: " + selectedFont.name);
    }

    // Method to apply the selected font to all TextMeshPro Text components in the scene
    private void ApplySelectedFontToTextMeshProText()
    {
        TMP_Text[] textComponents = FindObjectsOfType<TMP_Text>();

        foreach (TMP_Text textComponent in textComponents)
        {
            textComponent.font = selectedFont;
        }
    }

    // Helper method to get font asset by name
    private TMP_FontAsset GetFontByName(string fontName)
    {
        if (fontName == defaultFont.name)
        {
            return defaultFont;
        }
        else if (fontName == alternativeFont.name)
        {
            return alternativeFont;
        }
        else
        {
            Debug.LogWarning("Saved font not found. Defaulting to default font.");
            return defaultFont;
        }
    }
}
