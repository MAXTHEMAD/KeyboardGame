using UnityEngine;
using TMPro;

public class FontManager : MonoBehaviour
{
    private static FontManager instance;

    public TMP_FontAsset selectedFont;

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

    // Method to set the selected font
    public void SetSelectedFont(TMP_FontAsset font)
    {
        selectedFont = font;
    }

    // Method to get the selected font
    public TMP_FontAsset GetSelectedFont()
    {
        return selectedFont;
    }
}
