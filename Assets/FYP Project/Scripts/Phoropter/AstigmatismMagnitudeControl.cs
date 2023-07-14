using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AstigmatismMagnitudeControl : MonoBehaviour
{

    public TextMeshProUGUI LeftValue;
    public TextMeshProUGUI RightValue;

    public TextMeshProUGUI TopLeftValue;
    public TextMeshProUGUI TopRightValue;

    public GameObject TopLeftobject;
    public GameObject TopRightobject;

    public GameObject leftMagBtn; //check patients left side
    public GameObject rightMagBtn; //check patients right side

    public float rotationSpeed = 10f;
    public GameObject LeftAstigmatismMagKnob;
    public GameObject RightAstigmatismMagKnob;

    public float AstigMagLeft;
    public float AstigMagRight;

    public bool AstigMagLeftBool;
    public bool AstigMagRightBool;

    public bool isLeftChanged = false;
    public bool isRightChanged = false;

    public Animator LeftAnimator;
    public Animator RightAnimator;

    public LensFlip lensFlip;
    public AIVoiceChecker Checker;
    // Start is called before the first frame update
    void Start()
    {
        AstigMagRight = 0;
        AstigMagLeft = 0;

        AstigMagLeftBool = false;
        AstigMagRightBool = false;

        TopLeftobject.SetActive(false);
        TopRightobject.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (AstigMagLeftBool)
        {
            float rotationAmount = Input.mouseScrollDelta.y * rotationSpeed * Time.deltaTime;
            if (lensFlip.leftLens)
            {
                LeftAnimator.SetBool("IsRotatedLeft", true);
            }

            TopLeftobject.SetActive(true);
            TopRightobject.SetActive(false);
            if (scrollInput != 0f)
            {
                RotateObject(LeftAstigmatismMagKnob, -rotationAmount, AstigMagLeft);
                AstigMagLeft += Mathf.Sign(scrollInput) * -0.25f;
                AstigMagLeft = Mathf.Clamp(AstigMagLeft, -6.00f, 0.00f);
                UpdateValue(LeftValue, AstigMagLeft, TopLeftValue);
                isLeftChanged = true;
            }

            if (lensFlip.leftFlippedOnce && lensFlip.leftFlippedTwice && isLeftChanged && lensFlip.leftLens && Checker.isRightSideAstigAxisComplete)
            {
                rightMagBtn.SetActive(true);
            }
        } else
        {
            LeftAnimator.SetBool("IsRotatedLeft", false);
        }


        if (AstigMagRightBool)
        {
            float rotationAmount = Input.mouseScrollDelta.y * rotationSpeed * Time.deltaTime;
            if (lensFlip.rightLens)
            {
                RightAnimator.SetBool("IsRotatedRight", true);
            }


            TopLeftobject.SetActive(false);
            TopRightobject.SetActive(true);
            if (scrollInput != 0f)
            {
                RotateObject(RightAstigmatismMagKnob, -rotationAmount, AstigMagRight);
                AstigMagRight += Mathf.Sign(scrollInput) * -0.25f;
                AstigMagRight = Mathf.Clamp(AstigMagRight, -6.00f, 0.00f);
                UpdateValue(RightValue, AstigMagRight, TopRightValue);
                isRightChanged = true;
            }

            if(lensFlip.rightFlippedOnce && lensFlip.rightFlippedTwice && isRightChanged && lensFlip.rightLens && Checker.isLeftSideAstigAxisComplete)
            {
                leftMagBtn.SetActive(true);
            }
        } 
        else
        {
            RightAnimator.SetBool("IsRotatedRight", false);
        }

        if(!AstigMagRightBool && !AstigMagLeftBool)
        {
            TopLeftobject.SetActive(false);
            TopRightobject.SetActive(false);
        }
    }

    private void RotateObject(GameObject obj, float rotationAmount, float astigvalue)
    {
        if (astigvalue < 0f && astigvalue > -6f)
        {
            // Get the object's center position
            Vector3 center = obj.GetComponent<Renderer>().bounds.center;

            // Calculate the rotation axis as the object's up vector
            Vector3 rotationAxis = obj.transform.up;

            // Rotate the object around its center for the Y-axis
            obj.transform.RotateAround(center, rotationAxis, rotationAmount);
        }
            return;
    }

    private void UpdateValue(TextMeshProUGUI valueText, float LSvalues, TextMeshProUGUI valueText2)
    {
        float displayValue = LSvalues * -1f;
        string formattedValue = displayValue.ToString("F2").Replace("0.", ".");
        valueText.text = formattedValue;
        valueText.color = Color.red;
        valueText2.text = formattedValue;
        valueText2.color = Color.red;
    }
}
