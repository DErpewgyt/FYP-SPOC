using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeasureReadings : MonoBehaviour
{
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

    void Start()
    {
        // Serial Number & Number & VD & PD
        float serialNumber = Random.Range(1000f, 600000f);
        float number = Random.Range(0f, 6000f);
        float vd = Random.Range(10f, 14f);
        float pd = Random.Range(54f, 74f);

        /******************************************************************************************/

        // Right Power (S)
        float rs1 = Random.Range(-19.00f, 16.75f);
        float rs2 = rs1;
        float rs3 = rs1;
        float rsTake = rs1;

        // Right Astigmatism (C)
        float rc1 = Random.Range(0.00f, 6.00f);
        float rc2 = rc1;
        float rc3 = rc1;
        float rcTake = rc1;

        // Right Axis-Astigmatism (A)
        float ra1 = Random.Range(0f, 180f);
        float ra2 = ra1 - 1f;
        float ra3 = ra1 - 3f;
        float raTake = Mathf.Ceil((ra1 + ra2 + ra3) / 3f);

        // Right Spherical Equivalent (SE)
        float seRight = rs1 + (rc1 / 2f);

        /******************************************************************************************/

        // Left Power (S)
        float ls1 = Random.Range(-19.00f, 16.75f);
        float ls2 = ls1;
        float ls3 = ls1;
        float lsTake = ls1;

        // Left Astigmatism (C)
        float lc1 = Random.Range(0.00f, 6.00f);
        float lc2 = lc1;
        float lc3 = lc1;
        float lcTake = lc1;

        // Left Axis-Astigmatism (A)
        float la1 = Random.Range(0f, 180f);
        float la2 = la1 - 1f;
        float la3 = la1 - 3f;
        float laTake = Mathf.Ceil((la1 + la2 + la3) / 3f);

        // Left Spherical Equivalent (SE)
        float seLeft = ls1 + (lc1 / 2f);

        /******************************************************************************************/

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
