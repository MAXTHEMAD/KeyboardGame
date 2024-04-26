using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class FeedBackText : MonoBehaviour
{
    bool[] texts;
    private void Awake()
    {
        texts = new bool[transform.childCount];
    }

    public void feedback(int scoreband)
    {
        if (scoreband == 0) return;
        int index = 0;
        for (int i = 0; i < texts.Length; i++)
        {
            if (!texts[i])
            {
                index = i; break;
            }
        }
        StartCoroutine(showText(index,scoreband));
    }
    IEnumerator showText(int i,int score)
    {
        float time = 1;
        RectTransform text = (RectTransform)transform.GetChild(i);
        text.gameObject.SetActive(true);
        texts[i] = true;
        text.gameObject.GetComponent<TextMeshProUGUI>().color = score == 1 ? new Color(242f/255f, 1f, 1f) : score == 2 ? Color.green : Color.yellow;
        text.gameObject.GetComponent<TextMeshProUGUI>().text = score == 1 ? "Perfect!" : score == 2 ? "Good" : "Okay";

        while (time > 0)
        {
            time -= Time.deltaTime /2;
            text.Translate(Vector2.right * 2);
            text.GetComponent<TextMeshProUGUI>().color = new Color(text.GetComponent<TextMeshProUGUI>().color.r, text.GetComponent<TextMeshProUGUI>().color.g, text.GetComponent<TextMeshProUGUI>().color.b,time);
            yield return null;
        }
        text.gameObject.SetActive(false);
        text.localPosition = new Vector2(0,100*i);
        texts[i] = false;
    }
}
