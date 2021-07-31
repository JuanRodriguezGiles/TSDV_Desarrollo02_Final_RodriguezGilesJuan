using TMPro;
using UnityEngine;
public class UiGameOver : MonoBehaviour
{
    PlayerStats.Stats _stats;
    public TMP_Text score;
    public TMP_Text crates;
    public TMP_Text distance;

    void OnEnable()
    {
        _stats = GameManager.Instance.stats;
        score.text = "Score: " + _stats.score.ToString();
        crates.text = "Crates destroyed: " + _stats.destroyedCrates.ToString();
        distance.text = "Distance travelled: " + Mathf.RoundToInt(_stats.totalDistance).ToString();
    }

    public void LoadMainMenuScene()
    {
        GameManager.Instance.LoadMainMenuScene();
    }
}