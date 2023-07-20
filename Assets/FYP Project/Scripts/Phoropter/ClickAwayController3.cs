using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickAwayController3 : MonoBehaviour
{
    public Canvas graphic1;
    public Canvas graphic2;
    public Canvas graphic3;
    public GameObject blur;
    public Button helpButton;
    public Canvas Readings;
    public Canvas Resets;
    public Canvas Guide;
   


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject != graphic1)
                {
                    graphic1.gameObject.SetActive(false);
                    graphic2.gameObject.SetActive(false);
                    graphic3.gameObject.SetActive(false);
                    blur.SetActive(false);
                    helpButton.gameObject.SetActive(true);
                    Readings.gameObject.SetActive(true);
                    Resets.gameObject.SetActive(true);
                    Guide.gameObject.SetActive(true);
                  
                }
            }
            else
            {
                    graphic1.gameObject.SetActive(false);
                    graphic2.gameObject.SetActive(false);
                    graphic3.gameObject.SetActive(false);
                Guide.gameObject.SetActive(true); 
                blur.SetActive(false);
                helpButton.gameObject.SetActive(true);
                Readings.gameObject.SetActive(true);
                Resets.gameObject.SetActive(true);
                
            }
        }
    }
}
