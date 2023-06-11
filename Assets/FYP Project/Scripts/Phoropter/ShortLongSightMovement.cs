using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShortLongSightMovement : MonoBehaviour
{
    public TextMeshProUGUI RightValue;
    public TextMeshProUGUI LeftValue;

    private float LSLeft;
    private float LSRight;

    public bool LeftLSSightBool;
    public bool RightLSSightBool;

    private void Start()
    {
        LeftLSSightBool = false;
        RightLSSightBool = false;

        LSLeft = 0;
        LSRight = 0;
    }

    private void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (LeftLSSightBool)
        {
            if (scrollInput != 0f)
            {
                LSLeft += Mathf.Sign(scrollInput) * 0.25f;
                LSLeft = Mathf.Clamp(LSLeft, -19f, 16.75f);
                UpdateValue(LeftValue, LSLeft);
            }
        }

        if (RightLSSightBool)
        {
            if (scrollInput != 0f)
            {
                LSRight += Mathf.Sign(scrollInput) * 0.25f;
                LSRight = Mathf.Clamp(LSRight, -19f, 16.75f);
                UpdateValue(RightValue ,LSRight);
            }
        }
    }

    private void UpdateValue(TextMeshProUGUI valueText, float LSvalues)
    {
        valueText.text = LSvalues.ToString("F2");

        if (LSvalues < 0f)
        {
            valueText.color = Color.red;
        }
        else
        {
            valueText.color = Color.black;
        }

    }
}
