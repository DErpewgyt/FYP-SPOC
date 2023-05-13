using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    private Scene startingScene;
    public GameObject clicker;
    public GameObject fader;
    public CanvasGroup canvasGroup;
    public Fade fadeScript;

    private void Start()
    {
        // Store the starting scene and objects
        startingScene = SceneManager.GetActiveScene();
    }

    public void ResetScene()
    {
        Fade.ShouldFadeIn = false;  // Tell the Fade script to not do the fade animation
        SceneManager.LoadScene(startingScene.buildIndex, LoadSceneMode.Single);
    }
}