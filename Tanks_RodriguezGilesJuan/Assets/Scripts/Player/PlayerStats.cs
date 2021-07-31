using System;
using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    public struct Stats
    {
        public int score;
        public int destroyedCrates;
        public float totalDistance;
    }
    public Stats stats;
    Vector3 _lastPosition;
    public static event Action<int> onScoreChange;
    void OnEnable()
    {
        Crate.onCrateDestroyed += AddScore;
    }
    void OnDisable()
    {
        Crate.onCrateDestroyed -= AddScore;
    }
    void Start()
    {
        _lastPosition = transform.position;
    }
    void Update()
    {
        if (transform.position != _lastPosition)
            MeasureDistance();
    }
    void AddScore()
    {
        stats.score += 5;
        stats.destroyedCrates++;
        onScoreChange?.Invoke(stats.score);
    }
    void MeasureDistance()
    {
        float distance = Vector3.Distance(_lastPosition, transform.position);
        stats.totalDistance += distance;
        _lastPosition = transform.position;
    }
}