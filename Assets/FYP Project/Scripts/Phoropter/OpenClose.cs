using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenClose : MonoBehaviour
{
    public Animator LeftCoverPivotAnimation;
    public Animator RightCoverPivotAnimation;

    public Animator LeftCoverCloseAnimation;
    public Animator RightCoverCloseAnimation;

    private bool isLeftActive;
    private bool isRightActive;

    private void Start()
    {
        isLeftActive = false;
        isRightActive = false;

        LeftCoverPivotAnimation.SetBool("CoverOpenClose", false);
        LeftCoverCloseAnimation.SetBool("OpenClose", false);

        RightCoverPivotAnimation.SetBool("CoverOpenClose", false);
        RightCoverCloseAnimation.SetBool("OpenClose", false);
    }

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
                    isLeftActive = !isLeftActive;
                    LeftCoverPivotAnimation.SetBool("CoverOpenClose", isLeftActive);
                    LeftCoverCloseAnimation.SetBool("OpenClose", isLeftActive);
                }
                else if (hit.collider.gameObject.tag == "OpenAndCloseKnobRight")
                {
                    isRightActive = !isRightActive;
                    RightCoverPivotAnimation.SetBool("CoverOpenClose", isRightActive);
                    RightCoverCloseAnimation.SetBool("OpenClose", isRightActive);
                }
            }
        }
    }
}

