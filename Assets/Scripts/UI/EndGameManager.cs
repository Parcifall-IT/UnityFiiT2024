using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] private GameObject end;

    void Start()
    {
        end.SetActive(false);
    }

    public void ShowEndGameScreen()
    {
        end.SetActive(true);
    }

    public void StartOver()
    {
        SceneManager.LoadScene("StartMenu");
    }
}