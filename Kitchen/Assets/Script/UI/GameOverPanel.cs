using UnityEngine;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] GameObject root;
    [SerializeField] TextMeshProUGUI finalScoreText;

    [SerializeField] ScoreController scoreController;

    public void Show()
    {
        root.SetActive(true);

        finalScoreText.text = "Final Score: " + scoreController.Score;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}