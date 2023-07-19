using UnityEngine;
using UnityEngine.UI;

public class PhoropterGraphicController : MonoBehaviour
{
    public Canvas graphic1;
    public Canvas graphic2;
    public Canvas graphic3;
    public Canvas Readings;
    public Canvas Resets;
    public GameObject blur;
    public Button helpButton;
    public Canvas Guide;
    public Button ObjectiveChecker;


    public void OnHelpButtonClick()
    {
        bool isHelpImageActive = !graphic1.gameObject.activeInHierarchy;
        
        graphic1.gameObject.SetActive(isHelpImageActive);
        graphic2.gameObject.SetActive(isHelpImageActive);
        graphic3.gameObject.SetActive(isHelpImageActive);
        blur.SetActive(isHelpImageActive);
        helpButton.gameObject.SetActive(!isHelpImageActive);
        Readings.gameObject.SetActive(!isHelpImageActive);
        Resets.gameObject.SetActive(!isHelpImageActive);
        Guide.gameObject.SetActive(!isHelpImageActive);
        ObjectiveChecker.gameObject.SetActive(!isHelpImageActive);
       
    }
}
