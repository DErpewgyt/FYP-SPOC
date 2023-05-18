using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggles : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Toggle vsyncToggle;

    // Start is called before the first frame update
    void Start()
    {
        fullscreenToggle.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncToggle.isOn = false;
        }
        else
        {
            vsyncToggle.isOn = true;
        }

        // Add listener to the fullscreen toggle
        fullscreenToggle.onValueChanged.AddListener(OnFullscreenToggle);
    }

    // Function to handle fullscreen toggle
    void OnFullscreenToggle(bool value)
    {
        Screen.fullScreen = value;
    }
}
