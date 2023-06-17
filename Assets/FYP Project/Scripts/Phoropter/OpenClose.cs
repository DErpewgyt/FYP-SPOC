using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenClose : MonoBehaviour
{
    public GameObject LeftCover;
    public GameObject RightCover;

    private bool isLeftActive = false;
    private bool isRightActive = false;

    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                print("clicked");
                if (hit.collider.gameObject.tag == "OpenAndCloseKnobLeft")
                {
                    Debug.Log("1 check");
                    if (isLeftActive == true)
                    {
                        isLeftActive = false;
                    }
                    else
                    {
                        isLeftActive = true;
                    }
                    //isActive = !isActive;
                    LeftCover.SetActive(isLeftActive);
                }
            }
        }

        Ray rayRight = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(rayRight, out RaycastHit hitRight))
        {
            if (Input.GetMouseButtonDown(0))
            {
                print("clicked");
                if (hit.collider.gameObject.tag == "OpenAndCloseKnobRight")
                {
                    Debug.Log("1 check");
                    if (isRightActive == true)
                    {
                        isRightActive = false;
                    }
                    else
                    {
                        isRightActive = true;
                    }
                    //isActive = !isActive;
                    RightCover.SetActive(isRightActive);
                }
            }
        }

    }
}
