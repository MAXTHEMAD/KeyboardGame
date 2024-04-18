using UnityEngine;
using TMPro;

public class FontManager : MonoBehaviour
{
    public bool IsEasyReadMode { get; set; }

    public TMP_FontAsset normalFont;
    public TMP_FontAsset easyReadFont;

    public TMP_FontAsset selectedFont;

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

        // Initialize selected font
        selectedFont = normalFont;

        // Apply the selected font to all TextMeshProUGUI objects in the scene
        SetFont();
    }

    public void ToggleFont()
    {
        // Toggle between normalFont and easyReadFont
        selectedFont = (selectedFont == normalFont) ? easyReadFont : normalFont;

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
