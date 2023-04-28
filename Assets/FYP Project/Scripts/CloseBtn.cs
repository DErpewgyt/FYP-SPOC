//#define LOG_TRACE_INFO
//#define LOG_EXTRA_INFO
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseBtn : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}