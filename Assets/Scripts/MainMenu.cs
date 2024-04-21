using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Image lofi;
    [SerializeField]
    Image funk;
    private void Awake()
    {
        lofi.fillAmount = Mathf.InverseLerp(0, Song.LoadSong("Lofi").Length * 256, Scores.scoreOnSongs["Lofi"]);
        funk.fillAmount = Mathf.InverseLerp(0, Song.LoadSong("Funk").Length * 256, Scores.scoreOnSongs["Funk"]);
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
