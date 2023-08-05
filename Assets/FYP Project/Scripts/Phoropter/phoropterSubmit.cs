using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phoropterSubmit : MonoBehaviour
{
    public GameObject completeScreen;
    public GameObject endBtns;
    public Button resetBtn;
    public Button submitBtn;

    public void activateCompleteScreen()
    {
        completeScreen.SetActive(true);
        endBtns.SetActive(true);
        disableButtons();
    }

    public void disableButtons()
    {
        resetBtn.interactable = false;
        submitBtn.interactable = false;
    }
}
