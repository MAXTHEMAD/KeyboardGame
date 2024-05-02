using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stars : MonoBehaviour
{
    [SerializeField]
    Image lofi;
    [SerializeField]
    Image funk;
    private void Awake()
    {
        lofi.fillAmount = round(Mathf.InverseLerp(0, Song.LoadSong("Lofi").Length * 256, Scores.scoreOnSongs["Lofi"]));
        funk.fillAmount = round(Mathf.InverseLerp(0, Song.LoadSong("Funk").Length * 256, Scores.scoreOnSongs["Funk"]));
        lofi.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Scores.scoreOnSongs["Lofi"] + "/" + Song.LoadSong("Lofi").Length * 256;
        funk.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Scores.scoreOnSongs["Funk"] + "/" + Song.LoadSong("Funk").Length * 256;
    }

    private float round(float amount)
    {
        if (amount == 1)
            return 1;
        else if (amount >= 0.8f)
            return 0.8f;
        else if (amount >= 0.6f)
            return 0.6f;
        else if (amount >= 0.4f)
            return 0.4f;
        else if (amount >= 0.2f)
            return 0.2f;
        return 0;
    }
}
