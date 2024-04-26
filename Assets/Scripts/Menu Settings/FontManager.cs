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
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
        

        // Initialize selected font to default font
        selectedFont = defaultFont;

        // Apply the selected font 
        SetFont();
    }

    public void ToggleFont()
    {
        // Toggle between font
        selectedFont = (selectedFont == defaultFont) ? dyslexicFont : defaultFont;

        // Apply the selected font
        SetFont();
    }

    private void SetFont()
    {
        
        TextMeshProUGUI[] textObjects = FindObjectsOfType<TextMeshProUGUI>();

        
        foreach (TextMeshProUGUI textObject in textObjects)
        {
            textObject.font = selectedFont;
        }
    }
}
