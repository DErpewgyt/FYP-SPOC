using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject pauseMenuBtn;
    public GameObject quitPromptPanel;
    public GameObject menuPromptPanel;

    void Awake()
    {
        Cursor.visible = false;
        Resume();
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
        quitPromptPanel.SetActive(false);
        menuPromptPanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        //Cursor.lockState = CursorLockMode.None; // Unlock the mouse cursor
        Cursor.visible = false; // Show the mouse cursor
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseMenuBtn.SetActive(true);
        quitPromptPanel.SetActive(false);
        menuPromptPanel.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None; // Unlock the mouse cursor
        Cursor.visible = true; // Show the mouse cursor
    }

    public void SaveBtn()
    {
        Debug.Log("Saving");
    }

    public void LoadSave()
    {
        Debug.Log("Loading Save");
    }


    // --------------------------------------------------- Main Menu Controller------------------------------------------------
    public void MainMenu()
    {
        menuPromptPanel.SetActive(true);
    }

    public void ConfirmMainMenu(string JEREMYMainMenuScene)
    {
        SceneManager.LoadScene(JEREMYMainMenuScene);
    }

    public void CancelMainMenu()
    {
        menuPromptPanel.SetActive(false);
    }


    // --------------------------------------------------- Quit game Contol-----------------------------------------------------
    public void QuitGame()
    {
        quitPromptPanel.SetActive(true);
    }

    public void ConfirmQuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void CancelQuitGame()
    {
        quitPromptPanel.SetActive(false);
    }
}
