using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSettingsP2 : MonoBehaviour
{
    public void ChangeQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}