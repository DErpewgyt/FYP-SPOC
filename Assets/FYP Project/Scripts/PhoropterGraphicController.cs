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

    public bool one = false;
    public bool two = false;
    public bool three = false;

    public void OnHelpButtonClick()
    {
        if (one == true)
        {
            graphic1.gameObject.SetActive(true);
        }
        if (two == true)
        {
            graphic2.gameObject.SetActive(true);
        }
        if (three == true)
        {
            graphic3.gameObject.SetActive(true);
        }
        blur.SetActive(true);
        helpButton.gameObject.SetActive(!true);
        Readings.gameObject.SetActive(!true);
        Resets.gameObject.SetActive(!true);
        Guide.gameObject.SetActive(!true);

    }
}
