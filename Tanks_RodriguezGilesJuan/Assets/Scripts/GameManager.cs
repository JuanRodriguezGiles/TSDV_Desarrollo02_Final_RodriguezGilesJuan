using System;
using System.Collections;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    [SerializeField] float _maxTimeSeconds;
    public static event Action<float> onTimeChange;
    float _time;
    void Start()
    {
        _time = _maxTimeSeconds;
        StartCoroutine(Timer());
    }
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

    }
}