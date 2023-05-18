using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VideoSettingsP2 : MonoBehaviour
{
    public TMP_Dropdown qualityDropdown;

    private void Start()
    {
        if (PlayerPrefs.HasKey("QualityLevel"))
        {
            int qualityIndex = PlayerPrefs.GetInt("QualityLevel");
            QualitySettings.SetQualityLevel(qualityIndex);
            qualityDropdown.value = qualityIndex;
            qualityDropdown.RefreshShownValue();
        }
    }

    public void ChangeQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("QualityLevel", qualityIndex);
        qualityDropdown.value = qualityIndex;
    }
}
