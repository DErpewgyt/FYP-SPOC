using System.Collections;
using UnityEngine;

public class AIVoiceChecker : MonoBehaviour
{
    public MeasureReadings paper;
    public RulerController ruler;
    public ShortLongSightMovement LSController;
    public AstigmatismMagnitudeControl MagnitudeController;
    public AstigmatismAxisControl axisController;
    public OpenClose openCloseController;
    public LensFlip LensFlip;

    public AudioSource perfect;
    public AudioSource tooNear;
    public AudioSource tooFar;

    public AudioSource leftBlur;
    public AudioSource leftClear;
    public AudioSource leftTooClear;

    public AudioSource rightBlur;
    public AudioSource rightClear;
    public AudioSource rightTooClear;

    public bool isLeftOpen; // cover on patient's left
    public bool isRightOpen; // cover on patient's right

    public int pd;

    public float RS;
    public float RC;
    public int RA;

    public float PRS;
    public float PRC;
    public int PRA;

    public float LS;
    public float LC;
    public int LA;

    public float PLS;
    public float PLC;
    public int PLA;

    public int rulerDist;
    public int correctDist;

    public float ls;
    public float rs;

    public float LeftMag;
    public float RightMag;

    public float leftAxis;
    public float rightAxis;

    public float MeasurementChanges = 0.25f;

    public GameObject CheckBtn; // check objective refraction
    public GameObject rsBtn; // check patient's right side
    public GameObject lsBtn; // check patient's left side
    public GameObject rightMagBtn; // Checks patients right side
    public GameObject leftMagBtn; // Checks patients left side
    public GameObject rightAxisBtn; // check patients right side
    public GameObject leftAxisBtn; // check patients left side

    public bool isSetupComplete = false;

    public bool isRightSideComplete = false;
    public bool isRightSideLSComplete = false;
    public bool isRightSideAstigAxisComplete = false;
    public bool isRightSideAstigMagComplete = false;

    public bool isLeftSideComplete = false;
    public bool isLeftSideLSComplete = false;
    public bool isLeftSideAstigAxisComplete = false;
    public bool isLeftSideAstigMagComplete = false;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(GetMeasurements());
    }

    private IEnumerator GetMeasurements()
    {
        // Wait for one frame to ensure that MeasureReadings initializes its variables
        yield return null;

        /* Random Answer Generator*/////////////////////////////////////////////////////////////////////////////////
        /*int randomChangePD = Random.Range(0, 3);

        switch (randomChangePD)
        {
            case 0:
                pd = Mathf.Max(paper.pd - 2, 60);
                break;

            case 1:
                pd = Mathf.Min(paper.pd + 2, 74);
                break;

            default:
                pd = paper.pd;
                break;
        }*/

        pd = paper.pd;

        int randomChangeRS = Random.Range(0, 13);

        float adjustedRsTake = paper.rsTake;
        PRS = RoundToQuarter(paper.rsTake);

        switch (randomChangeRS)
        {
            case 0:
                adjustedRsTake = Mathf.Max(adjustedRsTake - MeasurementChanges, -19.00f);
                break;

            case 1:
                adjustedRsTake = Mathf.Min(adjustedRsTake + MeasurementChanges, 0.00f);
                break;

            case 2:
                adjustedRsTake = Mathf.Max(adjustedRsTake - MeasurementChanges * 2, -19.00f);
                break;

            case 3:
                adjustedRsTake = Mathf.Min(adjustedRsTake + MeasurementChanges * 2, 0.00f);
                break;

            case 4:
                adjustedRsTake = Mathf.Max(adjustedRsTake - MeasurementChanges * 3, -19.00f);
                break;

            case 5:
                adjustedRsTake = Mathf.Min(adjustedRsTake + MeasurementChanges * 3, 0.00f);
                break;

            case 6:
                adjustedRsTake = Mathf.Max(adjustedRsTake - MeasurementChanges * 4, -19.00f);
                break;

            case 7:
                adjustedRsTake = Mathf.Min(adjustedRsTake + MeasurementChanges * 4, 0.00f);
                break;

            case 8:
                adjustedRsTake = Mathf.Max(adjustedRsTake - MeasurementChanges * 5, -19.00f);
                break;

            case 9:
                adjustedRsTake = Mathf.Min(adjustedRsTake + MeasurementChanges * 5, 0.00f);
                break;

            case 10:
                adjustedRsTake = Mathf.Max(adjustedRsTake - MeasurementChanges * 6, -19.00f);
                break;

            case 11:
                adjustedRsTake = Mathf.Min(adjustedRsTake + MeasurementChanges * 6, 0.00f);
                break;

            default:
                break;
        }

        RS = RoundToQuarter(adjustedRsTake);

        int randomChangeRC = Random.Range(0, 9);

        float adjustedRcTake = paper.rcTake;
        PRC = RoundToQuarter(paper.rcTake);

        switch (randomChangeRC)
        {
            case 0:
                adjustedRcTake = Mathf.Max(adjustedRcTake - MeasurementChanges, -6.00f);
                break;

            case 1:
                adjustedRcTake = Mathf.Min(adjustedRcTake + MeasurementChanges, 0.00f);
                break;

            case 2:
                adjustedRcTake = Mathf.Max(adjustedRcTake - MeasurementChanges * 2, -6.00f);
                break;

            case 3:
                adjustedRcTake = Mathf.Min(adjustedRcTake + MeasurementChanges * 2, 0.00f);
                break;

            case 4:
                adjustedRcTake = Mathf.Max(adjustedRcTake - MeasurementChanges * 3, -6.00f);
                break;

            case 5:
                adjustedRcTake = Mathf.Min(adjustedRcTake + MeasurementChanges * 3, 0.00f);
                break;

            case 6:
                adjustedRcTake = Mathf.Max(adjustedRcTake - MeasurementChanges * 4, -6.00f);
                break;

            case 7:
                adjustedRcTake = Mathf.Min(adjustedRcTake + MeasurementChanges * 4, 0.00f);
                break;

            default:
                break;
        }

        RC = RoundToQuarter(adjustedRcTake);

        int randomChangeRA = Random.Range(0, 11);
        PRA = paper.raTake;

        switch (randomChangeRA)
        {
            case 0:
                RA = Mathf.Min(paper.raTake + 1, 180);
                break;

            case 1:
                RA = Mathf.Max(paper.raTake - 1, 0);
                break;

            case 2:
                RA = Mathf.Min(paper.raTake + 2, 180);
                break;

            case 3:
                RA = Mathf.Max(paper.raTake - 2, 0);
                break;

            case 4:
                RA = Mathf.Min(paper.raTake + 3, 180);
                break;

            case 5:
                RA = Mathf.Max(paper.raTake - 3, 0);
                break;

            case 6:
                RA = Mathf.Min(paper.raTake + 4, 180);
                break;

            case 7:
                RA = Mathf.Max(paper.raTake - 4, 0);
                break;

            case 8:
                RA = Mathf.Min(paper.raTake + 5, 180);
                break;

            case 9:
                RA = Mathf.Max(paper.raTake - 5, 0);
                break;

            default:
                RA = paper.raTake;
                break;
        }

        /***********************************************  LEFT  *******************************************************/

        int randomChangeLS = Random.Range(0, 13);

        float adjustedLsTake = paper.lsTake;
        PLS = RoundToQuarter(paper.lsTake);

        switch (randomChangeLS)
        {
            case 0:
                adjustedLsTake = Mathf.Max(adjustedLsTake - MeasurementChanges, -19.00f);
                break;

            case 1:
                adjustedLsTake = Mathf.Min(adjustedLsTake + MeasurementChanges, 0.00f);
                break;

            case 2:
                adjustedLsTake = Mathf.Max(adjustedLsTake - MeasurementChanges * 2, -19.00f);
                break;

            case 3:
                adjustedLsTake = Mathf.Min(adjustedLsTake + MeasurementChanges * 2, 0.00f);
                break;

            case 4:
                adjustedLsTake = Mathf.Max(adjustedLsTake - MeasurementChanges * 3, -19.00f);
                break;

            case 5:
                adjustedLsTake = Mathf.Min(adjustedLsTake + MeasurementChanges * 3, 0.00f);
                break;

            case 6:
                adjustedLsTake = Mathf.Max(adjustedLsTake - MeasurementChanges * 4, -19.00f);
                break;

            case 7:
                adjustedLsTake = Mathf.Min(adjustedLsTake + MeasurementChanges * 4, 0.00f);
                break;

            case 8:
                adjustedLsTake = Mathf.Max(adjustedLsTake - MeasurementChanges * 5, -19.00f);
                break;

            case 9:
                adjustedLsTake = Mathf.Min(adjustedLsTake + MeasurementChanges * 5, 0.00f);
                break;

            case 10:
                adjustedLsTake = Mathf.Max(adjustedLsTake - MeasurementChanges * 6, -19.00f);
                break;

            case 11:
                adjustedLsTake = Mathf.Min(adjustedLsTake + MeasurementChanges * 6, 0.00f);
                break;

            default:
                break;
        }

        LS = RoundToQuarter(adjustedLsTake);

        int randomChangeLC = Random.Range(0, 9);

        float adjustedLcTake = paper.lcTake;
        PLC = RoundToQuarter(paper.lcTake);

        switch (randomChangeLC)
        {
            case 0:
                adjustedLcTake = Mathf.Max(adjustedLcTake - MeasurementChanges, -6.00f);
                break;

            case 1:
                adjustedLcTake = Mathf.Min(adjustedLcTake + MeasurementChanges, 0.00f);
                break;

            case 2:
                adjustedLcTake = Mathf.Max(adjustedLcTake - MeasurementChanges * 2, -6.00f);
                break;

            case 3:
                adjustedLcTake = Mathf.Min(adjustedLcTake + MeasurementChanges * 2, 0.00f);
                break;

            case 4:
                adjustedLcTake = Mathf.Max(adjustedLcTake - MeasurementChanges * 3, -6.00f);
                break;

            case 5:
                adjustedLcTake = Mathf.Min(adjustedLcTake + MeasurementChanges * 3, 0.00f);
                break;

            case 6:
                adjustedLcTake = Mathf.Max(adjustedLcTake - MeasurementChanges * 4, -6.00f);
                break;

            case 7:
                adjustedLcTake = Mathf.Min(adjustedLcTake + MeasurementChanges * 4, 0.00f);
                break;

            default:
                break;
        }

        LC = RoundToQuarter(adjustedLcTake);
        /*        string LC = LCformat.ToString("F2");
        */

        int randomChangeLA = Random.Range(0, 11);
        PLA = paper.laTake;

        switch (randomChangeLA)
        {
            case 0:
                LA = Mathf.Min(paper.laTake + 1, 180);
                break;

            case 1:
                LA = Mathf.Max(paper.laTake - 1, 0);
                break;

            case 2:
                LA = Mathf.Min(paper.laTake + 2, 180);
                break;

            case 3:
                LA = Mathf.Max(paper.laTake - 2, 0);
                break;

            case 4:
                LA = Mathf.Min(paper.laTake + 3, 180);
                break;

            case 5:
                LA = Mathf.Max(paper.laTake - 3, 0);
                break;

            case 6:
                LA = Mathf.Min(paper.laTake + 4, 180);
                break;

            case 7:
                LA = Mathf.Max(paper.laTake - 4, 0);
                break;

            case 8:
                LA = Mathf.Min(paper.laTake + 5, 180);
                break;

            case 9:
                LA = Mathf.Max(paper.laTake - 5, 0);
                break;

            default:
                LA = paper.laTake;
                break;
        }

        /***********************************************************************************************************/

        // Print the retrieved value of pd
        print("Retrieved PD value: " + pd);
        print("/*********               RIGHT        ************/");
        print("Retrieved RS Take value:" + RS);
        print("Retrieved RC Take value:" + RC);
        print("Retrieved RA Take value:" + RA);
        print("/*********               LEFT         ************/");
        print("Retrieved LS Take value:" + LS);
        print("Retrieved LC Take value:" + LC);
        print("Retrieved LA Take value:" + LA);

        print("/*****************************************************************/");

        // Checker for PD
        if (pd == 60)
        {
            correctDist = 34;
        }
        if (pd == 61)
        {
            correctDist = 37;
        }
        if (pd == 62)
        {
            correctDist = 40;
        }
        if (pd == 63)
        {
            correctDist = 43;
        }
        if (pd == 64)
        {
            correctDist = 46;
        }
        if (pd == 65)
        {
            correctDist = 49;
        }
        if (pd == 66)
        {
            correctDist = 52;
        }
        if (pd == 67)
        {
            correctDist = 55;
        }
        if (pd == 68)
        {
            correctDist = 58;
        }
        if (pd == 69)
        {
            correctDist = 61;
        }
        if (pd == 70)
        {
            correctDist = 64;
        }
        if (pd == 71)
        {
            correctDist = 67;
        }
        if (pd == 72)
        {
            correctDist = 70;
        }
        if (pd == 73)
        {
            correctDist = 73;
        }
        if (pd == 74)
        {
            correctDist = 76;
        }
    }

    public void paperCheck()
    {
        rulerDist = ruler.rulerDist;
        ls = LSController.LSLeft;
        rs = LSController.LSRight;
        LeftMag = MagnitudeController.AstigMagRight;
        RightMag = MagnitudeController.AstigMagLeft;
        leftAxis = axisController.RightDegreeWholeNumber;
        rightAxis = axisController.LeftDegreeWholeNumber;
        if (rulerDist == correctDist && ls == PRS && rs == PLS && LeftMag == PLC && RightMag == PRC && leftAxis == PLA && rightAxis == PRA)
        {
            perfect.Play();
            isSetupComplete = true;
            CheckBtn.SetActive(false);
            print("correct calibrated readings");
        }
        else
        {
            print("wrong calibrated readings");
        }
    }

    /*public void pdCheck()
    {
        rulerDist = ruler.rulerDist;
        isLeftOpen = openCloseController.isRightActive;
        isRightOpen = openCloseController.isLeftActive;
        print(rulerDist);
        if (isLeftOpen == true || isRightOpen == true)
        {
            print("cannot see anything");
        }
        else
        {
            if (rulerDist == correctDist)
            {
                perfect.Play();
            }
            else if (rulerDist < correctDist)
            {
                tooNear.Play();
            }
            else if (rulerDist > correctDist)
            {
                tooFar.Play();
            }
        }
        CheckBtn.SetActive(false);
    }*/

    public void rsCheck() // Chcek patient's right
    {
        ls = LSController.LSLeft;
        isRightOpen = openCloseController.isLeftActive;
        isLeftOpen = openCloseController.isRightActive;
        print(ls);
        if (isRightOpen == true)
        {
            print("cannot see anything");
        }
        else
        {
            if (isLeftOpen == false)
            {
                print("pls close the patient's left cover first");
            }
            else
            {
                if (ls == RS)
                {
                    rightClear.Play();
                    isRightSideLSComplete = true;
                }
                else if (ls > RS)
                {
                    rightTooClear.Play();
                }
                else if (ls < RS)
                {
                    rightBlur.Play();
                }
            }
        }
        rsBtn.SetActive(false);
    }

    public void lsCheck() // Chcek patient's left
    {
        isLeftOpen = openCloseController.isRightActive;
        isRightOpen = openCloseController.isLeftActive;
        rs = LSController.LSRight;
        print(rs);
        if (isLeftOpen == true)
        {
            print("cannot see anything");
        }
        else
        {
            if (isRightOpen == false)
            {
                print("pls close the patient's right cover first");
            }
            else
            {
                if (rs == LS)
                {
                    leftClear.Play();
                }
                else if (rs > LS)
                {
                    leftTooClear.Play();
                }
                else if (rs < LS)
                {
                    leftBlur.Play();
                }
            }
        }
        lsBtn.SetActive(false);
    }

    public void LeftMagCheck() // Check patients left
    {
        LeftMag = MagnitudeController.AstigMagRight;
        isLeftOpen = openCloseController.isRightActive;
        print(LeftMag);
        print(LC);
        if (isLeftOpen == true)
        {
            print("cannot see anything");
        }
        else
        {
            if (LeftMag == LC)
            {
                perfect.Play();
            }
            else if (LeftMag < LC)
            {
                print("less than");
            }
            else if (LeftMag > LC)
            {
                print("more than");
            }
        }
        leftMagBtn.SetActive(false);
    }

    public void RightMagCheck() // Check patients right
    {
        RightMag = MagnitudeController.AstigMagLeft;
        isRightOpen = openCloseController.isLeftActive;
        print(RightMag);
        if (isRightOpen == true)
        {
            print("cannot see anything");
        }
        else
        {
            LensFlip.leftFlippedOnce = false;
            LensFlip.leftFlippedTwice = false;
            MagnitudeController.isLeftChanged = false;
            if (RightMag == RC)
            {
                perfect.Play();
                print("Both are the same");
            }
            else if (RightMag < RC)
            {
                print("1 is more clear, (decrease Magnitude)");
            }
            else if (RightMag > RC)
            {
                print("2 is more clear, (increase Magnitude)");
            }
        }
        rightMagBtn.SetActive(false);
    }

    public void leftAxisCheck() // check patient's left axis
    {
        leftAxis = axisController.RightDegreeWholeNumber;
        isLeftOpen = openCloseController.isRightActive;
        print(leftAxis);
        if (isLeftOpen == true)
        {
            print("cannot see anything");
        }
        else
        {
            if (leftAxis == LA)
            {
                perfect.Play();
            }
            else if (leftAxis < LA)
            {
                print("less than");
            }
            else if (leftAxis > LA)
            {
                print("more than");
            }
        }
        leftAxisBtn.SetActive(false);
    }

    public void rightAxisCheck() // check patient's left axis
    {
        rightAxis = axisController.LeftDegreeWholeNumber;
        isRightOpen = openCloseController.isLeftActive;
        print(rightAxis);
        if (isRightOpen == true)
        {
            print("cannot see anything");
        }
        else
        {
            LensFlip.leftFlippedOnce = false;
            LensFlip.leftFlippedTwice = false;
            axisController.isLeftChanged = false;
            if (rightAxis == RA)
            {
                perfect.Play();
                print("They are both the same");
                isRightSideAstigAxisComplete = true;
            }
            else if (rightAxis < RA)
            {
                print("1 is more clear, (Increase Angle)");
                isRightSideAstigAxisComplete = false;
            }
            else if (rightAxis > RA)
            {
                print("2 is more clear, (Decrease Angle)");
                isRightSideAstigAxisComplete = false;
            }
        }
        rightAxisBtn.SetActive(false);
    }

    /*private string RoundToQuarter(float value)
    {
        float roundedValue = Mathf.Round(value * 4f) / 4f;
        string formattedValue = roundedValue.ToString("F2");
        return formattedValue;
    }*/

    // Rounds the value to the nearest 0.25
    private float RoundToQuarter(float value)
    {
        float roundedValue = Mathf.Round(value * 4f) / 4f;
        return roundedValue;
    }
}