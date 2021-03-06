using TMPro;
using UnityEngine;
public class UiGameplay : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text timeText;
    void OnEnable()
    {
        GameManager.onTimeChange += UpdateTimer;
        PlayerStats.onScoreChange += UpdateScore;
    }
    void OnDisable()
    {
        GameManager.onTimeChange -= UpdateTimer;
        PlayerStats.onScoreChange -= UpdateScore;
    }
    void UpdateTimer(float time)
    {
        timeText.text = Mathf.RoundToInt(time).ToString();
    }
    void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void LoadMainMenuScene()
    {
        GameManager.Instance.LoadMainMenuScene();
    }
    public void SaveGame()
    {
        SaveManager.Instance.Save();
    }
}