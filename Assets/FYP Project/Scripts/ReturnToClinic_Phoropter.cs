using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToClinic_Phoropter : MonoBehaviour
{
    public GameObject clinicReturn;
    public GameObject disableScripts;

    public void ReturnToClinic()
    {
        clinicReturn.SetActive(true);
        disableScripts.SetActive(false);
    }

    public void ConfirmClinic(string JeremyNewGameScene)
    {
        SceneManager.LoadScene(JeremyNewGameScene);
        disableScripts.SetActive(true);
    }

    public void CancelClinic()
    {
        clinicReturn.SetActive(false);
        disableScripts.SetActive(true);
    }
}
