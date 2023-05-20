using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickAwayController : MonoBehaviour
{
    public GameObject guide;
    public GameObject blur;
    public Button helpButton;
    public GameObject clipboard;
    public GameObject returnClinic;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject != guide)
                {
                    guide.SetActive(false);
                    blur.SetActive(false);
                    clipboard.SetActive(true);
                    returnClinic.SetActive(true);
                    helpButton.gameObject.SetActive(true);
                }
            }
            else
            {
                guide.SetActive(false);
                blur.SetActive(false);
                clipboard.SetActive(true);
                returnClinic.SetActive(true);
                helpButton.gameObject.SetActive(true);
            }
        }
    }
}
