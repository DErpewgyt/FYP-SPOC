using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClinicReturn : MonoBehaviour
{
    public GameObject clinicReturn;

    public void ReturnToClinic()
    {
        clinicReturn.SetActive(true);
    }

    public void ConfirmClinic(string NEWgameScene)
    {
        SceneManager.LoadScene(NEWgameScene);
    }

    public void CancelClinic()
    {
        clinicReturn.SetActive(false);
    }
}
