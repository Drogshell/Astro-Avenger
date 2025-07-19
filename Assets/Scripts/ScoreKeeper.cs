using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int _score;


    public int GetScore()
    {
        return _score;
    }

    public void UpdateScore(int score)
    {
        _score += score;
        Mathf.Clamp(score, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        _score = 0;
    }
}
