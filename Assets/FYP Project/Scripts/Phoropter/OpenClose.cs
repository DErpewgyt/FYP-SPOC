using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenClose : MonoBehaviour
{
    public GameObject LeftCover;
    public GameObject RightCover;

    public Animator LeftCoverCloseAnimation;
    public Animator RightCoverCloseAnimation;

    private bool isLeftActive;
    private bool isRightActive;

    private void Start()
    {
        isLeftActive = false;
        isRightActive = false;

        bool isLeftCoverOpen = LeftCover.activeSelf;

        LeftCoverCloseAnimation.SetBool("OpenClose", isLeftCoverOpen);

        bool isRightCoverOpen = RightCover.activeSelf;

        RightCoverCloseAnimation.SetBool("OpenClose", isRightCoverOpen);
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
                    LeftCover.SetActive(isLeftActive);

                    LeftCoverCloseAnimation.SetBool("OpenClose", isLeftActive);
                }
                else if (hit.collider.gameObject.tag == "OpenAndCloseKnobRight")
                {
                    isRightActive = !isRightActive;
                    RightCover.SetActive(isRightActive);

                    RightCoverCloseAnimation.SetBool("OpenClose", isRightActive);
                }
            }
        }
    }
}
