using System;
using UnityEngine;

public class ScoreController : MonoBehaviour 
{
    public int Score { get; private set; }

    public event Action<int> OnScoreChanged;

   
    public void AddScore(int value)
    {
        Score += value;

        int high = PlayerPrefs.GetInt("HighScore", 0);

        if (Score > high)
            PlayerPrefs.SetInt("HighScore", Score);

        OnScoreChanged?.Invoke(Score);
    }
}
