using UnityEngine;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private SceneTransition sceneTransition;

    public void Start()
    {
        if (sceneTransition == null)
            sceneTransition = FindObjectOfType<SceneTransition>();
    }

    public void NewGame()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainAudio>().FadeOut();
        sceneTransition.FadeToScene("Backup");
    }

    public void ContinueGame()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainAudio>().FadeOut();
        sceneTransition.FadeToScene("Backup");
        Debug.Log("Todo");
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
