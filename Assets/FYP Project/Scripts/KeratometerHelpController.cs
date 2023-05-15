using UnityEngine;
using UnityEngine.UI;

public class KeratometerHelpController : MonoBehaviour
{
    public GameObject helpImage;
    public GameObject blur;
    public Button helpButton;  // Add this line

    public void OnHelpButtonClick()
    {
        bool isHelpImageActive = !helpImage.activeInHierarchy;
        helpImage.SetActive(isHelpImageActive);
        blur.SetActive(isHelpImageActive);
        helpButton.gameObject.SetActive(!isHelpImageActive);  // Add this line
    }
}
