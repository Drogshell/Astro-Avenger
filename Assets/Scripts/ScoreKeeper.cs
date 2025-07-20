using System;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private static ScoreKeeper _instance;
    private int _score;
    
    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (_instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return _score;
    }

    public void UpdateScore(int score)
    {
        _score += score;
        Mathf.Clamp(_score, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        _score = 0;
    }
}
