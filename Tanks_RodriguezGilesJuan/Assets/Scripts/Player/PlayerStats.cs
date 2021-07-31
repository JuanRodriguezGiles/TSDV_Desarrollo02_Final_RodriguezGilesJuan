using System;
using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    int _score;
    public static event Action<int> onScoreChange;
    void OnEnable()
    {
        Crate.onCrateDestroyed += AddScore;
    }
    void OnDisable()
    {
        Crate.onCrateDestroyed -= AddScore;
    }
    void AddScore()
    {
        _score++;
        onScoreChange?.Invoke(_score);
    }
}