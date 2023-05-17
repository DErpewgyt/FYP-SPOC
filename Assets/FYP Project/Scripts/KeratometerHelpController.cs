using UnityEngine;
using UnityEngine.UI;

public class KeratometerHelpController : MonoBehaviour
{
    public GameObject guide;
    public GameObject blur;
    public Button helpButton;
    public GameObject clipboard;

    public void OnHelpButtonClick()
    {
        bool isHelpImageActive = !guide.activeInHierarchy;
        guide.SetActive(isHelpImageActive);
        blur.SetActive(isHelpImageActive);
        helpButton.gameObject.SetActive(!isHelpImageActive);
        //helpButton.SetActive(false);
        clipboard.gameObject.SetActive(!isHelpImageActive);
    }
}
