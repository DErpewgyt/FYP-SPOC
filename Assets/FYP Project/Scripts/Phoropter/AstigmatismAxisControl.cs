using TMPro;
using UnityEngine;

public class AstigmatismAxisControl : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public GameObject AstigmatismLensLeftFrame;
    public GameObject AstigmatismMiddleLensLeft;
    public GameObject AstigmatismLeftKnob;

    public GameObject AstigmatismLensRightFrame;
    public GameObject AstigmatismMiddleLensRight;
    public GameObject AstigmatismRightKnob;

    public bool isRotatingLeft = false;
    public bool isRotatingRight = false;

    public bool isLeftChanged = false;
    public bool isRightChanged = false;

    public float LeftDegree;
    public float RightDegree;

    public float LeftDegreeWholeNumber;
    public float RightDegreeWholeNumber;

    public GameObject leftAxisBtn; // check patients left side
    public GameObject rightAxisBtn; // check patients right side

    public GameObject LeftAxis; // check patients left side
    public GameObject RightAxis; // check patients right side

    public TextMeshProUGUI LeftAxisTMP; // check patients left side
    public TextMeshProUGUI RightAxisTMP; // check patients right side

    public LensFlip lensFlip;
    public AIVoiceChecker Checker;

    public void HandleLeftKnobClick()
    {
        isRotatingLeft = true;
    }

    public void HandleRightKnobClick()
    {
        isRotatingRight = true;
    }

    private void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (isRotatingLeft)
        {
            RightAxis.SetActive(false);
            LeftAxis.SetActive(true);
            //float rotationAmount = Input.mouseScrollDelta.y * rotationSpeed * Time.deltaTime;
            float rotation = 1;


            if (scrollInput < 0f)
            {
                // Rotate the first object
                RotateObject(AstigmatismLensLeftFrame, -rotation);

                // Rotate the second object
                RotateObject(AstigmatismMiddleLensLeft, -rotation);

                // Rotate the third object
                RotateObject(AstigmatismLeftKnob, -rotation);
                isLeftChanged = true;
                lensFlip.leftFlippedOnce = false;
                lensFlip.leftFlippedTwice = false;
            }
            else if (scrollInput > 0f)
            {
                // Rotate the first object
                RotateObject(AstigmatismLensLeftFrame, rotation);

                // Rotate the second object
                RotateObject(AstigmatismMiddleLensLeft, rotation);

                // Rotate the third object
                RotateObject(AstigmatismLeftKnob, rotation);
                isLeftChanged = true;
                lensFlip.leftFlippedOnce = false;
                lensFlip.leftFlippedTwice = false;
            }

            if (lensFlip.leftFlippedOnce && lensFlip.leftFlippedTwice && isLeftChanged && lensFlip.leftLens)
            {
                rightAxisBtn.SetActive(true);
            }
            else
            {
                rightAxisBtn.SetActive(false);
            }

        }

        if (isRotatingRight)
        {
            LeftAxis.SetActive(false);
            RightAxis.SetActive(true);
            //float rotationAmount = Input.mouseScrollDelta.y * rotationSpeed * Time.deltaTime;
            float rotation = 1;

            if (scrollInput < 0f)
            {
                // Rotate the first object
                RotateObject(AstigmatismLensRightFrame, rotation);

                // Rotate the second object
                RotateObject(AstigmatismMiddleLensRight, rotation);

                // Rotate the third object
                RotateObject(AstigmatismRightKnob, rotation);
                isRightChanged = true;
                lensFlip.rightFlippedOnce = false;
                lensFlip.rightFlippedTwice=false;
            } 
            else if(scrollInput > 0f)
            {
                // Rotate the first object
                RotateObject(AstigmatismLensRightFrame, -rotation);

                // Rotate the second object
                RotateObject(AstigmatismMiddleLensRight, -rotation);

                // Rotate the third object
                RotateObject(AstigmatismRightKnob, -rotation);
                isRightChanged = true;
                lensFlip.rightFlippedOnce = false;
                lensFlip.rightFlippedTwice = false;
            }

            if (lensFlip.rightFlippedOnce && lensFlip.rightFlippedTwice && isRightChanged && lensFlip.rightLens && Checker.isRightSideComplete)
            {
                leftAxisBtn.SetActive(true);
            } else
            {
                leftAxisBtn.SetActive(false);
            }
        }

        if(!isRotatingLeft && !isRotatingRight) 
        {   
            LeftAxis.SetActive(false); 
            RightAxis.SetActive(false);
        }
    }

    private void RotateObject(GameObject obj, float rotationAmount)
    {
        // Get the object's center position
        Vector3 center = obj.GetComponent<Renderer>().bounds.center;

        // Calculate the rotation axis as the object's up vector
        Vector3 rotationAxis = obj.transform.up;

        // Rotate the object around its center for the Y-axis
        obj.transform.RotateAround(center, rotationAxis, rotationAmount);

        if (obj == AstigmatismLeftKnob)
        {
            LeftDegree = (LeftDegree + rotationAmount) % 180;
            if (LeftDegree < 0)
            {
                LeftDegree += 180;
            }
            LeftDegreeWholeNumber = Mathf.Round(LeftDegree);
            UpdateValue(LeftAxisTMP, LeftDegree);
        }
        else if (obj == AstigmatismRightKnob)
        {
            RightDegree = (RightDegree + rotationAmount) % 180;
            if (RightDegree < 0)
            {
                RightDegree += 180;
            }
            RightDegreeWholeNumber = Mathf.Round(RightDegree);
            UpdateValue(RightAxisTMP, RightDegree);
        }
    }

    private void UpdateValue(TextMeshProUGUI valueText, float LSvalues)
    {
        valueText.text = LSvalues.ToString();
    }
}
