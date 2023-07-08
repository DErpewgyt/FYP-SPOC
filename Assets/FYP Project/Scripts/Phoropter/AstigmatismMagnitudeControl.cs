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

            RotateObject(LeftAstigmatismMagKnob, rotationAmount);

            TopLeftobject.SetActive(true);
            TopRightobject.SetActive(false);
            if (scrollInput != 0f)
            {
                AstigMagLeft -= Mathf.Sign(scrollInput) * 0.25f;
                AstigMagLeft = Mathf.Clamp(AstigMagLeft, 0.00f, 6.00f);
                UpdateValue(LeftValue, AstigMagLeft, TopLeftValue);
                rightMagBtn.SetActive(true);
            }
        }

        if (AstigMagRightBool)
        {
            float rotationAmount = Input.mouseScrollDelta.y * rotationSpeed * Time.deltaTime;

            RotateObject(RightAstigmatismMagKnob, rotationAmount);

            TopLeftobject.SetActive(false);
            TopRightobject.SetActive(true);
            if (scrollInput != 0f)
            {
                AstigMagRight -= Mathf.Sign(scrollInput) * 0.25f;
                AstigMagRight = Mathf.Clamp(AstigMagRight, 0.00f, 6.00f);
                UpdateValue(RightValue, AstigMagRight, TopRightValue);
                leftMagBtn.SetActive(true);
            }
        }

        if(!AstigMagRightBool && !AstigMagLeftBool)
        {
            TopLeftobject.SetActive(false);
            TopRightobject.SetActive(false);
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

    private void UpdateValue(TextMeshProUGUI valueText, float LSvalues, TextMeshProUGUI valueText2)
    {
        string formattedValue = LSvalues.ToString("F2").Replace("0.", ".");
        valueText.text = formattedValue;
        valueText.color = Color.red;
        valueText2.text = formattedValue;
        valueText2.color = Color.red;
    }
}
