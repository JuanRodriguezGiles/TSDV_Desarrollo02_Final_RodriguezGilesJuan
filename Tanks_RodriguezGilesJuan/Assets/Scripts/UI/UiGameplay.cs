using TMPro;
using UnityEngine;
public class UiGameplay : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text timeText;
    void OnEnable()
    {
        GameManager.onTimeChange += UpdateTimer;
    }
    void OnDisable()
    {
        GameManager.onTimeChange -= UpdateTimer;
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
}