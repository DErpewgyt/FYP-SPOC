using System.Collections;
using UnityEngine;

public class AIVoiceChecker : MonoBehaviour
{
    public MeasureReadings paper;
    public RulerController ruler;

    public AudioSource perfect;
    public AudioSource tooNear;
    public AudioSource tooFar;

    public int pd;
    public string RS;
    public string RC;
    public int RA;

    public string LS;
    public string LC;
    public int LA;
    
    public int rulerDist;
    public int correctDist;

    public float MeasurementChanges = 0.25f; // Increment/decrement value for rsTake

    public GameObject CheckBtn;

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
        int randomChangePD = Random.Range(0, 3); // Generates a random number between 0 and 2

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
        }

        int randomChangeRS = Random.Range(0, 13);

        float adjustedRsTake = paper.rsTake;

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

        RS = RoundToQuarter(adjustedRsTake); // Round the adjusted value to the nearest 0.25



        int randomChangeRC = Random.Range(0, 9); // Generates a random number between 0 and 6

        float adjustedRcTake = paper.rcTake; // Variable to store adjusted rsTake

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

        LC = RoundToQuarter(adjustedLcTake); // Round the adjusted value to the nearest 0.25
/*        string LC = LCformat.ToString("F2");
*/

        int randomChangeLA = Random.Range(0, 11);

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
            correctDist = 167;
        }
        if (pd == 61)
        {
            correctDist = 170;
        }
        if (pd == 62)
        {
            correctDist = 173;
        }
        if (pd == 63)
        {
            correctDist = 176;
        }
        if (pd == 64)
        {
            correctDist = 179;
        }
        if (pd == 65)
        {
            correctDist = 182;
        }
        if (pd == 66)
        {
            correctDist = 185;
        }
        if (pd == 67)
        {
            correctDist = 188;
        }
        if (pd == 68)
        {
            correctDist = 191;
        }
        if (pd == 69)
        {
            correctDist = 194;
        }
        if (pd == 70)
        {
            correctDist = 197;
        }
        if (pd == 71)
        {
            correctDist = 200;
        }
        if (pd == 72)
        {
            correctDist = 203;
        }
        if (pd == 73)
        {
            correctDist = 206;
        }
        if (pd == 74)
        {
            correctDist = 209;
        }
    }

    public void check()
    {
        rulerDist = ruler.rulerDist;
        print(rulerDist);
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
        CheckBtn.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private string RoundToQuarter(float value)
    {
        float roundedValue = Mathf.Round(value * 4f) / 4f;
        string formattedValue = roundedValue.ToString("F2");
        return formattedValue;
    }


    /*// Rounds the value to the nearest 0.25
    private float RoundToQuarter(float value)
    {
        float roundedValue = Mathf.Round(value * 4f) / 4f;
        return roundedValue;
    }*/
}