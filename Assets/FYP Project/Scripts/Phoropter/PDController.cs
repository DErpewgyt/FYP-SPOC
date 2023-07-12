using UnityEngine;
using TMPro;

public class PDController : MonoBehaviour
{
    public GameObject leftHalf;
    public GameObject rightHalf;

    public GameObject leftKnob;
    public GameObject rightKnob;
    public float rotationSpeed = 10f;

    /*public float moveSpeed = 1f;
    public float scrollSensitivity = 1f;*/

    public int scrollLimit;
    public int pd;

    /*public TextMeshProUGUI PDText;*/

    public Vector3 scrollDirection = new Vector3(1f, 0f, 0f);

    private void Start()
    {
        /*scrollLimit = 0;*/
    }
    public void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0 && pd < scrollLimit)
        {
            float rotationAmount = Input.mouseScrollDelta.y * rotationSpeed * Time.deltaTime;
            // Scroll outwards
            leftHalf.transform.position -= scrollDirection;
            rightHalf.transform.position += scrollDirection;
            pd += 1;
            //UpdateTmp();

            RotateObject(leftKnob, -rotationAmount);
            RotateObject(rightKnob, -rotationAmount);
        }
        else if (scrollInput < 0 && pd > 0)
        {
            float rotationAmount = Input.mouseScrollDelta.y * rotationSpeed * Time.deltaTime;
            // Scroll inwards
            leftHalf.transform.position += scrollDirection;
            rightHalf.transform.position -= scrollDirection;
            pd -= 1;
            //UpdateTmp();

            RotateObject(leftKnob, -rotationAmount);
            RotateObject(rightKnob, -rotationAmount);
        }
    }

    private void RotateObject(GameObject obj, float rotationAmount)
    {
        // Get the object's center position
        Vector3 center = obj.GetComponent<Renderer>().bounds.center;

        // Calculate the rotation axis as the object's right vector
        Vector3 rotationAxis = obj.transform.right;

        // Rotate the object around its center for the Y-axis
        obj.transform.RotateAround(center, rotationAxis, rotationAmount);


    }

    /*    private void UpdateTmp()
        {
            PDText.text = pd.ToString();
        }*/
}