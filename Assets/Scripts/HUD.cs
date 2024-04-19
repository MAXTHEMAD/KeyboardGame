using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public List<Slider> HealthSliders;
    public List<Slider> ScoreSliders;
    public Image image;
    public void SetHealth(float health)
    {
        foreach (Slider slider in HealthSliders)
        {
            slider.value = health;
        }
    }
    public void SetScore(float score)
    {
        foreach(Slider slider in ScoreSliders)
        {
            slider.value = score;
        }
        //image.fillAmount = score;
    }
    public void SetHealthandScore(float health,float score)
    {
        SetHealth(health);
        SetScore(score);
    }
    
    public void Setup(int maxScore)
    {
        foreach (Slider slider in ScoreSliders)
        {
            slider.maxValue = maxScore;
        }
    }
}
