using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LSshortCut : MonoBehaviour
{
    public GameObject Leftside;
    public GameObject RightSide;

    public ShortLongSightMovement ShortLongSightMovement;
    // Start is called before the first frame update
    void Start()
    {
        Leftside.SetActive(false);
        RightSide.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ShortLongSightMovement.LeftLSSightBool)
        {
            Leftside.SetActive(true);
        }
        else
        {
            Leftside.SetActive(false);
        }

        if (ShortLongSightMovement.RightLSSightBool)
        {
            RightSide.SetActive(true);
        } 
        else
        {
            RightSide.SetActive(false);
        }
    }

    public void Add3ToLeftside()
    {
        ShortLongSightMovement.LSLeft += 3;
        UpdateValue(ShortLongSightMovement.LeftValue, ShortLongSightMovement.LSLeft);
    }

    public void Subtract3ToLeftside()
    {
        ShortLongSightMovement.LSLeft -= 3;
        UpdateValue(ShortLongSightMovement.LeftValue, ShortLongSightMovement.LSLeft);
    }

    public void Add3ToRightside()
    {
        ShortLongSightMovement.LSRight += 3;
        UpdateValue(ShortLongSightMovement.RightValue, ShortLongSightMovement.LSRight);
    }

    public void Subtract3ToRightside()
    {
        ShortLongSightMovement.LSRight -= 3;
        UpdateValue(ShortLongSightMovement.RightValue, ShortLongSightMovement.LSRight);
    }

    private void UpdateValue(TextMeshProUGUI valueText, float LSvalue)
    {
        valueText.text = LSvalue.ToString();
    }
}
