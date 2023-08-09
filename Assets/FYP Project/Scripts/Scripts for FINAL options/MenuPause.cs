using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuPause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public bool isPaused;

    public GameObject pauseMenuUI;
    public GameObject pauseMenuBtn;
    public GameObject optionMenuUI;
    public GameObject quitPromptPanel;
    public GameObject menuPromptPanel;
    public GameObject Timers;
    public GameObject returnClinic;
    /*private ObjectClicker objectClicker;*/


/*    private void Start()
    {
        objectClicker = PMOClinker.instance.objectClicker;
    }*/


    void Update()
    {
        isPaused = GameIsPaused;
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
        if(ObjectClicker.zoomedIn == true)
        {
            ObjectClicker.ExitActive = false;
        }
        else
        {
            ObjectClicker.ExitActive = true;
        }
        pauseMenuUI.SetActive(false);
        pauseMenuBtn.SetActive(false);
        optionMenuUI.SetActive(false);
        quitPromptPanel.SetActive(false);
        menuPromptPanel.SetActive(false);
        Timers.SetActive(true);
        returnClinic.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        /*objectClicker.ExitIcon.SetActive(!objectClicker.zoomedIn);*/
    }

    void Pause()
    {
        ObjectClicker.ExitActive = false;
        pauseMenuUI.SetActive(true);
        pauseMenuBtn.SetActive(true);
        optionMenuUI.SetActive(false);
        quitPromptPanel.SetActive(false);
        menuPromptPanel.SetActive(false);
        Timers.SetActive(false);
        returnClinic.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
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
}
