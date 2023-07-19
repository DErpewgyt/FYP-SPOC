using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickAwayControllerZoomIn : MonoBehaviour
{
    public GameObject guide;
    public GameObject blur;
    public Button helpButton;
   

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
                
                    helpButton.gameObject.SetActive(true);
                }
            }
            else
            {
                guide.SetActive(false);
                blur.SetActive(false);
               
                helpButton.gameObject.SetActive(true);
            }
        }
    }
}
