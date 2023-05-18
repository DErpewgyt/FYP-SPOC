using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using StarterAssets; // Add this using directive

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject pauseMenuBtn;
    public GameObject optionMenuUI;
    public GameObject quitPromptPanel;
    public GameObject menuPromptPanel;

    private FirstPersonController firstPersonController; // Reference to the FirstPersonController script

    void Awake()
    {
        Cursor.visible = false;
        Resume();
    }

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
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
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;

        if (firstPersonController != null)
        {
            firstPersonController.enabled = true;
            firstPersonController.CameraRotation(); // Call the CameraRotation() function
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseMenuBtn.SetActive(true);
        optionMenuUI.SetActive(false);
        quitPromptPanel.SetActive(false);
        menuPromptPanel.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (firstPersonController != null)
        {
            firstPersonController.enabled = false;
        }
    }

    public void OptionBtn()
    {
        optionMenuUI.SetActive(true);
        pauseMenuBtn.SetActive(false);
    }

    public void OptionClose()
    {
        optionMenuUI.SetActive(false);
        pauseMenuBtn.SetActive(true);
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

    // Assign the FirstPersonController script
    public void AssignFirstPersonController(FirstPersonController controller)
    {
        firstPersonController = controller;
    }
}
