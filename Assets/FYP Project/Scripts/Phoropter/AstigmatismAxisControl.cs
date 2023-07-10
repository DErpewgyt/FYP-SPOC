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

    public float LeftDegree;
    public float RightDegree;

    public float LeftDegreeWholeNumber;
    public float RightDegreeWholeNumber;

    public GameObject leftAxisBtn; // check patients left side
    public GameObject rightAxisBtn; // check patients right side

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
                rightAxisBtn.SetActive(true);
            }
            else if (scrollInput > 0f)
            {
                // Rotate the first object
                RotateObject(AstigmatismLensLeftFrame, rotation);

                // Rotate the second object
                RotateObject(AstigmatismMiddleLensLeft, rotation);

                // Rotate the third object
                RotateObject(AstigmatismLeftKnob, rotation);
                rightAxisBtn.SetActive(true);
            }
        }

        if (isRotatingRight)
        {
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
                leftAxisBtn.SetActive(true);
            } 
            else if(scrollInput > 0f)
            {
                // Rotate the first object
                RotateObject(AstigmatismLensRightFrame, -rotation);

                // Rotate the second object
                RotateObject(AstigmatismMiddleLensRight, -rotation);

                // Rotate the third object
                RotateObject(AstigmatismRightKnob, -rotation);
                leftAxisBtn.SetActive(true);
            }
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
        }
        else if (obj == AstigmatismRightKnob)
        {
            RightDegree = (RightDegree + rotationAmount) % 180;
            if (RightDegree < 0)
            {
                RightDegree += 180;
            }
            RightDegreeWholeNumber = Mathf.Round(RightDegree);
        }
    }
}
