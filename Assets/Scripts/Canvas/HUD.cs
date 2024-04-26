using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Slider HealthSlider;
    public Slider ScoreSlider;
    public Image image;
    public void SetHealth(float health)
    {
        HealthSlider.value = health;
    }
    public void SetScore(float score)
    {
        ScoreSlider.value = score;
        image.fillAmount = Mathf.InverseLerp(0, ScoreSlider.maxValue,score);
    }
    public void SetHealthandScore(float health,float score)
    {
        SetHealth(health);
        SetScore(score);
    }
    
    public void Setup(int maxScore)
    {
        ScoreSlider.maxValue = maxScore;
    }
}
