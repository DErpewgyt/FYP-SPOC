using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteScreen : MonoBehaviour
{
    public Fade fadeScript;
    private Scene startingScene;
    public string sceneToLoad;// scene to transition to
    public GameObject EndBtn;

    // Start is called before the first frame update
    void Start()
    {
        // Store the starting scene and objects
        startingScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void retry()
    {
        Fade.ShouldFadeIn = false;  // Tell the Fade script to not do the fade animation
        Time.timeScale = 1f;
        SceneManager.LoadScene(startingScene.buildIndex, LoadSceneMode.Single);
        print("retry");
    }

    public void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneToLoad);
        print("mainMenu");
    }
}
