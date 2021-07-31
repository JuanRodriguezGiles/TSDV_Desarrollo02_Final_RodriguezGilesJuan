using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviourSingletonPersistent<GameManager>
{
    [SerializeField] float _maxTimeSeconds;
    public static event Action<float> onTimeChange;
    public PlayerStats.Stats stats;
    float _time;
    IEnumerator Timer()
    {
        while (_time > 0)
        {
            _time -= Time.deltaTime;
            onTimeChange?.Invoke(_time);
            yield return null;
        }
        GameOver();
    }
    void GameOver()
    {
        stats = FindObjectOfType<PlayerStats>().stats;
        SceneManager.LoadScene("GameOver");
    }
    public void LoadMainMenuScene()
    {
        _time = _maxTimeSeconds;
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameplayScene()
    {
        SceneManager.LoadScene("Gameplay");
        _time = _maxTimeSeconds;
        StartCoroutine(Timer());
    }
    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }
}