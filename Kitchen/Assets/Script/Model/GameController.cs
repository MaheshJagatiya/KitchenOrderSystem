using UnityEngine;
using System;
using System.Collections;
public class GameController : MonoBehaviour 
{
    public float gameTime = 180f;

    public event Action<float> OnTimerChanged;
    public event Action OnGameOver;

    void Start()
    {
        StartCoroutine(GameTimer());
    }

    IEnumerator GameTimer()
    {
        while (gameTime > 0)
        {
            yield return new WaitForSeconds(1f); 

            gameTime -= 1f;

            OnTimerChanged?.Invoke(gameTime);
        }

        gameTime = 0;
        OnTimerChanged?.Invoke(gameTime);

        OnGameOver?.Invoke();

        Time.timeScale = 0;
    }
}
