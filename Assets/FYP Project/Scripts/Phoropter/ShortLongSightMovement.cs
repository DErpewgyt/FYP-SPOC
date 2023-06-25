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

    public GameObject Leftneg1900;
    public GameObject Leftneg1875;
    public GameObject Leftneg1850;
    public GameObject Leftneg1825;
    public GameObject Leftneg1800;
    public GameObject Leftneg1775;
    public GameObject Leftneg1750;
    public GameObject Leftneg1725;
    public GameObject Leftneg1700;
    public GameObject Leftneg1675;
    public GameObject Leftneg1650;
    public GameObject Leftneg1625;
    public GameObject Leftneg1600;
    public GameObject Leftneg1575;
    public GameObject Leftneg1550;
    public GameObject Leftneg1525;
    public GameObject Leftneg1500;
    public GameObject Leftneg1475;
    public GameObject Leftneg1450;
    public GameObject Leftneg1425;
    public GameObject Leftneg1400;
    public GameObject Leftneg1375;
    public GameObject Leftneg1350;
    public GameObject Leftneg1325;
    public GameObject Leftneg1300;
    public GameObject Leftneg1275;
    public GameObject Leftneg1250;
    public GameObject Leftneg1225;
    public GameObject Leftneg1200;
    public GameObject Leftneg1175;
    public GameObject Leftneg1150;
    public GameObject Leftneg1125;
    public GameObject Leftneg1100;
    public GameObject Leftneg1075;
    public GameObject Leftneg1050;
    public GameObject Leftneg1025;
    public GameObject Leftneg1000;
    public GameObject Leftneg975;
    public GameObject Leftneg950;
    public GameObject Leftneg925;
    public GameObject Leftneg900;
    public GameObject Leftneg875;
    public GameObject Leftneg850;
    public GameObject Leftneg825;
    public GameObject Leftneg800;
    public GameObject Leftneg775;
    public GameObject Leftneg750;
    public GameObject Leftneg725;
    public GameObject Leftneg700;
    public GameObject Leftneg675;
    public GameObject Leftneg650;
    public GameObject Leftneg625;
    public GameObject Leftneg600;
    public GameObject Leftneg575;
    public GameObject Leftneg550;
    public GameObject Leftneg525;
    public GameObject Leftneg500;
    public GameObject Leftneg475;
    public GameObject Leftneg450;
    public GameObject Leftneg425;
    public GameObject Leftneg400;
    public GameObject Leftneg375;
    public GameObject Leftneg350;
    public GameObject Leftneg325;
    public GameObject Leftneg300;
    public GameObject Leftneg275;
    public GameObject Leftneg250;
    public GameObject Leftneg225;
    public GameObject Leftneg200;
    public GameObject Leftneg175;
    public GameObject Leftneg150;
    public GameObject Leftneg125;
    public GameObject Leftneg100;
    public GameObject Leftneg75;
    public GameObject Leftneg50;
    public GameObject Leftneg25;

    public GameObject Leftpos0;
    
    public GameObject Leftpos25;
    public GameObject Leftpos50;
    public GameObject Leftpos75;
    public GameObject Leftpos100;
    public GameObject Leftpos125;
    public GameObject Leftpos150;
    public GameObject Leftpos175;
    public GameObject Leftpos200;
    public GameObject Leftpos225;
    public GameObject Leftpos250;
    public GameObject Leftpos275;
    public GameObject Leftpos300;
    public GameObject Leftpos325;
    public GameObject Leftpos350;
    public GameObject Leftpos375;
    public GameObject Leftpos400;
    public GameObject Leftpos425;
    public GameObject Leftpos450;
    public GameObject Leftpos475;
    public GameObject Leftpos500;
    public GameObject Leftpos525;
    public GameObject Leftpos550;
    public GameObject Leftpos575;
    public GameObject Leftpos600;
    public GameObject Leftpos625;
    public GameObject Leftpos650;
    public GameObject Leftpos675;
    public GameObject Leftpos700;
    public GameObject Leftpos725;
    public GameObject Leftpos750;
    public GameObject Leftpos775;
    public GameObject Leftpos800;
    public GameObject Leftpos825;
    public GameObject Leftpos850;
    public GameObject Leftpos875;
    public GameObject Leftpos900;
    public GameObject Leftpos925;
    public GameObject Leftpos950;
    public GameObject Leftpos975;
    public GameObject Leftpos1000;
    public GameObject Leftpos1025;
    public GameObject Leftpos1050;
    public GameObject Leftpos1075;
    public GameObject Leftpos1100;
    public GameObject Leftpos1125;
    public GameObject Leftpos1150;
    public GameObject Leftpos1175;
    public GameObject Leftpos1200;
    public GameObject Leftpos1225;
    public GameObject Leftpos1250;
    public GameObject Leftpos1275;
    public GameObject Leftpos1300;
    public GameObject Leftpos1325;
    public GameObject Leftpos1350;
    public GameObject Leftpos1375;
    public GameObject Leftpos1400;
    public GameObject Leftpos1425;
    public GameObject Leftpos1450;
    public GameObject Leftpos1475;
    public GameObject Leftpos1500;
    public GameObject Leftpos1525;
    public GameObject Leftpos1550;
    public GameObject Leftpos1575;
    public GameObject Leftpos1600;
    public GameObject Leftpos1625;
    public GameObject Leftpos1650;
    public GameObject Leftpos1675;





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
        disableAll();
        switch (LSvalues)
        {

            case (float)-19:
                Leftneg1900.SetActive(true);
                break;


            case (float)-18.75:
                Leftneg1875.SetActive(true);
                break;


            case (float)-18.5:
                Leftneg1850.SetActive(true);
                break;


            case (float)-18.25:
                Leftneg1825.SetActive(true);
                break;


            case (float)-18:
                Leftneg1800.SetActive(true);
                break;


            case (float)-17.75:
                Leftneg1775.SetActive(true);
                break;


            case (float)-17.5:
                Leftneg1750.SetActive(true);
                break;


            case (float)-17.25:
                Leftneg1725.SetActive(true);
                break;


            case (float)-17:
                Leftneg1700.SetActive(true);
                break;


            case (float)-16.75:
                Leftneg1675.SetActive(true);
                break;


            case (float)-16.5:
                Leftneg1650.SetActive(true);
                break;


            case (float)-16.25:
                Leftneg1625.SetActive(true);
                break;


            case (float)-16:
                Leftneg1600.SetActive(true);
                break;


            case (float)-15.75:
                Leftneg1575.SetActive(true);
                break;


            case (float)-15.5:
                Leftneg1550.SetActive(true);
                break;


            case (float)-15.25:
                Leftneg1525.SetActive(true);
                break;


            case (float)-15:
                Leftneg1500.SetActive(true);
                break;


            case (float)-14.75:
                Leftneg1475.SetActive(true);
                break;


            case (float)-14.5:
                Leftneg1450.SetActive(true);
                break;


            case (float)-14.25:
                Leftneg1425.SetActive(true);
                break;


            case (float)-14:
                Leftneg1400.SetActive(true);
                break;


            case (float)-13.75:
                Leftneg1375.SetActive(true);
                break;


            case (float)-13.5:
                Leftneg1350.SetActive(true);
                break;


            case (float)-13.25:
                Leftneg1325.SetActive(true);
                break;


            case (float)-13:
                Leftneg1300.SetActive(true);
                break;


            case (float)-12.75:
                Leftneg1275.SetActive(true);
                break;


            case (float)-12.5:
                Leftneg1250.SetActive(true);
                break;


            case (float)-12.25:
                Leftneg1225.SetActive(true);
                break;


            case (float)-12:
                Leftneg1200.SetActive(true);
                break;


            case (float)-11.75:
                Leftneg1175.SetActive(true);
                break;


            case (float)-11.5:
                Leftneg1150.SetActive(true);
                break;


            case (float)-11.25:
                Leftneg1125.SetActive(true);
                break;


            case (float)-11:
                Leftneg1100.SetActive(true);
                break;


            case (float)-10.75:
                Leftneg1075.SetActive(true);
                break;


            case (float)-10.5:
                Leftneg1050.SetActive(true);
                break;


            case (float)-10.25:
                Leftneg1025.SetActive(true);
                break;


            case (float)-10:
                Leftneg1000.SetActive(true);
                break;


            case (float)-9.75:
                Leftneg975.SetActive(true);
                break;


            case (float)-9.5:
                Leftneg950.SetActive(true);
                break;


            case (float)-9.25:
                Leftneg925.SetActive(true);
                break;


            case (float)-9:
                Leftneg900.SetActive(true);
                break;


            case (float)-8.75:
                Leftneg875.SetActive(true);
                break;


            case (float)-8.5:
                Leftneg850.SetActive(true);
                break;


            case (float)-8.25:
                Leftneg825.SetActive(true);
                break;


            case (float)-8:
                Leftneg800.SetActive(true);
                break;


            case (float)-7.75:
                Leftneg775.SetActive(true);
                break;


            case (float)-7.5:
                Leftneg750.SetActive(true);
                break;


            case (float)-7.25:
                Leftneg725.SetActive(true);
                break;


            case (float)-7:
                Leftneg700.SetActive(true);
                break;


            case (float)-6.75:
                Leftneg675.SetActive(true);
                break;


            case (float)-6.5:
                Leftneg650.SetActive(true);
                break;


            case (float)-6.25:
                Leftneg625.SetActive(true);
                break;


            case (float)-6:
                Leftneg600.SetActive(true);
                break;


            case (float)-5.75:
                Leftneg575.SetActive(true);
                break;


            case (float)-5.5:
                Leftneg550.SetActive(true);
                break;


            case (float)-5.25:
                Leftneg525.SetActive(true);
                break;


            case (float)-5:
                Leftneg500.SetActive(true);
                break;


            case (float)-4.75:
                Leftneg475.SetActive(true);
                break;


            case (float)-4.5:
                Leftneg450.SetActive(true);
                break;


            case (float)-4.25:
                Leftneg425.SetActive(true);
                break;


            case (float)-4:
                Leftneg400.SetActive(true);
                break;


            case (float)-3.75:
                Leftneg375.SetActive(true);
                break;


            case (float)-3.5:
                Leftneg350.SetActive(true);
                break;


            case (float)-3.25:
                Leftneg325.SetActive(true);
                break;


            case (float)-3:
                Leftneg300.SetActive(true);
                break;


            case (float)-2.75:
                Leftneg275.SetActive(true);
                break;


            case (float)-2.5:
                Leftneg250.SetActive(true);
                break;


            case (float)-2.25:
                Leftneg225.SetActive(true);
                break;


            case (float)-2:
                Leftneg200.SetActive(true);
                break;


            case (float)-1.75:
                Leftneg175.SetActive(true);
                break;


            case (float)-1.5:
                Leftneg150.SetActive(true);
                break;


            case (float)-1.25:
                Leftneg125.SetActive(true);
                break;


            case (float)-1:
                Leftneg100.SetActive(true);
                break;


            case (float)-0.75:
                Leftneg75.SetActive(true);
                break;


            case (float)-0.5:
                Leftneg50.SetActive(true);
                break;


            case (float)-0.25:
                Leftneg25.SetActive(true);
                break;


            case (float)0:
                Leftpos0.SetActive(true);
                break;


            case (float)0.25:
                Leftpos25.SetActive(true);
                break;


            case (float)0.5:
                Leftpos50.SetActive(true);
                break;


            case (float)0.75:
                Leftpos75.SetActive(true);
                break;


            case (float)1:
                Leftpos100.SetActive(true);
                break;


            case (float)1.25:
                Leftpos125.SetActive(true);
                break;


            case (float)1.5:
                Leftpos150.SetActive(true);
                break;


            case (float)1.75:
                Leftpos175.SetActive(true);
                break;


            case (float)2:
                Leftpos200.SetActive(true);
                break;


            case (float)2.25:
                Leftpos225.SetActive(true);
                break;


            case (float)2.5:
                Leftpos250.SetActive(true);
                break;


            case (float)2.75:
                Leftpos275.SetActive(true);
                break;


            case (float)3:
                Leftpos300.SetActive(true);
                break;


            case (float)3.25:
                Leftpos325.SetActive(true);
                break;


            case (float)3.5:
                Leftpos350.SetActive(true);
                break;


            case (float)3.75:
                Leftpos375.SetActive(true);
                break;


            case (float)4:
                Leftpos400.SetActive(true);
                break;


            case (float)4.25:
                Leftpos425.SetActive(true);
                break;


            case (float)4.5:
                Leftpos450.SetActive(true);
                break;


            case (float)4.75:
                Leftpos475.SetActive(true);
                break;


            case (float)5:
                Leftpos500.SetActive(true);
                break;


            case (float)5.25:
                Leftpos525.SetActive(true);
                break;


            case (float)5.5:
                Leftpos550.SetActive(true);
                break;


            case (float)5.75:
                Leftpos575.SetActive(true);
                break;


            case (float)6:
                Leftpos600.SetActive(true);
                break;


            case (float)6.25:
                Leftpos625.SetActive(true);
                break;


            case (float)6.5:
                Leftpos650.SetActive(true);
                break;


            case (float)6.75:
                Leftpos675.SetActive(true);
                break;


            case (float)7:
                Leftpos700.SetActive(true);
                break;


            case (float)7.25:
                Leftpos725.SetActive(true);
                break;


            case (float)7.5:
                Leftpos750.SetActive(true);
                break;


            case (float)7.75:
                Leftpos775.SetActive(true);
                break;


            case (float)8:
                Leftpos800.SetActive(true);
                break;


            case (float)8.25:
                Leftpos825.SetActive(true);
                break;


            case (float)8.5:
                Leftpos850.SetActive(true);
                break;


            case (float)8.75:
                Leftpos875.SetActive(true);
                break;


            case (float)9:
                Leftpos900.SetActive(true);
                break;


            case (float)9.25:
                Leftpos925.SetActive(true);
                break;


            case (float)9.5:
                Leftpos950.SetActive(true);
                break;


            case (float)9.75:
                Leftpos975.SetActive(true);
                break;


            case (float)10:
                Leftpos1000.SetActive(true);
                break;


            case (float)10.25:
                Leftpos1025.SetActive(true);
                break;


            case (float)10.5:
                Leftpos1050.SetActive(true);
                break;


            case (float)10.75:
                Leftpos1075.SetActive(true);
                break;


            case (float)11:
                Leftpos1100.SetActive(true);
                break;


            case (float)11.25:
                Leftpos1125.SetActive(true);
                break;


            case (float)11.5:
                Leftpos1150.SetActive(true);
                break;


            case (float)11.75:
                Leftpos1175.SetActive(true);
                break;


            case (float)12:
                Leftpos1200.SetActive(true);
                break;


            case (float)12.25:
                Leftpos1225.SetActive(true);
                break;


            case (float)12.5:
                Leftpos1250.SetActive(true);
                break;


            case (float)12.75:
                Leftpos1275.SetActive(true);
                break;


            case (float)13:
                Leftpos1300.SetActive(true);
                break;


            case (float)13.25:
                Leftpos1325.SetActive(true);
                break;


            case (float)13.5:
                Leftpos1350.SetActive(true);
                break;


            case (float)13.75:
                Leftpos1375.SetActive(true);
                break;


            case (float)14:
                Leftpos1400.SetActive(true);
                break;


            case (float)14.25:
                Leftpos1425.SetActive(true);
                break;


            case (float)14.5:
                Leftpos1450.SetActive(true);
                break;


            case (float)14.75:
                Leftpos1475.SetActive(true);
                break;


            case (float)15:
                Leftpos1500.SetActive(true);
                break;


            case (float)15.25:
                Leftpos1525.SetActive(true);
                break;


            case (float)15.5:
                Leftpos1550.SetActive(true);
                break;


            case (float)15.75:
                Leftpos1575.SetActive(true);
                break;


            case (float)16:
                Leftpos1600.SetActive(true);
                break;


            case (float)16.25:
                Leftpos1625.SetActive(true);
                break;


            case (float)16.5:
                Leftpos1650.SetActive(true);
                break;


            case (float)16.75:
                Leftpos1675.SetActive(true);
                break;

        }


        if (LSvalues < 0f)
        {
            valueText.color = Color.red;
        }
        else
        {
            valueText.color = Color.black;
        }



    }

    private void disableAll()
    {
        Leftneg1900.SetActive(false);
        Leftneg1875.SetActive(false);
        Leftneg1850.SetActive(false);
        Leftneg1825.SetActive(false);
        Leftneg1800.SetActive(false);
        Leftneg1775.SetActive(false);
        Leftneg1750.SetActive(false);
        Leftneg1725.SetActive(false);
        Leftneg1700.SetActive(false);
        Leftneg1675.SetActive(false);
        Leftneg1650.SetActive(false);
        Leftneg1625.SetActive(false);
        Leftneg1600.SetActive(false);
        Leftneg1575.SetActive(false);
        Leftneg1550.SetActive(false);
        Leftneg1525.SetActive(false);
        Leftneg1500.SetActive(false);
        Leftneg1475.SetActive(false);
        Leftneg1450.SetActive(false);
        Leftneg1425.SetActive(false);
        Leftneg1400.SetActive(false);
        Leftneg1375.SetActive(false);
        Leftneg1350.SetActive(false);
        Leftneg1325.SetActive(false);
        Leftneg1300.SetActive(false);
        Leftneg1275.SetActive(false);
        Leftneg1250.SetActive(false);
        Leftneg1225.SetActive(false);
        Leftneg1200.SetActive(false);
        Leftneg1175.SetActive(false);
        Leftneg1150.SetActive(false);
        Leftneg1125.SetActive(false);
        Leftneg1100.SetActive(false);
        Leftneg1075.SetActive(false);
        Leftneg1050.SetActive(false);
        Leftneg1025.SetActive(false);
        Leftneg1000.SetActive(false);
        Leftneg975.SetActive(false);
        Leftneg950.SetActive(false);
        Leftneg925.SetActive(false);
        Leftneg900.SetActive(false);
        Leftneg875.SetActive(false);
        Leftneg850.SetActive(false);
        Leftneg825.SetActive(false);
        Leftneg800.SetActive(false);
        Leftneg775.SetActive(false);
        Leftneg750.SetActive(false);
        Leftneg725.SetActive(false);
        Leftneg700.SetActive(false);
        Leftneg675.SetActive(false);
        Leftneg650.SetActive(false);
        Leftneg625.SetActive(false);
        Leftneg600.SetActive(false);
        Leftneg575.SetActive(false);
        Leftneg550.SetActive(false);
        Leftneg525.SetActive(false);
        Leftneg500.SetActive(false);
        Leftneg475.SetActive(false);
        Leftneg450.SetActive(false);
        Leftneg425.SetActive(false);
        Leftneg400.SetActive(false);
        Leftneg375.SetActive(false);
        Leftneg350.SetActive(false);
        Leftneg325.SetActive(false);
        Leftneg300.SetActive(false);
        Leftneg275.SetActive(false);
        Leftneg250.SetActive(false);
        Leftneg225.SetActive(false);
        Leftneg200.SetActive(false);
        Leftneg175.SetActive(false);
        Leftneg150.SetActive(false);
        Leftneg125.SetActive(false);
        Leftneg100.SetActive(false);
        Leftneg75.SetActive(false);
        Leftneg50.SetActive(false);
        Leftneg25.SetActive(false);
        Leftpos0.SetActive(false);
        Leftpos25.SetActive(false);
        Leftpos50.SetActive(false);
        Leftpos75.SetActive(false);
        Leftpos100.SetActive(false);
        Leftpos125.SetActive(false);
        Leftpos150.SetActive(false);
        Leftpos175.SetActive(false);
        Leftpos200.SetActive(false);
        Leftpos225.SetActive(false);
        Leftpos250.SetActive(false);
        Leftpos275.SetActive(false);
        Leftpos300.SetActive(false);
        Leftpos325.SetActive(false);
        Leftpos350.SetActive(false);
        Leftpos375.SetActive(false);
        Leftpos400.SetActive(false);
        Leftpos425.SetActive(false);
        Leftpos450.SetActive(false);
        Leftpos475.SetActive(false);
        Leftpos500.SetActive(false);
        Leftpos525.SetActive(false);
        Leftpos550.SetActive(false);
        Leftpos575.SetActive(false);
        Leftpos600.SetActive(false);
        Leftpos625.SetActive(false);
        Leftpos650.SetActive(false);
        Leftpos675.SetActive(false);
        Leftpos700.SetActive(false);
        Leftpos725.SetActive(false);
        Leftpos750.SetActive(false);
        Leftpos775.SetActive(false);
        Leftpos800.SetActive(false);
        Leftpos825.SetActive(false);
        Leftpos850.SetActive(false);
        Leftpos875.SetActive(false);
        Leftpos900.SetActive(false);
        Leftpos925.SetActive(false);
        Leftpos950.SetActive(false);
        Leftpos975.SetActive(false);
        Leftpos1000.SetActive(false);
        Leftpos1025.SetActive(false);
        Leftpos1050.SetActive(false);
        Leftpos1075.SetActive(false);
        Leftpos1100.SetActive(false);
        Leftpos1125.SetActive(false);
        Leftpos1150.SetActive(false);
        Leftpos1175.SetActive(false);
        Leftpos1200.SetActive(false);
        Leftpos1225.SetActive(false);
        Leftpos1250.SetActive(false);
        Leftpos1275.SetActive(false);
        Leftpos1300.SetActive(false);
        Leftpos1325.SetActive(false);
        Leftpos1350.SetActive(false);
        Leftpos1375.SetActive(false);
        Leftpos1400.SetActive(false);
        Leftpos1425.SetActive(false);
        Leftpos1450.SetActive(false);
        Leftpos1475.SetActive(false);
        Leftpos1500.SetActive(false);
        Leftpos1525.SetActive(false);
        Leftpos1550.SetActive(false);
        Leftpos1575.SetActive(false);
        Leftpos1600.SetActive(false);
        Leftpos1625.SetActive(false);
        Leftpos1650.SetActive(false);
        Leftpos1675.SetActive(false);
    }
}
