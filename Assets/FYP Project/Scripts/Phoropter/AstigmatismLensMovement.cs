using UnityEngine;

public class AstigmatismLensMovement : MonoBehaviour
{
    public Animator LeftLensController;
    public Animator RightLensController;

    public bool LeftLensActive;
    public bool RightLensActive;

    private void Start()
    {
        LeftLensActive = false;
        RightLensActive = false;
    }

    public void LeftLensAnimate()
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
        }
    }

    public void RightLensAnimate()
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
        }
    }
}