using UnityEngine;
using UnityEngine.UI;

public class PhoropterHelpController : MonoBehaviour
{
    public Canvas guideCanvas;
    public Canvas leftArrow;
    public Canvas rightArrow;
    public Canvas Readings;
    public Canvas Resets;
    public GameObject blur;
    public Button helpButton;
    public Button GraphicButton;
 


    public void OnHelpButtonClick()
    {
        bool isHelpImageActive = !guideCanvas.gameObject.activeInHierarchy;
        
        guideCanvas.gameObject.SetActive(isHelpImageActive);
        leftArrow.gameObject.SetActive(isHelpImageActive);
        rightArrow.gameObject.SetActive(isHelpImageActive);
        blur.SetActive(isHelpImageActive);
        helpButton.gameObject.SetActive(!isHelpImageActive);
        Readings.gameObject.SetActive(!isHelpImageActive);
        Resets.gameObject.SetActive(!isHelpImageActive);
        GraphicButton.gameObject.SetActive(!isHelpImageActive);
       
       
    }
}
