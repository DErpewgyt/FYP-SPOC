using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickAwayController2 : MonoBehaviour
{
    public Canvas guide1;
    public Canvas guide2;
    public Canvas guide3;
    public Canvas guide4;
    public Canvas guide5;
    public Canvas guide6;
    public GameObject blur;
    public Canvas leftArrow;
    public Canvas rightArrow;
    public Button helpButton;
    public Canvas Readings;
    public Canvas Resets;
    public Button GraphicButton;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject != guide1)
                {
                    guide1.gameObject.SetActive(false);
                    guide2.gameObject.SetActive(false);
                    guide3.gameObject.SetActive(false);
                    guide4.gameObject.SetActive(false);
                    guide5.gameObject.SetActive(false);
                    guide6.gameObject.SetActive(false);
                    blur.SetActive(false);
                    leftArrow.gameObject.SetActive(false);
                    rightArrow.gameObject.SetActive(false);
                    helpButton.gameObject.SetActive(true);
                    Readings.gameObject.SetActive(true);
                    Resets.gameObject.SetActive(true);
                    GraphicButton.gameObject.SetActive(true);
                }
            }
            else
            {
                    guide1.gameObject.SetActive(false);
                    guide2.gameObject.SetActive(false);
                    guide3.gameObject.SetActive(false);
                    guide4.gameObject.SetActive(false);
                    guide5.gameObject.SetActive(false);
                    guide6.gameObject.SetActive(false);
                blur.SetActive(false);
                leftArrow.gameObject.SetActive(false);
                rightArrow.gameObject.SetActive(false);
                helpButton.gameObject.SetActive(true);
                Readings.gameObject.SetActive(true);
                Resets.gameObject.SetActive(true);
                GraphicButton.gameObject.SetActive(true);
            }
        }
    }
}
