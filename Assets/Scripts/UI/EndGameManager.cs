using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public GameObject endGameCanvas;

    void Start()
    {
        if (endGameCanvas != null)
            endGameCanvas.SetActive(false);
    }

    public void ShowEndGameScreen()
    {
        if (endGameCanvas != null)
            endGameCanvas.SetActive(true);
    }

    public void StartOver()
    {
        SceneManager.LoadScene("StartMenu");
    }
}