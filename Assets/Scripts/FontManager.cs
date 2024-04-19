using UnityEngine;
using TMPro;

public class FontManager : MonoBehaviour
{
    public TMP_FontAsset defaultFont; // LuckiestGuy SDF
    public TMP_FontAsset dyslexicFont; // opendyslexic SDF

    public TMP_FontAsset selectedFont { get; private set; }


    private static FontManager instance;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Ensure FontManager persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }
        

        // Initialize selected font to default font
        selectedFont = defaultFont;

        // Apply the selected font to all TextMeshProUGUI objects in the scene
        SetFont();
    }

    public void ToggleFont()
    {
        // Toggle between defaultFont and dyslexicFont
        selectedFont = (selectedFont == defaultFont) ? dyslexicFont : defaultFont;

        // Apply the selected font
        SetFont();
    }

    private void SetFont()
    {
        // Find all TextMeshProUGUI objects in the scene
        TextMeshProUGUI[] textObjects = FindObjectsOfType<TextMeshProUGUI>();

        // Apply the selected font to each TextMeshProUGUI object
        foreach (TextMeshProUGUI textObject in textObjects)
        {
            textObject.font = selectedFont;
        }
    }
}
