using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator animator;
    public CanvasGroup fadeCanvasGroup;
    private string sceneToLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        if (fadeCanvasGroup == null)
            fadeCanvasGroup = GetComponent<CanvasGroup>();
        fadeCanvasGroup.blocksRaycasts = false;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    public void FadeToScene(string sceneName)
    {
        sceneToLoad = sceneName;
        fadeCanvasGroup.blocksRaycasts = true;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
        // fadeCanvasGroup.blocksRaycasts = false;
        // animator.SetTrigger("FadeIn");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == sceneToLoad)
        {
            fadeCanvasGroup.blocksRaycasts = false;
            animator.SetTrigger("FadeIn");
        }
    }
}
