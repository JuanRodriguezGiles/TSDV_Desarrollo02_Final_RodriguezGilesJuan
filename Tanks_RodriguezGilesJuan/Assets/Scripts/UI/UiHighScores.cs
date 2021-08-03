using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class UiHighScores : MonoBehaviour
{
    public List<TMP_Text> highScoresText;

    void OnEnable()
    {
        UpdateHighScoreText();
    }
    void UpdateHighScoreText()
    {
        List<int> scores = HighScoreManager.Instance.highScores;
        for (int i = 0; i < scores.Count; i++)
        {
            if (scores[i] != 0)
                highScoresText[i].text = scores[i].ToString();
            else
            {
                highScoresText[i].text = " ";
            }
        }
    }
    public void LoadMainMenuScene()
    {
        GameManager.Instance.LoadMainMenuScene();
    }
}