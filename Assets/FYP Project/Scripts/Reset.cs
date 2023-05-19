using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    private Scene startingScene;

    private void Start()
    {
        // Store the starting scene
        startingScene = SceneManager.GetActiveScene();
    }

    public void ResetScene()
    {
        Fade.FadeChecker = false;  // skip fade
        Checker.objextive1 = false;
        Checker.saved = false;
        ObjectClicker.zoomedIn = false;
        Time.timeScale = 1f; // resume game
        SceneManager.LoadScene(startingScene.buildIndex, LoadSceneMode.Single); // reload

    }
}