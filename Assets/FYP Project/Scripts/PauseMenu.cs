using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject quitPromptPanel;
    public GameObject menuPromptPanel;

    // Update is called once per frame
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
        quitPromptPanel.SetActive(false);
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

    public void ConfirmMainMenu()
    {
        Debug.Log("Loading Main Menu...");
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
        Debug.Log("Quitting Game...");
    }

    public void CancelQuitGame()
    {
        quitPromptPanel.SetActive(false);
    }
}