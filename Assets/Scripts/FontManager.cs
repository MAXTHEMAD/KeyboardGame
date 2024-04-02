using UnityEngine;
using TMPro;

public class FontManager : MonoBehaviour
{
    public TMP_FontAsset normalFont;
    public TMP_FontAsset easyReadFont;

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
    }

    private void Start()
    {
        SetFont();
    }

    public void ToggleFont()
    {
        // Toggle the font selection
        if (normalFont == TMP_FontAsset.defaultFontAsset)
        {
            normalFont = easyReadFont;
        }
        else
        {
            normalFont = TMP_FontAsset.defaultFontAsset;
        }

        // Apply the font changes
        SetFont();
    }

    private void SetFont()
    {
        // Find all TextMeshProUGUI objects in the scene
        TextMeshProUGUI[] textObjects = FindObjectsOfType<TextMeshProUGUI>();

        // Apply the selected font to each TextMeshProUGUI object
        foreach (TextMeshProUGUI textObject in textObjects)
        {
            if (normalFont != null)
            {
                textObject.font = normalFont;
            }
        }
    }
}
