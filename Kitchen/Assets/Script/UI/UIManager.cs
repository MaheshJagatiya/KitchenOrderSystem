using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] ScoreController scoreController;

    public HUDView hud;
    public GameOverPanel gameOverPanel;
    public StartPanel startPanel;

    void Start()
    {
        gameController.OnGameOver += ShowGameOver;
        scoreController.OnScoreChanged += hud.UpdateScore;
        gameController.OnTimerChanged += hud.UpdateTimer;
    }

    void ShowGameOver()
    {
        gameOverPanel.Show();
    }

    public void StartGame()
    {
        startPanel.Hide();
        Time.timeScale = 1;
    }
}