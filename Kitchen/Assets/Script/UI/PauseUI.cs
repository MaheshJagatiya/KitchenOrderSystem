using UnityEngine;
using UnityEngine.UI;
public class PauseUI : MonoBehaviour
{
    [SerializeField] Button pauseButton;
    [SerializeField] Button playButton;

    void Start()
    {
        // Initial state    
        pauseButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;

        pauseButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;

        pauseButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);
    }
}