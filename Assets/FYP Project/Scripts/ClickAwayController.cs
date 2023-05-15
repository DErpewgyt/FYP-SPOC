using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;  // Add this line

public class ClickAwayController : MonoBehaviour
{
    public GameObject helpImage;
    public GameObject blur;
    public Button helpButton;  // Add this line

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject != helpImage)
                {
                    helpImage.SetActive(false);
                    blur.SetActive(false);
                    helpButton.gameObject.SetActive(true);  // Add this line
                }
            }
            else
            {
                helpImage.SetActive(false);
                blur.SetActive(false);
                helpButton.gameObject.SetActive(true);  // Add this line
            }
        }
    }
}
