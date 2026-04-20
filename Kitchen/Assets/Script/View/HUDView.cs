using UnityEngine;
using TMPro;

public class HUDView : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI timerText;

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
       // FloatingTextSpawner.Instance.Spawn("Score: " + score);
        int high = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "HighScore: " + high;
    }

    public void UpdateTimer(float t)
    {
        timerText.text = "Time: " + Mathf.CeilToInt(t);
    }
}