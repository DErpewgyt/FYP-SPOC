using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    private Scene startingScene;
    public GameObject clicker;
    public GameObject fader;
    public CanvasGroup canvasGroup;

    private void Start()
    {
        // Store the starting scene
        startingScene = SceneManager.GetActiveScene();
    }

    public void ResetScene()
    {
        Fade.ShouldFadeIn = false;  // skip fade
        SceneManager.LoadScene(startingScene.buildIndex, LoadSceneMode.Single);
    }
}