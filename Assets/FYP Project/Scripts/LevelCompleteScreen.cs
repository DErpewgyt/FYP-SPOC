using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteScreen : MonoBehaviour
{
    private Scene startingScene;

    public string sceneToLoad; // scene to transition to

    private void Start()
    {
        // Store the starting scene and objects
        startingScene = SceneManager.GetActiveScene();
    }

    public void retry()
    {
        Fade.ShouldFadeIn = false;  // skip fade
        Time.timeScale = 1f; // resume time flow
        SceneManager.LoadScene(startingScene.buildIndex, LoadSceneMode.Single); // reload
        /*print("retry");*/
    }

    public void mainMenu()
    {
        Time.timeScale = 1f; // resume time flow
        SceneManager.LoadScene(sceneToLoad); // go to main menu
        /*print("mainMenu");*/
    }
}