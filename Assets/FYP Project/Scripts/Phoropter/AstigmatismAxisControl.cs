using UnityEngine;

public class AstigmatismAxisControl : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public GameObject AstigmatismLensLeftFrame;
    public GameObject AstigmatismMiddleLensLeft;

    public GameObject AstigmatismLensRightFrame;
    public GameObject AstigmatismMiddleLensRight;

    public bool isRotatingLeft = false;
    public bool isRotatingRight = false;

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
        if (isRotatingLeft)
        {
            float rotationAmount = Input.mouseScrollDelta.y * rotationSpeed * Time.deltaTime;

            // Rotate the first object
            RotateObject(AstigmatismLensLeftFrame, rotationAmount);

            // Rotate the second object
            RotateObject(AstigmatismMiddleLensLeft, rotationAmount);
        }

        if (isRotatingRight)
        {
            float rotationAmount = Input.mouseScrollDelta.y * rotationSpeed * Time.deltaTime;

            // Rotate the first object
            RotateObject(AstigmatismLensRightFrame, rotationAmount);

            // Rotate the second object
            RotateObject(AstigmatismMiddleLensRight, rotationAmount);
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
    }
}
