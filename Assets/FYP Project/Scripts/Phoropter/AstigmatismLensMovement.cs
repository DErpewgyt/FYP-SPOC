using UnityEngine;

public class AstigmatismLensMovement : MonoBehaviour
{
    public AIVoiceChecker checker;

    public Animator LeftLensController;
    public Animator RightLensController;

    public bool isLeftJccFlippedBack = false; // players left
    public bool isRightJccFlippedBack = false; // players right

    public bool LeftLensActive;
    public bool RightLensActive;

    private void Start()
    {
        LeftLensActive = false;
        RightLensActive = false;
    }

    public void LeftLensAnimate() // players left
    {
        if (LeftLensActive == false)
        {
            LeftLensController.SetBool("Lens", true);
            LeftLensActive = true;
        }
        else
        {
            LeftLensController.SetBool("Lens", false);
            LeftLensActive = false;
            if (checker.isRightSideAstigMagComplete == true)
            {
                checker.rightJcc.enabled = false;
                checker.rightLsMesh.enabled = true;
                checker.GraphicController.two = false;
                checker.GraphicController.three = true;
                isLeftJccFlippedBack = true;
            }
        }
    }

    public void RightLensAnimate() // players right
    {
        if (RightLensActive == false)
        {
            RightLensController.SetBool("Lens", true);
            RightLensActive = true;
        }
        else
        {
            RightLensController.SetBool("Lens", false);
            RightLensActive = false;
            if (checker.isLeftSideAstigMagComplete)
            {
                checker.leftJcc.enabled = false;
                checker.leftLsMesh.enabled = true;
                checker.GraphicController.two = false;
                checker.GraphicController.three = true;
                isRightJccFlippedBack = true;
            }
        }
    }
}