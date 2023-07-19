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

    public AudioSource GreenClearer;
    public AudioSource RedClearer;

    /*
    public AudioSource LeftAxisClear1;
    public AudioSource LeftAxisClear2;

    public AudioSource LeftMagClear1;
    public AudioSource LeftMagClear2;

    public AudioSource RightAxisClear1;
    public AudioSource RightAxisClear2;

    public AudioSource RightMagClear1;
    public AudioSource RightMagClear2;
    */
    public AudioSource ClearerSideis1;
    public AudioSource ClearerSideis2;
    public AudioSource BothAreClear;

    public AudioSource StillClear;
    public AudioSource BecomeBlur;

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

    public float finalls;
    public float finalrs;

    public float LeftMag;
    public float RightMag;

    public float leftAxis;
    public float rightAxis;

    public int leftfinalcheckint;
    public int rightfinalcheckint;

    public float leftfinalcheckfloat;
    public float rightfinalcheckfloat;

    public float MeasurementChanges = 0.25f;

    public GameObject CheckBtn; // check objective refraction
    public GameObject rsBtn; // check patient's right side
    public GameObject lsBtn; // check patient's left side
    public GameObject rightMagBtn; // Checks patients right side
    public GameObject leftMagBtn; // Checks patients left side
    public GameObject rightAxisBtn; // check patients right side
    public GameObject leftAxisBtn; // check patients left side
    public GameObject rightFinalBtn; //do final check for each side
    public GameObject leftFinalBtn; //do final check for each side

    public bool isSetupComplete = false;

    public bool IsRighteyeOpen = false; 
    public bool isRightSideLSComplete = false; //for patients right
    public bool isRightSideAstigAxisComplete = false;//for patients left
    public bool isRightSideAstigMagComplete = false;//for patients left
    public bool isRightSideFinalComplete = false; //for patients right

    public bool IsLefteyeOpen = false;
    public bool isLeftSideLSComplete = false;//for patients left
    public bool isLeftSideAstigAxisComplete = false; //for patients right
    public bool isLeftSideAstigMagComplete = false; //for patients right
    public bool isLeftSideFinalComplete = false;//for patients left

    public bool isRightSideComplete = false; //for patients right
    public bool isLeftSideComplete = false;//for patients left

    public OpenClose OpenCloseController;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(GetMeasurements());
    }

    private void Update()
    {
        ls = LSController.LSLeft;
        rs = LSController.LSRight;
        finalls = LSController.LSLeft;
        finalrs = LSController.LSRight;
        rightAxis = axisController.LeftDegreeWholeNumber;
        leftAxis = axisController.RightDegreeWholeNumber;
        RightMag = MagnitudeController.AstigMagLeft;
        LeftMag = MagnitudeController.AstigMagRight;

        if(openCloseController.isLeftActive && !openCloseController.isRightActive && isRightSideFinalComplete)
        {
            IsLefteyeOpen = true;
        } 
        else
        {
            IsLefteyeOpen = false;
        }

        if (!openCloseController.isLeftActive && openCloseController.isRightActive && isSetupComplete)
        {
            IsRighteyeOpen = true;
        } 
        else 
        { 
            IsRighteyeOpen = false;
        }

        if (isRightSideAstigAxisComplete && isRightSideAstigMagComplete && isRightSideFinalComplete && isRightSideLSComplete)
        {
            isRightSideComplete = true;
        }

        if(isLeftSideAstigAxisComplete && isLeftSideAstigMagComplete && isLeftSideFinalComplete && isLeftSideLSComplete)
        {
            isLeftSideComplete = true;
        }

        if(ls != RS)
        {
            isRightSideLSComplete = false;
            //Debug.Log("KILL YOURSELF");
        }

        if (rs != LS)
        {
            isLeftSideLSComplete = false;
        }

        if (LeftMag != LC)
        {
            isLeftSideAstigMagComplete = false;
        }

        if (RightMag != RC)
        {
            isRightSideAstigMagComplete = false;
        }

        if (leftAxis != LA)
        {
            isLeftSideAstigAxisComplete = false;
        }

        if (rightAxis != RA)
        {
            isRightSideAstigAxisComplete = false;
        }

        if(finalls != rightfinalcheckfloat)
        {
            isRightSideFinalComplete = false;
        }

        if (finalrs != leftfinalcheckfloat)
        {
            isLeftSideFinalComplete = false;
        }
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

        int randomChangeRS = Random.Range(0, 5);

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

        int randomChangeLS = Random.Range(0, 5);

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

        leftfinalcheckint = Random.Range(0, 2);
        rightfinalcheckint = Random.Range(0, 2);

        if(leftfinalcheckint == 0)
        {
            leftfinalcheckfloat = LS;
            print("this is leftfinalcheckfloat: " + leftfinalcheckfloat);
        }

        else if (leftfinalcheckint == 1)
        {
            leftfinalcheckfloat = LS + 0.25f;
            print("this is leftfinalcheckfloat: " + leftfinalcheckfloat);
        }

        else if (leftfinalcheckint == 2)
        {
            leftfinalcheckfloat = LS + 0.5f;
            print("this is leftfinalcheckfloat: " + leftfinalcheckfloat);
        }

        if (rightfinalcheckint == 0)
        {
            rightfinalcheckfloat = RS;
            print("this is rightfinalcheckfloat: " + rightfinalcheckfloat);
        }

        else if (rightfinalcheckint == 1)
        {
            rightfinalcheckfloat = RS + 0.25f;
            print("this is rightfinalcheckfloat: " + rightfinalcheckfloat);
        }

        else if (rightfinalcheckint == 2)
        {
            rightfinalcheckfloat = RS + 0.5f;
            print("this is rightfinalcheckfloat: " + rightfinalcheckfloat);
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

    public void rsCheck() // Check patient's right
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
                    //rightClear.Play();
                    BothAreClear.Play();
                    isRightSideLSComplete = true;
                }
                else if (ls > RS)
                {
                    //rightTooClear.Play();
                    RedClearer.Play();
                }
                else if (ls < RS)
                {
                    //rightBlur.Play();
                    GreenClearer.Play();
                }
            }
        }
        rsBtn.SetActive(false);
    }

    public void lsCheck() // Check patient's left
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
                    //leftClear.Play();
                    BothAreClear.Play();
                    isLeftSideLSComplete = true;
                }
                else if (rs > LS)
                {
                    //leftTooClear.Play();
                    RedClearer.Play();
                }
                else if (rs < LS)
                {
                    //leftBlur.Play();
                    GreenClearer.Play();
                }
            }
        }
        lsBtn.SetActive(false);
    }

    public void LeftMagCheck() // Check patients right
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
            LensFlip.leftFlippedOnce = false;
            LensFlip.leftFlippedTwice = false;
            MagnitudeController.isRightChanged = false;
            if (LeftMag == LC)
            {
                //perfect.Play();
                BothAreClear.Play();
                print("Both are the same");
                isLeftSideAstigMagComplete = true;
            }
            else if (LeftMag < LC)
            {
                ClearerSideis2.Play();
                //isLeftSideAstigMagComplete = false;
            }
            else if (LeftMag > LC)
            {
                ClearerSideis1.Play();
                //isLeftSideAstigMagComplete = false;
            }
        }
        leftMagBtn.SetActive(false);
    }

    public void RightMagCheck() // Check patients left
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
                //perfect.Play();
                BothAreClear.Play();
                print("Both are the same");
                isRightSideAstigMagComplete = true;
            }
            else if (RightMag < RC)
            {
                ClearerSideis2.Play();
                //isRightSideAstigMagComplete = false;
            }
            else if (RightMag > RC)
            {
                ClearerSideis1.Play();
               //isRightSideAstigMagComplete = false;
            }
        }
        rightMagBtn.SetActive(false);
    }

    public void leftAxisCheck() // check patient's right axis
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
            LensFlip.rightFlippedOnce = false;
            LensFlip.rightFlippedTwice = false;
            axisController.isRightChanged = false;
            if (leftAxis == LA)
            {
                //perfect.Play();
                BothAreClear.Play();
                isLeftSideAstigAxisComplete = true;
            }
            else if (leftAxis < LA)
            {
                print("1 is more clear, (Increase Angle right)");
                ClearerSideis1.Play();
                //isLeftSideAstigAxisComplete = false;
            }
            else if (leftAxis > LA)
            {
                print("2 is more clear, (Decrease Angle right)");
                ClearerSideis2.Play();
                //isLeftSideAstigAxisComplete = false;
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
                //perfect.Play();
                BothAreClear.Play();
                print("They are both the same");
                isRightSideAstigAxisComplete = true;
            }
            else if (rightAxis < RA)
            {
                print("1 is more clear, (Increase Angle left)");
                ClearerSideis1.Play();
                //isRightSideAstigAxisComplete = false;
            }
            else if (rightAxis > RA)
            {
                print("2 is more clear, (Decrease Angle left)");
                ClearerSideis2.Play();
               //isRightSideAstigAxisComplete = false;
            }
        }
        rightAxisBtn.SetActive(false);
    }

    public void leftFinalCheck() // Chcek patient's left
    {
        isLeftOpen = openCloseController.isRightActive;
        finalrs = LSController.LSRight;
        print(finalrs);
        if (isLeftOpen == true)
        {
            print("cannot see anything");
        }
        else
        {
            if (finalrs == leftfinalcheckfloat)//6.5=6.5
            {
                //leftClear.Play();
                Debug.Log("still clear!(anymore and ill be wrong)");
                StillClear.Play();
                //isLeftSideFinalComplete = true;
            }
            else if (finalrs > leftfinalcheckfloat)//6.75>6.5
            {
                //leftTooClear.Play();
                Debug.Log("blur/wrong");
                BecomeBlur.Play();
            }

            else if (finalrs < leftfinalcheckfloat)
            {
                //leftTooClear.Play();
                Debug.Log("clear! (power too high rn)");
                StillClear.Play();
            }
            else
                Debug.Log("unclear! (power way too high rn)");
        }
    }

    public void rightFinalCheck() // Chcek patient's right
    {
        isRightOpen = openCloseController.isLeftActive;
        finalls = LSController.LSLeft;
        print(finalls);
        if (isRightOpen == true)
        {
            print("cannot see anything");
        }
        else
        {
            if (finalls == rightfinalcheckfloat)//6.5=6.5
            {
                //leftClear.Play();
                Debug.Log("still clear!(anymore and ill be wrong)");
                //isRightSideFinalComplete = true;
                StillClear.Play();
            }
            else if (finalls > rightfinalcheckfloat)//6.75>6.5
            {
                //leftTooClear.Play();
                Debug.Log("blur/wrong");
                BecomeBlur.Play();
            }

            else if (finalls < rightfinalcheckfloat)
            {
                //leftTooClear.Play();
                Debug.Log("clear! (power too high rn)");
                StillClear.Play();
            }
            else
                Debug.Log("unclear! (power way too high rn)");
        }
    }

    public void leftfinalsubmit()
    {
        if (finalrs == leftfinalcheckfloat)//6.5=6.5
        {
            //leftClear.Play();
            Debug.Log("still clear!(anymore and ill be wrong)");
            //StillClear.Play();
            isLeftSideFinalComplete = true;
        }
        else
            Debug.Log("thanks");
    }

    public void rightfinalsubmit()
    {
        if (finalls == rightfinalcheckfloat)//6.5=6.5
        {
            //leftClear.Play(); 
            Debug.Log("still clear!(anymore and ill be wrong)");
            isRightSideFinalComplete = true;
            //StillClear.Play();
        }
        else
            Debug.Log("thanksright");
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