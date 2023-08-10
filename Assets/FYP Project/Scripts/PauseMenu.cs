using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using StarterAssets;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject pauseMenuBtn;
    public GameObject optionMenuUI;
    public GameObject quitPromptPanel;
    public GameObject menuPromptPanel;
    public GameObject WASDquest;
    public GameObject mouseQuest;
    public GameObject examQuest;
    public GameObject chooseQuest;
    public GameObject canvasFader;
    public GameObject VideoPlayer;
    public GameObject VideoPlayer2;
    private FirstPersonController firstPersonController;

    void Awake()
    {
        Cursor.visible = false;
    }

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseMenuBtn.SetActive(false);
        optionMenuUI.SetActive(false);
        quitPromptPanel.SetActive(false);
        menuPromptPanel.SetActive(false);
        WASDquest.SetActive(true);
        examQuest.SetActive(true);
        /*mouseQuest.SetActive(true);
        chooseQuest.SetActive(true);*/
        canvasFader.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        VideoPlayer.SetActive(false);
        VideoPlayer2.SetActive(false);

        if (firstPersonController != null)
        {
            firstPersonController.enabled = true;
            firstPersonController.CameraRotation();
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseMenuBtn.SetActive(true);
        optionMenuUI.SetActive(false);
        quitPromptPanel.SetActive(false);
        menuPromptPanel.SetActive(false);
        WASDquest.SetActive(false);
        examQuest.SetActive(false);
        mouseQuest.SetActive(false);
        chooseQuest.SetActive(false);
        canvasFader.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        VideoPlayer.SetActive(false);
        VideoPlayer2.SetActive(false);

        if (firstPersonController != null)
        {
            firstPersonController.enabled = false;
        }
    }

    public void OptionBtn()
    {
        optionMenuUI.SetActive(true);
        pauseMenuBtn.SetActive(false);
        VideoPlayer.SetActive(true);
        VideoPlayer2.SetActive(true);
    }

    public void OptionClose()
    {
        optionMenuUI.SetActive(false);
        pauseMenuBtn.SetActive(true);
        VideoPlayer.SetActive(false);
        VideoPlayer2.SetActive(false);
    }

    // --------------------------------------------------- Main Menu Controller-------------------------------------------------
    public void MainMenu()
    {
        menuPromptPanel.SetActive(true);
        pauseMenuBtn.SetActive(false);
    }

    public void ConfirmMainMenu(string JEREMYMainMenuScene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(JEREMYMainMenuScene);
    }

    public void CancelMainMenu()
    {
        menuPromptPanel.SetActive(false);
        pauseMenuBtn.SetActive(true);
    }


    // --------------------------------------------------- Quit game Contol-----------------------------------------------------
    public void QuitGame()
    {
        quitPromptPanel.SetActive(true);
        pauseMenuBtn.SetActive(false);
    }

    public void ConfirmQuitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void CancelQuitGame()
    {
        quitPromptPanel.SetActive(false);
        pauseMenuBtn.SetActive(true);
    }

    public void AssignFirstPersonController(FirstPersonController controller)
    {
        firstPersonController = controller;
    }
}
