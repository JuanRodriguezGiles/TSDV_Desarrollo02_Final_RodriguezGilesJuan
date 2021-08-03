using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class UiGameOver : MonoBehaviour
{
    PlayerStats.Stats _stats;
    public TMP_Text score;
    public TMP_Text crates;
    public TMP_Text distance;
    public List<TMP_Text> highScoresText;
    void OnEnable()
    {
        _stats = GameManager.Instance.stats;
        score.text = "Score: " + _stats.score.ToString();
        crates.text = "Crates destroyed: " + _stats.destroyedCrates.ToString();
        distance.text = "Distance travelled: " + Mathf.RoundToInt(_stats.totalDistance).ToString();
        UpdateHighscoreText();
    }
    void UpdateHighscoreText()
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