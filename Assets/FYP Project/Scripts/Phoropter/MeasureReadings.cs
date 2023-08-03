using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeasureReadings : MonoBehaviour
{
    public GameObject smallPD;
    public GameObject mediumPD;
    public GameObject largePD;


    /*RIGHT*/

    public TextMeshProUGUI RS1;
    public TextMeshProUGUI RS2;
    public TextMeshProUGUI RS3;
    public TextMeshProUGUI RS_Take;

    public TextMeshProUGUI RC1;
    public TextMeshProUGUI RC2;
    public TextMeshProUGUI RC3;
    public TextMeshProUGUI RC_Take;

    public TextMeshProUGUI RA1;
    public TextMeshProUGUI RA2;
    public TextMeshProUGUI RA3;
    public TextMeshProUGUI RA_Take;

    /*LEFT*/

    public TextMeshProUGUI LS1;
    public TextMeshProUGUI LS2;
    public TextMeshProUGUI LS3;
    public TextMeshProUGUI LS_Take;

    public TextMeshProUGUI LC1;
    public TextMeshProUGUI LC2;
    public TextMeshProUGUI LC3;
    public TextMeshProUGUI LC_Take;

    public TextMeshProUGUI LA1;
    public TextMeshProUGUI LA2;
    public TextMeshProUGUI LA3;
    public TextMeshProUGUI LA_Take;

    //VD, PD. SE, SN, No.

    public TextMeshProUGUI VD;
    public TextMeshProUGUI PD;

    public TextMeshProUGUI SE_Right;
    public TextMeshProUGUI SE_Left;

    public TextMeshProUGUI SN;
    public TextMeshProUGUI NO;

    public int pd;
    public float rsTake;
    public float lsTake;

    public float rcTake;
    public float lcTake;

    public int raTake;
    public int laTake;

    void Start()
    {
        // Serial Number & Number & VD & PD
        float serialNumber = Random.Range(1000f, 600000f);
        float number = Random.Range(0f, 6000f);
        float vd = 12f;
        pd = Random.Range(55, 71);

        /******************************************************************************************/

        // Right Power (S)
        float rs1 = Random.Range(0.00f, -19.00f);
        float rs2 = rs1;
        float rs3 = rs1;
        rsTake = rs1;

        // Right Astigmatism (C)
        float rc1 = Random.Range(0.00f, -6.00f);
        float rc2 = rc1;
        float rc3 = rc1;
        rcTake = rc1;

        // Right Axis-Astigmatism (A)
        int ra1 = Random.Range(0, 180);
        int ra2 = ra1 - 1;
        int ra3 = ra1 - 3;
        raTake = Mathf.RoundToInt(Mathf.Ceil((ra1 + ra2 + ra3) / 3));

        // Right Spherical Equivalent (SE)
        float seRight = rs1 + (rc1 / 2f);

        /******************************************************************************************/

        // Left Power (S)
        float ls1 = Random.Range(0.00f, -19.00f);
        float ls2 = ls1;
        float ls3 = ls1;
        lsTake = ls1;

        // Left Astigmatism (C)
        float lc1 = Random.Range(0.00f, -6.00f);
        float lc2 = lc1;
        float lc3 = lc1;
        lcTake = lc1;

        // Left Axis-Astigmatism (A)
        float la1 = Random.Range(0f, 180f);
        float la2 = la1 - 1;
        float la3 = la1 - 3;
        laTake = Mathf.RoundToInt(Mathf.Ceil((la1 + la2 + la3) / 3));

        // Left Spherical Equivalent (SE)
        float seLeft = ls1 + (lc1 / 2f);

        /******************************************************************************************/

        if (pd <= 59)
        {
            smallPD.SetActive(true);
        } 
        if (pd >= 60 && pd <= 64)
        {
            mediumPD.SetActive(true);
        }
        else if (pd >= 65 && pd <= 70)
        {
            largePD.SetActive(true);
        }

        // Display Measurements

        // Right
        SN.text = serialNumber.ToString("F0");
        NO.text = number.ToString("F0");
        VD.text = vd.ToString("F0");
        PD.text = pd.ToString("F0");

        RS1.text = RoundToQuarter(rs1).ToString("F2");
        RS2.text = RoundToQuarter(rs2).ToString("F2");
        RS3.text = RoundToQuarter(rs3).ToString("F2");
        RS_Take.text = RoundToQuarter(rsTake).ToString("F2");

        RC1.text = RoundToQuarter(rc1).ToString("F2");
        RC2.text = RoundToQuarter(rc2).ToString("F2");
        RC3.text = RoundToQuarter(rc3).ToString("F2");
        RC_Take.text = RoundToQuarter(rcTake).ToString("F2");

        RA1.text = ra1.ToString("F0");
        RA2.text = ra2.ToString("F0");
        RA3.text = ra3.ToString("F0");
        RA_Take.text = raTake.ToString("F0");

        SE_Right.text = RoundToQuarter(seRight).ToString("F2");

        // Left
        LS1.text = RoundToQuarter(ls1).ToString("F2");
        LS2.text = RoundToQuarter(ls2).ToString("F2");
        LS3.text = RoundToQuarter(ls3).ToString("F2");
        LS_Take.text = RoundToQuarter(lsTake).ToString("F2");

        LC1.text = RoundToQuarter(lc1).ToString("F2");
        LC2.text = RoundToQuarter(lc2).ToString("F2");
        LC3.text = RoundToQuarter(lc3).ToString("F2");
        LC_Take.text = RoundToQuarter(lcTake).ToString("F2");

        LA1.text = la1.ToString("F0");
        LA2.text = la2.ToString("F0");
        LA3.text = la3.ToString("F0");
        LA_Take.text = laTake.ToString("F0");

        SE_Left.text = RoundToQuarter(seLeft).ToString("F2");
    }

    // Rounds Number like S & C to .25, .50, .75, and .00
    private float RoundToQuarter(float value)
    {
        float roundedValue = Mathf.Round(value * 4) / 4;
        return roundedValue;
    }
}
