using UnityEngine;

public class StartPanel : MonoBehaviour
{
    public GameObject root;

    void Start()
    {
        Time.timeScale = 0;
        root.SetActive(true);
    }

    public void StartGame()
    {
        root.SetActive(false);
        Time.timeScale = 1;
    }
    public void Hide()
    {
        root.SetActive(false);
    }
}