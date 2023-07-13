using UnityEngine;

public class LensFlip : MonoBehaviour
{
    public bool leftLens;
    public bool rightLens;
    public bool leftLensFlipped;
    public bool rightLensFlipped;

    public bool leftFlippedOnce;
    public bool leftFlippedTwice;

    public bool rightFlippedOnce;
    public bool rightFlippedTwice;

    public GameObject LeftFlipBtn;
    public GameObject RightFlipBtn;

    public Animator LeftLensFlipController;
    public Animator RightLensFlipController;

    // Start is called before the first frame update
    private void Start()
    {
        leftLens = false;
        rightLens = false;
        leftLensFlipped = false;
        rightLensFlipped = false;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void leftFlip()
    {
        if (leftLens == false)
        {
            leftLens = true;
            LeftFlipBtn.SetActive(true);

        }
        else if (leftLens == true)
        {
            leftLens = false;
            LeftFlipBtn.SetActive(false);

        }
    }

    public void rightFlip()
    {
        if (rightLens == false)
        {
            rightLens = true;
            RightFlipBtn.SetActive(true);
        }
        else if (rightLens == true)
        {
            rightLens = false;
            RightFlipBtn.SetActive(false);
        }
    }

    public void flipLeftLens()
    {
        if (leftLensFlipped == false)
        {
            print("1");
            LeftLensFlipController.SetBool("Flipped", true);
            leftLensFlipped = true;
            leftFlippedOnce = true;
        }
        else if (leftLensFlipped == true)
        {
            print("2");
            LeftLensFlipController.SetBool("Flipped", false);
            leftLensFlipped = false;
            leftFlippedTwice = true;
        }
    }

    public void flipRightLens()
    {
        if (rightLensFlipped == false)
        {
            RightLensFlipController.SetBool("Flipped", true);
            rightLensFlipped = true;
        }
        else if (rightLensFlipped == true)
        {
            RightLensFlipController.SetBool("Flipped", false);
            rightLensFlipped = false;
        }
    }
}