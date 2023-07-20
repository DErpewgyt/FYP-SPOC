using TMPro;
using UnityEngine;

public class ShortLongSightMovement : MonoBehaviour
{
    public TextMeshProUGUI RightValue;
    public TextMeshProUGUI LeftValue;

    public float LSLeft;
    public float LSRight;

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

    public GameObject TopLeftGroup;

    public GameObject TopLeftneg1900;
    public GameObject TopLeftneg1875;
    public GameObject TopLeftneg1850;
    public GameObject TopLeftneg1825;
    public GameObject TopLeftneg1800;
    public GameObject TopLeftneg1775;
    public GameObject TopLeftneg1750;
    public GameObject TopLeftneg1725;
    public GameObject TopLeftneg1700;
    public GameObject TopLeftneg1675;
    public GameObject TopLeftneg1650;
    public GameObject TopLeftneg1625;
    public GameObject TopLeftneg1600;
    public GameObject TopLeftneg1575;
    public GameObject TopLeftneg1550;
    public GameObject TopLeftneg1525;
    public GameObject TopLeftneg1500;
    public GameObject TopLeftneg1475;
    public GameObject TopLeftneg1450;
    public GameObject TopLeftneg1425;
    public GameObject TopLeftneg1400;
    public GameObject TopLeftneg1375;
    public GameObject TopLeftneg1350;
    public GameObject TopLeftneg1325;
    public GameObject TopLeftneg1300;
    public GameObject TopLeftneg1275;
    public GameObject TopLeftneg1250;
    public GameObject TopLeftneg1225;
    public GameObject TopLeftneg1200;
    public GameObject TopLeftneg1175;
    public GameObject TopLeftneg1150;
    public GameObject TopLeftneg1125;
    public GameObject TopLeftneg1100;
    public GameObject TopLeftneg1075;
    public GameObject TopLeftneg1050;
    public GameObject TopLeftneg1025;
    public GameObject TopLeftneg1000;
    public GameObject TopLeftneg975;
    public GameObject TopLeftneg950;
    public GameObject TopLeftneg925;
    public GameObject TopLeftneg900;
    public GameObject TopLeftneg875;
    public GameObject TopLeftneg850;
    public GameObject TopLeftneg825;
    public GameObject TopLeftneg800;
    public GameObject TopLeftneg775;
    public GameObject TopLeftneg750;
    public GameObject TopLeftneg725;
    public GameObject TopLeftneg700;
    public GameObject TopLeftneg675;
    public GameObject TopLeftneg650;
    public GameObject TopLeftneg625;
    public GameObject TopLeftneg600;
    public GameObject TopLeftneg575;
    public GameObject TopLeftneg550;
    public GameObject TopLeftneg525;
    public GameObject TopLeftneg500;
    public GameObject TopLeftneg475;
    public GameObject TopLeftneg450;
    public GameObject TopLeftneg425;
    public GameObject TopLeftneg400;
    public GameObject TopLeftneg375;
    public GameObject TopLeftneg350;
    public GameObject TopLeftneg325;
    public GameObject TopLeftneg300;
    public GameObject TopLeftneg275;
    public GameObject TopLeftneg250;
    public GameObject TopLeftneg225;
    public GameObject TopLeftneg200;
    public GameObject TopLeftneg175;
    public GameObject TopLeftneg150;
    public GameObject TopLeftneg125;
    public GameObject TopLeftneg100;
    public GameObject TopLeftneg75;
    public GameObject TopLeftneg50;
    public GameObject TopLeftneg25;

    public GameObject TopLeftpos0;

    public GameObject TopLeftpos25;
    public GameObject TopLeftpos50;
    public GameObject TopLeftpos75;
    public GameObject TopLeftpos100;
    public GameObject TopLeftpos125;
    public GameObject TopLeftpos150;
    public GameObject TopLeftpos175;
    public GameObject TopLeftpos200;
    public GameObject TopLeftpos225;
    public GameObject TopLeftpos250;
    public GameObject TopLeftpos275;
    public GameObject TopLeftpos300;
    public GameObject TopLeftpos325;
    public GameObject TopLeftpos350;
    public GameObject TopLeftpos375;
    public GameObject TopLeftpos400;
    public GameObject TopLeftpos425;
    public GameObject TopLeftpos450;
    public GameObject TopLeftpos475;
    public GameObject TopLeftpos500;
    public GameObject TopLeftpos525;
    public GameObject TopLeftpos550;
    public GameObject TopLeftpos575;
    public GameObject TopLeftpos600;
    public GameObject TopLeftpos625;
    public GameObject TopLeftpos650;
    public GameObject TopLeftpos675;
    public GameObject TopLeftpos700;
    public GameObject TopLeftpos725;
    public GameObject TopLeftpos750;
    public GameObject TopLeftpos775;
    public GameObject TopLeftpos800;
    public GameObject TopLeftpos825;
    public GameObject TopLeftpos850;
    public GameObject TopLeftpos875;
    public GameObject TopLeftpos900;
    public GameObject TopLeftpos925;
    public GameObject TopLeftpos950;
    public GameObject TopLeftpos975;
    public GameObject TopLeftpos1000;
    public GameObject TopLeftpos1025;
    public GameObject TopLeftpos1050;
    public GameObject TopLeftpos1075;
    public GameObject TopLeftpos1100;
    public GameObject TopLeftpos1125;
    public GameObject TopLeftpos1150;
    public GameObject TopLeftpos1175;
    public GameObject TopLeftpos1200;
    public GameObject TopLeftpos1225;
    public GameObject TopLeftpos1250;
    public GameObject TopLeftpos1275;
    public GameObject TopLeftpos1300;
    public GameObject TopLeftpos1325;
    public GameObject TopLeftpos1350;
    public GameObject TopLeftpos1375;
    public GameObject TopLeftpos1400;
    public GameObject TopLeftpos1425;
    public GameObject TopLeftpos1450;
    public GameObject TopLeftpos1475;
    public GameObject TopLeftpos1500;
    public GameObject TopLeftpos1525;
    public GameObject TopLeftpos1550;
    public GameObject TopLeftpos1575;
    public GameObject TopLeftpos1600;
    public GameObject TopLeftpos1625;
    public GameObject TopLeftpos1650;
    public GameObject TopLeftpos1675;

    //Right side

    public GameObject Rightneg1900;
    public GameObject Rightneg1875;
    public GameObject Rightneg1850;
    public GameObject Rightneg1825;
    public GameObject Rightneg1800;
    public GameObject Rightneg1775;
    public GameObject Rightneg1750;
    public GameObject Rightneg1725;
    public GameObject Rightneg1700;
    public GameObject Rightneg1675;
    public GameObject Rightneg1650;
    public GameObject Rightneg1625;
    public GameObject Rightneg1600;
    public GameObject Rightneg1575;
    public GameObject Rightneg1550;
    public GameObject Rightneg1525;
    public GameObject Rightneg1500;
    public GameObject Rightneg1475;
    public GameObject Rightneg1450;
    public GameObject Rightneg1425;
    public GameObject Rightneg1400;
    public GameObject Rightneg1375;
    public GameObject Rightneg1350;
    public GameObject Rightneg1325;
    public GameObject Rightneg1300;
    public GameObject Rightneg1275;
    public GameObject Rightneg1250;
    public GameObject Rightneg1225;
    public GameObject Rightneg1200;
    public GameObject Rightneg1175;
    public GameObject Rightneg1150;
    public GameObject Rightneg1125;
    public GameObject Rightneg1100;
    public GameObject Rightneg1075;
    public GameObject Rightneg1050;
    public GameObject Rightneg1025;
    public GameObject Rightneg1000;
    public GameObject Rightneg975;
    public GameObject Rightneg950;
    public GameObject Rightneg925;
    public GameObject Rightneg900;
    public GameObject Rightneg875;
    public GameObject Rightneg850;
    public GameObject Rightneg825;
    public GameObject Rightneg800;
    public GameObject Rightneg775;
    public GameObject Rightneg750;
    public GameObject Rightneg725;
    public GameObject Rightneg700;
    public GameObject Rightneg675;
    public GameObject Rightneg650;
    public GameObject Rightneg625;
    public GameObject Rightneg600;
    public GameObject Rightneg575;
    public GameObject Rightneg550;
    public GameObject Rightneg525;
    public GameObject Rightneg500;
    public GameObject Rightneg475;
    public GameObject Rightneg450;
    public GameObject Rightneg425;
    public GameObject Rightneg400;
    public GameObject Rightneg375;
    public GameObject Rightneg350;
    public GameObject Rightneg325;
    public GameObject Rightneg300;
    public GameObject Rightneg275;
    public GameObject Rightneg250;
    public GameObject Rightneg225;
    public GameObject Rightneg200;
    public GameObject Rightneg175;
    public GameObject Rightneg150;
    public GameObject Rightneg125;
    public GameObject Rightneg100;
    public GameObject Rightneg75;
    public GameObject Rightneg50;
    public GameObject Rightneg25;

    public GameObject Rightpos0;

    public GameObject Rightpos25;
    public GameObject Rightpos50;
    public GameObject Rightpos75;
    public GameObject Rightpos100;
    public GameObject Rightpos125;
    public GameObject Rightpos150;
    public GameObject Rightpos175;
    public GameObject Rightpos200;
    public GameObject Rightpos225;
    public GameObject Rightpos250;
    public GameObject Rightpos275;
    public GameObject Rightpos300;
    public GameObject Rightpos325;
    public GameObject Rightpos350;
    public GameObject Rightpos375;
    public GameObject Rightpos400;
    public GameObject Rightpos425;
    public GameObject Rightpos450;
    public GameObject Rightpos475;
    public GameObject Rightpos500;
    public GameObject Rightpos525;
    public GameObject Rightpos550;
    public GameObject Rightpos575;
    public GameObject Rightpos600;
    public GameObject Rightpos625;
    public GameObject Rightpos650;
    public GameObject Rightpos675;
    public GameObject Rightpos700;
    public GameObject Rightpos725;
    public GameObject Rightpos750;
    public GameObject Rightpos775;
    public GameObject Rightpos800;
    public GameObject Rightpos825;
    public GameObject Rightpos850;
    public GameObject Rightpos875;
    public GameObject Rightpos900;
    public GameObject Rightpos925;
    public GameObject Rightpos950;
    public GameObject Rightpos975;
    public GameObject Rightpos1000;
    public GameObject Rightpos1025;
    public GameObject Rightpos1050;
    public GameObject Rightpos1075;
    public GameObject Rightpos1100;
    public GameObject Rightpos1125;
    public GameObject Rightpos1150;
    public GameObject Rightpos1175;
    public GameObject Rightpos1200;
    public GameObject Rightpos1225;
    public GameObject Rightpos1250;
    public GameObject Rightpos1275;
    public GameObject Rightpos1300;
    public GameObject Rightpos1325;
    public GameObject Rightpos1350;
    public GameObject Rightpos1375;
    public GameObject Rightpos1400;
    public GameObject Rightpos1425;
    public GameObject Rightpos1450;
    public GameObject Rightpos1475;
    public GameObject Rightpos1500;
    public GameObject Rightpos1525;
    public GameObject Rightpos1550;
    public GameObject Rightpos1575;
    public GameObject Rightpos1600;
    public GameObject Rightpos1625;
    public GameObject Rightpos1650;
    public GameObject Rightpos1675;

    public GameObject TopRightGroup;

    public GameObject TopRightneg1900;
    public GameObject TopRightneg1875;
    public GameObject TopRightneg1850;
    public GameObject TopRightneg1825;
    public GameObject TopRightneg1800;
    public GameObject TopRightneg1775;
    public GameObject TopRightneg1750;
    public GameObject TopRightneg1725;
    public GameObject TopRightneg1700;
    public GameObject TopRightneg1675;
    public GameObject TopRightneg1650;
    public GameObject TopRightneg1625;
    public GameObject TopRightneg1600;
    public GameObject TopRightneg1575;
    public GameObject TopRightneg1550;
    public GameObject TopRightneg1525;
    public GameObject TopRightneg1500;
    public GameObject TopRightneg1475;
    public GameObject TopRightneg1450;
    public GameObject TopRightneg1425;
    public GameObject TopRightneg1400;
    public GameObject TopRightneg1375;
    public GameObject TopRightneg1350;
    public GameObject TopRightneg1325;
    public GameObject TopRightneg1300;
    public GameObject TopRightneg1275;
    public GameObject TopRightneg1250;
    public GameObject TopRightneg1225;
    public GameObject TopRightneg1200;
    public GameObject TopRightneg1175;
    public GameObject TopRightneg1150;
    public GameObject TopRightneg1125;
    public GameObject TopRightneg1100;
    public GameObject TopRightneg1075;
    public GameObject TopRightneg1050;
    public GameObject TopRightneg1025;
    public GameObject TopRightneg1000;
    public GameObject TopRightneg975;
    public GameObject TopRightneg950;
    public GameObject TopRightneg925;
    public GameObject TopRightneg900;
    public GameObject TopRightneg875;
    public GameObject TopRightneg850;
    public GameObject TopRightneg825;
    public GameObject TopRightneg800;
    public GameObject TopRightneg775;
    public GameObject TopRightneg750;
    public GameObject TopRightneg725;
    public GameObject TopRightneg700;
    public GameObject TopRightneg675;
    public GameObject TopRightneg650;
    public GameObject TopRightneg625;
    public GameObject TopRightneg600;
    public GameObject TopRightneg575;
    public GameObject TopRightneg550;
    public GameObject TopRightneg525;
    public GameObject TopRightneg500;
    public GameObject TopRightneg475;
    public GameObject TopRightneg450;
    public GameObject TopRightneg425;
    public GameObject TopRightneg400;
    public GameObject TopRightneg375;
    public GameObject TopRightneg350;
    public GameObject TopRightneg325;
    public GameObject TopRightneg300;
    public GameObject TopRightneg275;
    public GameObject TopRightneg250;
    public GameObject TopRightneg225;
    public GameObject TopRightneg200;
    public GameObject TopRightneg175;
    public GameObject TopRightneg150;
    public GameObject TopRightneg125;
    public GameObject TopRightneg100;
    public GameObject TopRightneg75;
    public GameObject TopRightneg50;
    public GameObject TopRightneg25;

    public GameObject TopRightpos0;

    public GameObject TopRightpos25;
    public GameObject TopRightpos50;
    public GameObject TopRightpos75;
    public GameObject TopRightpos100;
    public GameObject TopRightpos125;
    public GameObject TopRightpos150;
    public GameObject TopRightpos175;
    public GameObject TopRightpos200;
    public GameObject TopRightpos225;
    public GameObject TopRightpos250;
    public GameObject TopRightpos275;
    public GameObject TopRightpos300;
    public GameObject TopRightpos325;
    public GameObject TopRightpos350;
    public GameObject TopRightpos375;
    public GameObject TopRightpos400;
    public GameObject TopRightpos425;
    public GameObject TopRightpos450;
    public GameObject TopRightpos475;
    public GameObject TopRightpos500;
    public GameObject TopRightpos525;
    public GameObject TopRightpos550;
    public GameObject TopRightpos575;
    public GameObject TopRightpos600;
    public GameObject TopRightpos625;
    public GameObject TopRightpos650;
    public GameObject TopRightpos675;
    public GameObject TopRightpos700;
    public GameObject TopRightpos725;
    public GameObject TopRightpos750;
    public GameObject TopRightpos775;
    public GameObject TopRightpos800;
    public GameObject TopRightpos825;
    public GameObject TopRightpos850;
    public GameObject TopRightpos875;
    public GameObject TopRightpos900;
    public GameObject TopRightpos925;
    public GameObject TopRightpos950;
    public GameObject TopRightpos975;
    public GameObject TopRightpos1000;
    public GameObject TopRightpos1025;
    public GameObject TopRightpos1050;
    public GameObject TopRightpos1075;
    public GameObject TopRightpos1100;
    public GameObject TopRightpos1125;
    public GameObject TopRightpos1150;
    public GameObject TopRightpos1175;
    public GameObject TopRightpos1200;
    public GameObject TopRightpos1225;
    public GameObject TopRightpos1250;
    public GameObject TopRightpos1275;
    public GameObject TopRightpos1300;
    public GameObject TopRightpos1325;
    public GameObject TopRightpos1350;
    public GameObject TopRightpos1375;
    public GameObject TopRightpos1400;
    public GameObject TopRightpos1425;
    public GameObject TopRightpos1450;
    public GameObject TopRightpos1475;
    public GameObject TopRightpos1500;
    public GameObject TopRightpos1525;
    public GameObject TopRightpos1550;
    public GameObject TopRightpos1575;
    public GameObject TopRightpos1600;
    public GameObject TopRightpos1625;
    public GameObject TopRightpos1650;
    public GameObject TopRightpos1675;

    public GameObject LeftCheck;
    public GameObject RightCheck;

    public GameObject LeftKnob;
    public GameObject RightKnob;

    public GameObject LeftsideButtons;
    public GameObject RightSideButtons;

    public GameObject PaperBtn;

    public GameObject LeftsideShortCutKnob;
    public GameObject RightSideShortCutKnob;

    public float rotationSpeed = 100f;
    public float rotationamountShortCut = 20f;

    public AIVoiceChecker Checker;

    public GameObject leftSideFinalBtn; //patients right
    public GameObject leftSideFinalSubmitBtn;
    public GameObject rightSideFinalBtn; //patients left
    public GameObject rightSideFinalSubmitBtn;

    private void Start()
    {
        LeftLSSightBool = false;
        RightLSSightBool = false;

        LSLeft = 0;
        LSRight = 0;

        LeftsideButtons.SetActive(false);
        RightSideButtons.SetActive(false);
    }

    private void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (LeftLSSightBool)
        {
            LeftsideButtons.SetActive(true);
            RightSideButtons.SetActive(false);
            float rotationAmount = Input.mouseScrollDelta.y * rotationSpeed * Time.deltaTime;
            TopLeftGroup.SetActive(true);
            TopRightGroup.SetActive(false);

            if (Checker.isSetupComplete == true && Checker.isRightSideAstigAxisComplete == false)
            {
                LeftCheck.SetActive(true);
            }
            else if (Checker.isSetupComplete == true && Checker.isRightSideAstigAxisComplete == true)
            {
                leftSideFinalBtn.SetActive(true);
                leftSideFinalSubmitBtn.SetActive(true);
            }

            if (scrollInput != 0f)
            {
                LSLeft += Mathf.Sign(scrollInput) * 0.25f;
                LSLeft = Mathf.Clamp(LSLeft, -19f, 16.75f);

                if (LSLeft != -19f && LSLeft != 16.75f)
                {
                    RotateObjectTransform(LeftKnob, rotationAmount);
                }
                UpdateValue(LeftValue, LSLeft);
            }
        }

        if (RightLSSightBool)
        {
            RightSideButtons.SetActive(true);
            LeftsideButtons.SetActive(false);
            float rotationAmount = Input.mouseScrollDelta.y * rotationSpeed * Time.deltaTime;
            TopLeftGroup.SetActive(false);
            TopRightGroup.SetActive(true);

            if (Checker.isRightSideFinalComplete == true && Checker.isLeftSideAstigAxisComplete == false)
            {
                RightCheck.SetActive(true);
            }
            else if (Checker.isRightSideFinalComplete == true && Checker.isLeftSideAstigAxisComplete == true)
            {
                rightSideFinalBtn.SetActive(true);
                rightSideFinalSubmitBtn.SetActive(true);
            }

            if (scrollInput != 0f)
            {
                LSRight += Mathf.Sign(scrollInput) * 0.25f;
                LSRight = Mathf.Clamp(LSRight, -19f, 16.75f);

                if (LSRight != -19f && LSRight != 16.75f)
                {
                    RotateObjectTransform(RightKnob, -rotationAmount);
                }

                UpdateValue(RightValue, LSRight);
            }
        }

        if (!LeftLSSightBool && !RightLSSightBool)
        {
            TopLeftGroup.SetActive(false);
            TopRightGroup.SetActive(false);

            RightSideButtons.SetActive(false);
            LeftsideButtons.SetActive(false);
        }
    }

    public void Add3ToLeftside()
    {
        if (LSLeft < 14f)
        {
            float rotationAmount = rotationamountShortCut;
            LSLeft += 3;
            UpdateValue(LeftValue, LSLeft);
            RotateObject(LeftsideShortCutKnob, -rotationAmount);
        }
    }

    public void Subtract3ToLeftside()
    {
        if (LSLeft > -16.25f)
        {
            float rotationAmount = -rotationamountShortCut;
            LSLeft -= 3;
            UpdateValue(LeftValue, LSLeft);
            RotateObject(LeftsideShortCutKnob, rotationAmount);
        }
    }

    public void Add3ToRightside()
    {
        if (LSRight < 14f)
        {
            float rotationAmount = rotationamountShortCut;
            LSRight += 3;
            UpdateValue(RightValue, LSRight);
            RotateObject(RightSideShortCutKnob, -rotationAmount);
        }
    }

    public void Subtract3ToRightside()
    {
        if (LSRight > -16.25f)
        {
            float rotationAmount = -rotationamountShortCut;
            LSRight -= 3;
            UpdateValue(RightValue, LSRight);
            RotateObject(RightSideShortCutKnob, rotationAmount);
        }
    }

    private void RotateObjectTransform(GameObject obj, float rotationAmount)
    {
        // Get the object's position
        Vector3 center = obj.transform.position;
        print("GetRotatedTransform");
        // Calculate the rotation axis as the object's up vector
        Vector3 rotationAxis = obj.transform.up;

        // Rotate the object around its center for the Y-axis
        obj.transform.RotateAround(center, rotationAxis, rotationAmount);
    }

    private void RotateObject(GameObject obj, float rotationAmount)
    {
        // Get the object's position
        Vector3 center = obj.GetComponent<Renderer>().bounds.center;

        // Calculate the rotation axis as the object's up vector
        Vector3 rotationAxis = obj.transform.up;

        // Rotate the object around its center for the Y-axis
        obj.transform.RotateAround(center, rotationAxis, rotationAmount);
    }

    private void UpdateValue(TextMeshProUGUI valueText, float LSvalues)
    {
        valueText.text = LSvalues.ToString("F2");

        if (LeftLSSightBool)
        {
            disableLeft();
            switch (LSvalues)
            {
                case (float)-19:
                    TopLeftneg1900.SetActive(true);
                    Leftneg1900.SetActive(true);
                    break;

                case (float)-18.75:
                    TopLeftneg1875.SetActive(true);
                    Leftneg1875.SetActive(true);
                    break;

                case (float)-18.5:
                    TopLeftneg1850.SetActive(true);
                    Leftneg1850.SetActive(true);
                    break;

                case (float)-18.25:
                    TopLeftneg1825.SetActive(true);
                    Leftneg1825.SetActive(true);
                    break;

                case (float)-18:
                    TopLeftneg1800.SetActive(true);
                    Leftneg1800.SetActive(true);
                    break;

                case (float)-17.75:
                    TopLeftneg1775.SetActive(true);
                    Leftneg1775.SetActive(true);
                    break;

                case (float)-17.5:
                    TopLeftneg1750.SetActive(true);
                    Leftneg1750.SetActive(true);
                    break;

                case (float)-17.25:
                    TopLeftneg1725.SetActive(true);
                    Leftneg1725.SetActive(true);
                    break;

                case (float)-17:
                    TopLeftneg1700.SetActive(true);
                    Leftneg1700.SetActive(true);
                    break;

                case (float)-16.75:
                    TopLeftneg1675.SetActive(true);
                    Leftneg1675.SetActive(true);
                    break;

                case (float)-16.5:
                    TopLeftneg1650.SetActive(true);
                    Leftneg1650.SetActive(true);
                    break;

                case (float)-16.25:
                    TopLeftneg1625.SetActive(true);
                    Leftneg1625.SetActive(true);
                    break;

                case (float)-16:
                    TopLeftneg1600.SetActive(true);
                    Leftneg1600.SetActive(true);
                    break;

                case (float)-15.75:
                    TopLeftneg1575.SetActive(true);
                    Leftneg1575.SetActive(true);
                    break;

                case (float)-15.5:
                    TopLeftneg1550.SetActive(true);
                    Leftneg1550.SetActive(true);
                    break;

                case (float)-15.25:
                    TopLeftneg1525.SetActive(true);
                    Leftneg1525.SetActive(true);
                    break;

                case (float)-15:
                    TopLeftneg1500.SetActive(true);
                    Leftneg1500.SetActive(true);
                    break;

                case (float)-14.75:
                    TopLeftneg1475.SetActive(true);
                    Leftneg1475.SetActive(true);
                    break;

                case (float)-14.5:
                    TopLeftneg1450.SetActive(true);
                    Leftneg1450.SetActive(true);
                    break;

                case (float)-14.25:
                    TopLeftneg1425.SetActive(true);
                    Leftneg1425.SetActive(true);
                    break;

                case (float)-14:
                    TopLeftneg1400.SetActive(true);
                    Leftneg1400.SetActive(true);
                    break;

                case (float)-13.75:
                    TopLeftneg1375.SetActive(true);
                    Leftneg1375.SetActive(true);
                    break;

                case (float)-13.5:
                    TopLeftneg1350.SetActive(true);
                    Leftneg1350.SetActive(true);
                    break;

                case (float)-13.25:
                    TopLeftneg1325.SetActive(true);
                    Leftneg1325.SetActive(true);
                    break;

                case (float)-13:
                    TopLeftneg1300.SetActive(true);
                    Leftneg1300.SetActive(true);
                    break;

                case (float)-12.75:
                    TopLeftneg1275.SetActive(true);
                    Leftneg1275.SetActive(true);
                    break;

                case (float)-12.5:
                    TopLeftneg1250.SetActive(true);
                    Leftneg1250.SetActive(true);
                    break;

                case (float)-12.25:
                    TopLeftneg1225.SetActive(true);
                    Leftneg1225.SetActive(true);
                    break;

                case (float)-12:
                    TopLeftneg1200.SetActive(true);
                    Leftneg1200.SetActive(true);
                    break;

                case (float)-11.75:
                    TopLeftneg1175.SetActive(true);
                    Leftneg1175.SetActive(true);
                    break;

                case (float)-11.5:
                    TopLeftneg1150.SetActive(true);
                    Leftneg1150.SetActive(true);
                    break;

                case (float)-11.25:
                    TopLeftneg1125.SetActive(true);
                    Leftneg1125.SetActive(true);
                    break;

                case (float)-11:
                    TopLeftneg1100.SetActive(true);
                    Leftneg1100.SetActive(true);
                    break;

                case (float)-10.75:
                    TopLeftneg1075.SetActive(true);
                    Leftneg1075.SetActive(true);
                    break;

                case (float)-10.5:
                    TopLeftneg1050.SetActive(true);
                    Leftneg1050.SetActive(true);
                    break;

                case (float)-10.25:
                    TopLeftneg1025.SetActive(true);
                    Leftneg1025.SetActive(true);
                    break;

                case (float)-10:
                    TopLeftneg1000.SetActive(true);
                    Leftneg1000.SetActive(true);
                    break;

                case (float)-9.75:
                    TopLeftneg975.SetActive(true);
                    Leftneg975.SetActive(true);
                    break;

                case (float)-9.5:
                    TopLeftneg950.SetActive(true);
                    Leftneg950.SetActive(true);
                    break;

                case (float)-9.25:
                    TopLeftneg925.SetActive(true);
                    Leftneg925.SetActive(true);
                    break;

                case (float)-9:
                    TopLeftneg900.SetActive(true);
                    Leftneg900.SetActive(true);
                    break;

                case (float)-8.75:
                    TopLeftneg875.SetActive(true);
                    Leftneg875.SetActive(true);
                    break;

                case (float)-8.5:
                    TopLeftneg850.SetActive(true);
                    Leftneg850.SetActive(true);
                    break;

                case (float)-8.25:
                    TopLeftneg825.SetActive(true);
                    Leftneg825.SetActive(true);
                    break;

                case (float)-8:
                    TopLeftneg800.SetActive(true);
                    Leftneg800.SetActive(true);
                    break;

                case (float)-7.75:
                    TopLeftneg775.SetActive(true);
                    Leftneg775.SetActive(true);
                    break;

                case (float)-7.5:
                    TopLeftneg750.SetActive(true);
                    Leftneg750.SetActive(true);
                    break;

                case (float)-7.25:
                    TopLeftneg725.SetActive(true);
                    Leftneg725.SetActive(true);
                    break;

                case (float)-7:
                    TopLeftneg700.SetActive(true);
                    Leftneg700.SetActive(true);
                    break;

                case (float)-6.75:
                    TopLeftneg675.SetActive(true);
                    Leftneg675.SetActive(true);
                    break;

                case (float)-6.5:
                    TopLeftneg650.SetActive(true);
                    Leftneg650.SetActive(true);
                    break;

                case (float)-6.25:
                    TopLeftneg625.SetActive(true);
                    Leftneg625.SetActive(true);
                    break;

                case (float)-6:
                    TopLeftneg600.SetActive(true);
                    Leftneg600.SetActive(true);
                    break;

                case (float)-5.75:
                    TopLeftneg575.SetActive(true);
                    Leftneg575.SetActive(true);
                    break;

                case (float)-5.5:
                    TopLeftneg550.SetActive(true);
                    Leftneg550.SetActive(true);
                    break;

                case (float)-5.25:
                    TopLeftneg525.SetActive(true);
                    Leftneg525.SetActive(true);
                    break;

                case (float)-5:
                    TopLeftneg500.SetActive(true);
                    Leftneg500.SetActive(true);
                    break;

                case (float)-4.75:
                    TopLeftneg475.SetActive(true);
                    Leftneg475.SetActive(true);
                    break;

                case (float)-4.5:
                    TopLeftneg450.SetActive(true);
                    Leftneg450.SetActive(true);
                    break;

                case (float)-4.25:
                    TopLeftneg425.SetActive(true);
                    Leftneg425.SetActive(true);
                    break;

                case (float)-4:
                    TopLeftneg400.SetActive(true);
                    Leftneg400.SetActive(true);
                    break;

                case (float)-3.75:
                    TopLeftneg375.SetActive(true);
                    Leftneg375.SetActive(true);
                    break;

                case (float)-3.5:
                    TopLeftneg350.SetActive(true);
                    Leftneg350.SetActive(true);
                    break;

                case (float)-3.25:
                    TopLeftneg325.SetActive(true);
                    Leftneg325.SetActive(true);
                    break;

                case (float)-3:
                    TopLeftneg300.SetActive(true);
                    Leftneg300.SetActive(true);
                    break;

                case (float)-2.75:
                    TopLeftneg275.SetActive(true);
                    Leftneg275.SetActive(true);
                    break;

                case (float)-2.5:
                    TopLeftneg250.SetActive(true);
                    Leftneg250.SetActive(true);
                    break;

                case (float)-2.25:
                    TopLeftneg225.SetActive(true);
                    Leftneg225.SetActive(true);
                    break;

                case (float)-2:
                    TopLeftneg200.SetActive(true);
                    Leftneg200.SetActive(true);
                    break;

                case (float)-1.75:
                    TopLeftneg175.SetActive(true);
                    Leftneg175.SetActive(true);
                    break;

                case (float)-1.5:
                    TopLeftneg150.SetActive(true);
                    Leftneg150.SetActive(true);
                    break;

                case (float)-1.25:
                    TopLeftneg125.SetActive(true);
                    Leftneg125.SetActive(true);
                    break;

                case (float)-1:
                    TopLeftneg100.SetActive(true);
                    Leftneg100.SetActive(true);
                    break;

                case (float)-0.75:
                    TopLeftneg75.SetActive(true);
                    Leftneg75.SetActive(true);
                    break;

                case (float)-0.5:
                    Leftneg50.SetActive(true);
                    TopLeftneg50.SetActive(true);
                    break;

                case (float)-0.25:
                    Leftneg25.SetActive(true);
                    TopLeftneg25.SetActive(true);
                    break;

                case (float)0:
                    Leftpos0.SetActive(true);
                    TopLeftpos0.SetActive(true);
                    break;

                case (float)0.25:
                    Leftpos25.SetActive(true);
                    TopLeftpos25.SetActive(true);

                    break;

                case (float)0.5:
                    Leftpos50.SetActive(true);
                    TopLeftpos50.SetActive(true);
                    break;

                case (float)0.75:
                    Leftpos75.SetActive(true);
                    TopLeftpos75.SetActive(true);
                    break;

                case (float)1:
                    Leftpos100.SetActive(true);
                    TopLeftpos100.SetActive(true);
                    break;

                case (float)1.25:
                    Leftpos125.SetActive(true);
                    TopLeftpos125.SetActive(true);
                    break;

                case (float)1.5:
                    Leftpos150.SetActive(true);
                    TopLeftpos150.SetActive(true);
                    break;

                case (float)1.75:
                    Leftpos175.SetActive(true);
                    TopLeftpos175.SetActive(true);
                    break;

                case (float)2:
                    Leftpos200.SetActive(true);
                    TopLeftpos200.SetActive(true);
                    break;

                case (float)2.25:
                    Leftpos225.SetActive(true);
                    TopLeftpos225.SetActive(true);
                    break;

                case (float)2.5:
                    Leftpos250.SetActive(true);
                    TopLeftpos250.SetActive(true);
                    break;

                case (float)2.75:
                    Leftpos275.SetActive(true);
                    TopLeftpos275.SetActive(true);
                    break;

                case (float)3:
                    Leftpos300.SetActive(true);
                    TopLeftpos300.SetActive(true);
                    break;

                case (float)3.25:
                    Leftpos325.SetActive(true);
                    TopLeftpos325.SetActive(true);
                    break;

                case (float)3.5:
                    Leftpos350.SetActive(true);
                    TopLeftpos350.SetActive(true);
                    break;

                case (float)3.75:
                    Leftpos375.SetActive(true);
                    TopLeftpos375.SetActive(true);
                    break;

                case (float)4:
                    Leftpos400.SetActive(true);
                    TopLeftpos400.SetActive(true);
                    break;

                case (float)4.25:
                    Leftpos425.SetActive(true);
                    TopLeftpos425.SetActive(true);
                    break;

                case (float)4.5:
                    Leftpos450.SetActive(true);
                    TopLeftpos450.SetActive(true);
                    break;

                case (float)4.75:
                    Leftpos475.SetActive(true);
                    TopLeftpos475.SetActive(true);
                    break;

                case (float)5:
                    Leftpos500.SetActive(true);
                    TopLeftpos500.SetActive(true);
                    break;

                case (float)5.25:
                    Leftpos525.SetActive(true);
                    TopLeftpos525.SetActive(true);
                    break;

                case (float)5.5:
                    Leftpos550.SetActive(true);
                    TopLeftpos550.SetActive(true);
                    break;

                case (float)5.75:
                    Leftpos575.SetActive(true);
                    TopLeftpos575.SetActive(true);
                    break;

                case (float)6:
                    Leftpos600.SetActive(true);
                    TopLeftpos600.SetActive(true);
                    break;

                case (float)6.25:
                    Leftpos625.SetActive(true);
                    TopLeftpos625.SetActive(true);
                    break;

                case (float)6.5:
                    Leftpos650.SetActive(true);
                    TopLeftpos650.SetActive(true);
                    break;

                case (float)6.75:
                    Leftpos675.SetActive(true);
                    TopLeftpos675.SetActive(true);
                    break;

                case (float)7:
                    Leftpos700.SetActive(true);
                    TopLeftpos700.SetActive(true);
                    break;

                case (float)7.25:
                    Leftpos725.SetActive(true);
                    TopLeftpos725.SetActive(true);
                    break;

                case (float)7.5:
                    Leftpos750.SetActive(true);
                    TopLeftpos750.SetActive(true);
                    break;

                case (float)7.75:
                    Leftpos775.SetActive(true);
                    TopLeftpos775.SetActive(true);
                    break;

                case (float)8:
                    Leftpos800.SetActive(true);
                    TopLeftpos800.SetActive(true);
                    break;

                case (float)8.25:
                    Leftpos825.SetActive(true);
                    TopLeftpos825.SetActive(true);
                    break;

                case (float)8.5:
                    Leftpos850.SetActive(true);
                    TopLeftpos850.SetActive(true);
                    break;

                case (float)8.75:
                    Leftpos875.SetActive(true);
                    TopLeftpos875.SetActive(true);
                    break;

                case (float)9:
                    Leftpos900.SetActive(true);
                    TopLeftpos900.SetActive(true);
                    break;

                case (float)9.25:
                    Leftpos925.SetActive(true);
                    TopLeftpos925.SetActive(true);
                    break;

                case (float)9.5:
                    Leftpos950.SetActive(true);
                    TopLeftpos950.SetActive(true);
                    break;

                case (float)9.75:
                    Leftpos975.SetActive(true);
                    TopLeftpos975.SetActive(true);
                    break;

                case (float)10:
                    Leftpos1000.SetActive(true);
                    TopLeftpos1000.SetActive(true);
                    break;

                case (float)10.25:
                    Leftpos1025.SetActive(true);
                    TopLeftpos1025.SetActive(true);
                    break;

                case (float)10.5:
                    Leftpos1050.SetActive(true);
                    TopLeftpos1050.SetActive(true);
                    break;

                case (float)10.75:
                    Leftpos1075.SetActive(true);
                    TopLeftpos1075.SetActive(true);
                    break;

                case (float)11:
                    Leftpos1100.SetActive(true);
                    TopLeftpos1100.SetActive(true);
                    break;

                case (float)11.25:
                    Leftpos1125.SetActive(true);
                    TopLeftpos1125.SetActive(true);
                    break;

                case (float)11.5:
                    Leftpos1150.SetActive(true);
                    TopLeftpos1150.SetActive(true);
                    break;

                case (float)11.75:
                    Leftpos1175.SetActive(true);
                    TopLeftpos1175.SetActive(true);
                    break;

                case (float)12:
                    Leftpos1200.SetActive(true);
                    TopLeftpos1200.SetActive(true);
                    break;

                case (float)12.25:
                    Leftpos1225.SetActive(true);
                    TopLeftpos1225.SetActive(true);
                    break;

                case (float)12.5:
                    Leftpos1250.SetActive(true);
                    TopLeftpos1250.SetActive(true);
                    break;

                case (float)12.75:
                    Leftpos1275.SetActive(true);
                    TopLeftpos1275.SetActive(true);
                    break;

                case (float)13:
                    Leftpos1300.SetActive(true);
                    TopLeftpos1300.SetActive(true);
                    break;

                case (float)13.25:
                    Leftpos1325.SetActive(true);
                    TopLeftpos1325.SetActive(true);
                    break;

                case (float)13.5:
                    Leftpos1350.SetActive(true);
                    TopLeftpos1350.SetActive(true);
                    break;

                case (float)13.75:
                    Leftpos1375.SetActive(true);
                    TopLeftpos1375.SetActive(true);
                    break;

                case (float)14:
                    Leftpos1400.SetActive(true);
                    TopLeftpos1400.SetActive(true);
                    break;

                case (float)14.25:
                    Leftpos1425.SetActive(true);
                    TopLeftpos1425.SetActive(true);
                    break;

                case (float)14.5:
                    Leftpos1450.SetActive(true);
                    TopLeftpos1450.SetActive(true);
                    break;

                case (float)14.75:
                    Leftpos1475.SetActive(true);
                    TopLeftpos1475.SetActive(true);
                    break;

                case (float)15:
                    Leftpos1500.SetActive(true);
                    TopLeftpos1500.SetActive(true);
                    break;

                case (float)15.25:
                    Leftpos1525.SetActive(true);
                    TopLeftpos1525.SetActive(true);
                    break;

                case (float)15.5:
                    Leftpos1550.SetActive(true);
                    TopLeftpos1550.SetActive(true);
                    break;

                case (float)15.75:
                    Leftpos1575.SetActive(true);
                    TopLeftpos1575.SetActive(true);
                    break;

                case (float)16:
                    Leftpos1600.SetActive(true);
                    TopLeftpos1600.SetActive(true);
                    break;

                case (float)16.25:
                    Leftpos1625.SetActive(true);
                    TopLeftpos1625.SetActive(true);
                    break;

                case (float)16.5:
                    Leftpos1650.SetActive(true);
                    TopLeftpos1650.SetActive(true);
                    break;

                case (float)16.75:
                    Leftpos1675.SetActive(true);
                    TopLeftpos1675.SetActive(true);
                    break;
            }
        }
        else
        {
            if (RightLSSightBool)
            {
                disableRight();
                switch (LSvalues)
                {
                    case (float)-19:
                        TopRightneg1900.SetActive(true);
                        Rightneg1900.SetActive(true);
                        break;

                    case (float)-18.75:
                        TopRightneg1875.SetActive(true);
                        Rightneg1875.SetActive(true);
                        break;

                    case (float)-18.5:
                        TopRightneg1850.SetActive(true);
                        Rightneg1850.SetActive(true);
                        break;

                    case (float)-18.25:
                        TopRightneg1825.SetActive(true);
                        Rightneg1825.SetActive(true);
                        break;

                    case (float)-18:
                        TopRightneg1800.SetActive(true);
                        Rightneg1800.SetActive(true);
                        break;

                    case (float)-17.75:
                        TopRightneg1775.SetActive(true);
                        Rightneg1775.SetActive(true);
                        break;

                    case (float)-17.5:
                        TopRightneg1750.SetActive(true);
                        Rightneg1750.SetActive(true);
                        break;

                    case (float)-17.25:
                        TopRightneg1725.SetActive(true);
                        Rightneg1725.SetActive(true);
                        break;

                    case (float)-17:
                        TopRightneg1700.SetActive(true);
                        Rightneg1700.SetActive(true);
                        break;

                    case (float)-16.75:
                        TopRightneg1675.SetActive(true);
                        Rightneg1675.SetActive(true);
                        break;

                    case (float)-16.5:
                        TopRightneg1650.SetActive(true);
                        Rightneg1650.SetActive(true);
                        break;

                    case (float)-16.25:
                        TopRightneg1625.SetActive(true);
                        Rightneg1625.SetActive(true);
                        break;

                    case (float)-16:
                        TopRightneg1600.SetActive(true);
                        Rightneg1600.SetActive(true);
                        break;

                    case (float)-15.75:
                        TopRightneg1575.SetActive(true);
                        Rightneg1575.SetActive(true);
                        break;

                    case (float)-15.5:
                        TopRightneg1550.SetActive(true);
                        Rightneg1550.SetActive(true);
                        break;

                    case (float)-15.25:
                        TopRightneg1525.SetActive(true);
                        Rightneg1525.SetActive(true);
                        break;

                    case (float)-15:
                        TopRightneg1500.SetActive(true);
                        Rightneg1500.SetActive(true);
                        break;

                    case (float)-14.75:
                        TopRightneg1475.SetActive(true);
                        Rightneg1475.SetActive(true);
                        break;

                    case (float)-14.5:
                        TopRightneg1450.SetActive(true);
                        Rightneg1450.SetActive(true);
                        break;

                    case (float)-14.25:
                        TopRightneg1425.SetActive(true);
                        Rightneg1425.SetActive(true);
                        break;

                    case (float)-14:
                        TopRightneg1400.SetActive(true);
                        Rightneg1400.SetActive(true);
                        break;

                    case (float)-13.75:
                        TopRightneg1375.SetActive(true);
                        Rightneg1375.SetActive(true);
                        break;

                    case (float)-13.5:
                        TopRightneg1350.SetActive(true);
                        Rightneg1350.SetActive(true);
                        break;

                    case (float)-13.25:
                        TopRightneg1325.SetActive(true);
                        Rightneg1325.SetActive(true);
                        break;

                    case (float)-13:
                        TopRightneg1300.SetActive(true);
                        Rightneg1300.SetActive(true);
                        break;

                    case (float)-12.75:
                        TopRightneg1275.SetActive(true);
                        Rightneg1275.SetActive(true);
                        break;

                    case (float)-12.5:
                        TopRightneg1250.SetActive(true);
                        Rightneg1250.SetActive(true);
                        break;

                    case (float)-12.25:
                        TopRightneg1225.SetActive(true);
                        Rightneg1225.SetActive(true);
                        break;

                    case (float)-12:
                        TopRightneg1200.SetActive(true);
                        Rightneg1200.SetActive(true);
                        break;

                    case (float)-11.75:
                        TopRightneg1175.SetActive(true);
                        Rightneg1175.SetActive(true);
                        break;

                    case (float)-11.5:
                        TopRightneg1150.SetActive(true);
                        Rightneg1150.SetActive(true);
                        break;

                    case (float)-11.25:
                        TopRightneg1125.SetActive(true);
                        Rightneg1125.SetActive(true);
                        break;

                    case (float)-11:
                        TopRightneg1100.SetActive(true);
                        Rightneg1100.SetActive(true);
                        break;

                    case (float)-10.75:
                        TopRightneg1075.SetActive(true);
                        Rightneg1075.SetActive(true);
                        break;

                    case (float)-10.5:
                        TopRightneg1050.SetActive(true);
                        Rightneg1050.SetActive(true);
                        break;

                    case (float)-10.25:
                        TopRightneg1025.SetActive(true);
                        Rightneg1025.SetActive(true);
                        break;

                    case (float)-10:
                        TopRightneg1000.SetActive(true);
                        Rightneg1000.SetActive(true);
                        break;

                    case (float)-9.75:
                        TopRightneg975.SetActive(true);
                        Rightneg975.SetActive(true);
                        break;

                    case (float)-9.5:
                        TopRightneg950.SetActive(true);
                        Rightneg950.SetActive(true);
                        break;

                    case (float)-9.25:
                        TopRightneg925.SetActive(true);
                        Rightneg925.SetActive(true);
                        break;

                    case (float)-9:
                        TopRightneg900.SetActive(true);
                        Rightneg900.SetActive(true);
                        break;

                    case (float)-8.75:
                        TopRightneg875.SetActive(true);
                        Rightneg875.SetActive(true);
                        break;

                    case (float)-8.5:
                        TopRightneg850.SetActive(true);
                        Rightneg850.SetActive(true);
                        break;

                    case (float)-8.25:
                        TopRightneg825.SetActive(true);
                        Rightneg825.SetActive(true);
                        break;

                    case (float)-8:
                        TopRightneg800.SetActive(true);
                        Rightneg800.SetActive(true);
                        break;

                    case (float)-7.75:
                        TopRightneg775.SetActive(true);
                        Rightneg775.SetActive(true);
                        break;

                    case (float)-7.5:
                        TopRightneg750.SetActive(true);
                        Rightneg750.SetActive(true);
                        break;

                    case (float)-7.25:
                        TopRightneg725.SetActive(true);
                        Rightneg725.SetActive(true);
                        break;

                    case (float)-7:
                        TopRightneg700.SetActive(true);
                        Rightneg700.SetActive(true);
                        break;

                    case (float)-6.75:
                        TopRightneg675.SetActive(true);
                        Rightneg675.SetActive(true);
                        break;

                    case (float)-6.5:
                        TopRightneg650.SetActive(true);
                        Rightneg650.SetActive(true);
                        break;

                    case (float)-6.25:
                        TopRightneg625.SetActive(true);
                        Rightneg625.SetActive(true);
                        break;

                    case (float)-6:
                        TopRightneg600.SetActive(true);
                        Rightneg600.SetActive(true);
                        break;

                    case (float)-5.75:
                        TopRightneg575.SetActive(true);
                        Rightneg575.SetActive(true);
                        break;

                    case (float)-5.5:
                        TopRightneg550.SetActive(true);
                        Rightneg550.SetActive(true);
                        break;

                    case (float)-5.25:
                        TopRightneg525.SetActive(true);
                        Rightneg525.SetActive(true);
                        break;

                    case (float)-5:
                        TopRightneg500.SetActive(true);
                        Rightneg500.SetActive(true);
                        break;

                    case (float)-4.75:
                        TopRightneg475.SetActive(true);
                        Rightneg475.SetActive(true);
                        break;

                    case (float)-4.5:
                        TopRightneg450.SetActive(true);
                        Rightneg450.SetActive(true);
                        break;

                    case (float)-4.25:
                        TopRightneg425.SetActive(true);
                        Rightneg425.SetActive(true);
                        break;

                    case (float)-4:
                        TopRightneg400.SetActive(true);
                        Rightneg400.SetActive(true);
                        break;

                    case (float)-3.75:
                        TopRightneg375.SetActive(true);
                        Rightneg375.SetActive(true);
                        break;

                    case (float)-3.5:
                        TopRightneg350.SetActive(true);
                        Rightneg350.SetActive(true);
                        break;

                    case (float)-3.25:
                        TopRightneg325.SetActive(true);
                        Rightneg325.SetActive(true);
                        break;

                    case (float)-3:
                        TopRightneg300.SetActive(true);
                        Rightneg300.SetActive(true);
                        break;

                    case (float)-2.75:
                        TopRightneg275.SetActive(true);
                        Rightneg275.SetActive(true);
                        break;

                    case (float)-2.5:
                        TopRightneg250.SetActive(true);
                        Rightneg250.SetActive(true);
                        break;

                    case (float)-2.25:
                        TopRightneg225.SetActive(true);
                        Rightneg225.SetActive(true);
                        break;

                    case (float)-2:
                        TopRightneg200.SetActive(true);
                        Rightneg200.SetActive(true);
                        break;

                    case (float)-1.75:
                        TopRightneg175.SetActive(true);
                        Rightneg175.SetActive(true);
                        break;

                    case (float)-1.5:
                        TopRightneg150.SetActive(true);
                        Rightneg150.SetActive(true);
                        break;

                    case (float)-1.25:
                        TopRightneg125.SetActive(true);
                        Rightneg125.SetActive(true);
                        break;

                    case (float)-1:
                        TopRightneg100.SetActive(true);
                        Rightneg100.SetActive(true);
                        break;

                    case (float)-0.75:
                        TopRightneg75.SetActive(true);
                        Rightneg75.SetActive(true);
                        break;

                    case (float)-0.5:
                        TopRightneg50.SetActive(true);
                        Rightneg50.SetActive(true);
                        break;

                    case (float)-0.25:
                        TopRightneg25.SetActive(true);
                        Rightneg25.SetActive(true);
                        break;

                    case (float)0:
                        TopRightpos0.SetActive(true);
                        Rightpos0.SetActive(true);
                        break;

                    case (float)0.25:
                        TopRightpos25.SetActive(true);
                        Rightpos25.SetActive(true);
                        break;

                    case (float)0.5:
                        TopRightpos50.SetActive(true);
                        Rightpos50.SetActive(true);
                        break;

                    case (float)0.75:
                        TopRightpos75.SetActive(true);
                        Rightpos75.SetActive(true);
                        break;

                    case (float)1:
                        TopRightpos100.SetActive(true);
                        Rightpos100.SetActive(true);
                        break;

                    case (float)1.25:
                        TopRightpos125.SetActive(true);
                        Rightpos125.SetActive(true);
                        break;

                    case (float)1.5:
                        TopRightpos150.SetActive(true);
                        Rightpos150.SetActive(true);
                        break;

                    case (float)1.75:
                        TopRightpos175.SetActive(true);
                        Rightpos175.SetActive(true);
                        break;

                    case (float)2:
                        TopRightpos200.SetActive(true);
                        Rightpos200.SetActive(true);
                        break;

                    case (float)2.25:
                        TopRightpos225.SetActive(true);
                        Rightpos225.SetActive(true);
                        break;

                    case (float)2.5:
                        TopRightpos250.SetActive(true);
                        Rightpos250.SetActive(true);
                        break;

                    case (float)2.75:
                        TopRightpos275.SetActive(true);
                        Rightpos275.SetActive(true);
                        break;

                    case (float)3:
                        TopRightpos300.SetActive(true);
                        Rightpos300.SetActive(true);
                        break;

                    case (float)3.25:
                        TopRightpos325.SetActive(true);
                        Rightpos325.SetActive(true);
                        break;

                    case (float)3.5:
                        TopRightpos350.SetActive(true);
                        Rightpos350.SetActive(true);
                        break;

                    case (float)3.75:
                        TopRightpos375.SetActive(true);
                        Rightpos375.SetActive(true);
                        break;

                    case (float)4:
                        TopRightpos400.SetActive(true);
                        Rightpos400.SetActive(true);
                        break;

                    case (float)4.25:
                        TopRightpos425.SetActive(true);
                        Rightpos425.SetActive(true);
                        break;

                    case (float)4.5:
                        TopRightpos450.SetActive(true);
                        Rightpos450.SetActive(true);
                        break;

                    case (float)4.75:
                        TopRightpos475.SetActive(true);
                        Rightpos475.SetActive(true);
                        break;

                    case (float)5:
                        TopRightpos500.SetActive(true);
                        Rightpos500.SetActive(true);
                        break;

                    case (float)5.25:
                        TopRightpos525.SetActive(true);
                        Rightpos525.SetActive(true);
                        break;

                    case (float)5.5:
                        TopRightpos550.SetActive(true);
                        Rightpos550.SetActive(true);
                        break;

                    case (float)5.75:
                        TopRightpos575.SetActive(true);
                        Rightpos575.SetActive(true);
                        break;

                    case (float)6:
                        TopRightpos600.SetActive(true);
                        Rightpos600.SetActive(true);
                        break;

                    case (float)6.25:
                        TopRightpos625.SetActive(true);
                        Rightpos625.SetActive(true);
                        break;

                    case (float)6.5:
                        TopRightpos650.SetActive(true);
                        Rightpos650.SetActive(true);
                        break;

                    case (float)6.75:
                        TopRightpos675.SetActive(true);
                        Rightpos675.SetActive(true);
                        break;

                    case (float)7:
                        TopRightpos700.SetActive(true);
                        Rightpos700.SetActive(true);
                        break;

                    case (float)7.25:
                        TopRightpos725.SetActive(true);
                        Rightpos725.SetActive(true);
                        break;

                    case (float)7.5:
                        TopRightpos750.SetActive(true);
                        Rightpos750.SetActive(true);
                        break;

                    case (float)7.75:
                        TopRightpos775.SetActive(true);
                        Rightpos775.SetActive(true);
                        break;

                    case (float)8:
                        TopRightpos800.SetActive(true);
                        Rightpos800.SetActive(true);
                        break;

                    case (float)8.25:
                        TopRightpos825.SetActive(true);
                        Rightpos825.SetActive(true);
                        break;

                    case (float)8.5:
                        TopRightpos850.SetActive(true);
                        Rightpos850.SetActive(true);
                        break;

                    case (float)8.75:
                        TopRightpos875.SetActive(true);
                        Rightpos875.SetActive(true);
                        break;

                    case (float)9:
                        TopRightpos900.SetActive(true);
                        Rightpos900.SetActive(true);
                        break;

                    case (float)9.25:
                        TopRightpos925.SetActive(true);
                        Rightpos925.SetActive(true);
                        break;

                    case (float)9.5:
                        TopRightpos950.SetActive(true);
                        Rightpos950.SetActive(true);
                        break;

                    case (float)9.75:
                        TopRightpos975.SetActive(true);
                        Rightpos975.SetActive(true);
                        break;

                    case (float)10:
                        TopRightpos1000.SetActive(true);
                        Rightpos1000.SetActive(true);
                        break;

                    case (float)10.25:
                        TopRightpos1025.SetActive(true);
                        Rightpos1025.SetActive(true);
                        break;

                    case (float)10.5:
                        TopRightpos1050.SetActive(true);
                        Rightpos1050.SetActive(true);
                        break;

                    case (float)10.75:
                        TopRightpos1075.SetActive(true);
                        Rightpos1075.SetActive(true);
                        break;

                    case (float)11:
                        TopRightpos1100.SetActive(true);
                        Rightpos1100.SetActive(true);
                        break;

                    case (float)11.25:
                        TopRightpos1125.SetActive(true);
                        Rightpos1125.SetActive(true);
                        break;

                    case (float)11.5:
                        TopRightpos1150.SetActive(true);
                        Rightpos1150.SetActive(true);
                        break;

                    case (float)11.75:
                        TopRightpos1175.SetActive(true);
                        Rightpos1175.SetActive(true);
                        break;

                    case (float)12:
                        TopRightpos1200.SetActive(true);
                        Rightpos1200.SetActive(true);
                        break;

                    case (float)12.25:
                        TopRightpos1225.SetActive(true);
                        Rightpos1225.SetActive(true);
                        break;

                    case (float)12.5:
                        TopRightpos1250.SetActive(true);
                        Rightpos1250.SetActive(true);
                        break;

                    case (float)12.75:
                        TopRightpos1275.SetActive(true);
                        Rightpos1275.SetActive(true);
                        break;

                    case (float)13:
                        TopRightpos1300.SetActive(true);
                        Rightpos1300.SetActive(true);
                        break;

                    case (float)13.25:
                        TopRightpos1325.SetActive(true);
                        Rightpos1325.SetActive(true);
                        break;

                    case (float)13.5:
                        TopRightpos1350.SetActive(true);
                        Rightpos1350.SetActive(true);
                        break;

                    case (float)13.75:
                        TopRightpos1375.SetActive(true);
                        Rightpos1375.SetActive(true);
                        break;

                    case (float)14:
                        TopRightpos1400.SetActive(true);
                        Rightpos1400.SetActive(true);
                        break;

                    case (float)14.25:
                        TopRightpos1425.SetActive(true);
                        Rightpos1425.SetActive(true);
                        break;

                    case (float)14.5:
                        TopRightpos1450.SetActive(true);
                        Rightpos1450.SetActive(true);
                        break;

                    case (float)14.75:
                        TopRightpos1475.SetActive(true);
                        Rightpos1475.SetActive(true);
                        break;

                    case (float)15:
                        TopRightpos1500.SetActive(true);
                        Rightpos1500.SetActive(true);
                        break;

                    case (float)15.25:
                        TopRightpos1525.SetActive(true);
                        Rightpos1525.SetActive(true);
                        break;

                    case (float)15.5:
                        TopRightpos1550.SetActive(true);
                        Rightpos1550.SetActive(true);
                        break;

                    case (float)15.75:
                        TopRightpos1575.SetActive(true);
                        Rightpos1575.SetActive(true);
                        break;

                    case (float)16:
                        TopRightpos1600.SetActive(true);
                        Rightpos1600.SetActive(true);
                        break;

                    case (float)16.25:
                        TopRightpos1625.SetActive(true);
                        Rightpos1625.SetActive(true);
                        break;

                    case (float)16.5:
                        TopRightpos1650.SetActive(true);
                        Rightpos1650.SetActive(true);
                        break;

                    case (float)16.75:
                        TopRightpos1675.SetActive(true);
                        Rightpos1675.SetActive(true);
                        break;
                }
            }
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

    private void disableLeft()
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

        TopLeftneg1900.SetActive(false);
        TopLeftneg1875.SetActive(false);
        TopLeftneg1850.SetActive(false);
        TopLeftneg1825.SetActive(false);
        TopLeftneg1800.SetActive(false);
        TopLeftneg1775.SetActive(false);
        TopLeftneg1750.SetActive(false);
        TopLeftneg1725.SetActive(false);
        TopLeftneg1700.SetActive(false);
        TopLeftneg1675.SetActive(false);
        TopLeftneg1650.SetActive(false);
        TopLeftneg1625.SetActive(false);
        TopLeftneg1600.SetActive(false);
        TopLeftneg1575.SetActive(false);
        TopLeftneg1550.SetActive(false);
        TopLeftneg1525.SetActive(false);
        TopLeftneg1500.SetActive(false);
        TopLeftneg1475.SetActive(false);
        TopLeftneg1450.SetActive(false);
        TopLeftneg1425.SetActive(false);
        TopLeftneg1400.SetActive(false);
        TopLeftneg1375.SetActive(false);
        TopLeftneg1350.SetActive(false);
        TopLeftneg1325.SetActive(false);
        TopLeftneg1300.SetActive(false);
        TopLeftneg1275.SetActive(false);
        TopLeftneg1250.SetActive(false);
        TopLeftneg1225.SetActive(false);
        TopLeftneg1200.SetActive(false);
        TopLeftneg1175.SetActive(false);
        TopLeftneg1150.SetActive(false);
        TopLeftneg1125.SetActive(false);
        TopLeftneg1100.SetActive(false);
        TopLeftneg1075.SetActive(false);
        TopLeftneg1050.SetActive(false);
        TopLeftneg1025.SetActive(false);
        TopLeftneg1000.SetActive(false);
        TopLeftneg975.SetActive(false);
        TopLeftneg950.SetActive(false);
        TopLeftneg925.SetActive(false);
        TopLeftneg900.SetActive(false);
        TopLeftneg875.SetActive(false);
        TopLeftneg850.SetActive(false);
        TopLeftneg825.SetActive(false);
        TopLeftneg800.SetActive(false);
        TopLeftneg775.SetActive(false);
        TopLeftneg750.SetActive(false);
        TopLeftneg725.SetActive(false);
        TopLeftneg700.SetActive(false);
        TopLeftneg675.SetActive(false);
        TopLeftneg650.SetActive(false);
        TopLeftneg625.SetActive(false);
        TopLeftneg600.SetActive(false);
        TopLeftneg575.SetActive(false);
        TopLeftneg550.SetActive(false);
        TopLeftneg525.SetActive(false);
        TopLeftneg500.SetActive(false);
        TopLeftneg475.SetActive(false);
        TopLeftneg450.SetActive(false);
        TopLeftneg425.SetActive(false);
        TopLeftneg400.SetActive(false);
        TopLeftneg375.SetActive(false);
        TopLeftneg350.SetActive(false);
        TopLeftneg325.SetActive(false);
        TopLeftneg300.SetActive(false);
        TopLeftneg275.SetActive(false);
        TopLeftneg250.SetActive(false);
        TopLeftneg225.SetActive(false);
        TopLeftneg200.SetActive(false);
        TopLeftneg175.SetActive(false);
        TopLeftneg150.SetActive(false);
        TopLeftneg125.SetActive(false);
        TopLeftneg100.SetActive(false);
        TopLeftneg75.SetActive(false);
        TopLeftneg50.SetActive(false);
        TopLeftneg25.SetActive(false);

        TopLeftpos0.SetActive(false);

        TopLeftpos25.SetActive(false);
        TopLeftpos50.SetActive(false);
        TopLeftpos75.SetActive(false);
        TopLeftpos100.SetActive(false);
        TopLeftpos125.SetActive(false);
        TopLeftpos150.SetActive(false);
        TopLeftpos175.SetActive(false);
        TopLeftpos200.SetActive(false);
        TopLeftpos225.SetActive(false);
        TopLeftpos250.SetActive(false);
        TopLeftpos275.SetActive(false);
        TopLeftpos300.SetActive(false);
        TopLeftpos325.SetActive(false);
        TopLeftpos350.SetActive(false);
        TopLeftpos375.SetActive(false);
        TopLeftpos400.SetActive(false);
        TopLeftpos425.SetActive(false);
        TopLeftpos450.SetActive(false);
        TopLeftpos475.SetActive(false);
        TopLeftpos500.SetActive(false);
        TopLeftpos525.SetActive(false);
        TopLeftpos550.SetActive(false);
        TopLeftpos575.SetActive(false);
        TopLeftpos600.SetActive(false);
        TopLeftpos625.SetActive(false);
        TopLeftpos650.SetActive(false);
        TopLeftpos675.SetActive(false);
        TopLeftpos700.SetActive(false);
        TopLeftpos725.SetActive(false);
        TopLeftpos750.SetActive(false);
        TopLeftpos775.SetActive(false);
        TopLeftpos800.SetActive(false);
        TopLeftpos825.SetActive(false);
        TopLeftpos850.SetActive(false);
        TopLeftpos875.SetActive(false);
        TopLeftpos900.SetActive(false);
        TopLeftpos925.SetActive(false);
        TopLeftpos950.SetActive(false);
        TopLeftpos975.SetActive(false);
        TopLeftpos1000.SetActive(false);
        TopLeftpos1025.SetActive(false);
        TopLeftpos1050.SetActive(false);
        TopLeftpos1075.SetActive(false);
        TopLeftpos1100.SetActive(false);
        TopLeftpos1125.SetActive(false);
        TopLeftpos1150.SetActive(false);
        TopLeftpos1175.SetActive(false);
        TopLeftpos1200.SetActive(false);
        TopLeftpos1225.SetActive(false);
        TopLeftpos1250.SetActive(false);
        TopLeftpos1275.SetActive(false);
        TopLeftpos1300.SetActive(false);
        TopLeftpos1325.SetActive(false);
        TopLeftpos1350.SetActive(false);
        TopLeftpos1375.SetActive(false);
        TopLeftpos1400.SetActive(false);
        TopLeftpos1425.SetActive(false);
        TopLeftpos1450.SetActive(false);
        TopLeftpos1475.SetActive(false);
        TopLeftpos1500.SetActive(false);
        TopLeftpos1525.SetActive(false);
        TopLeftpos1550.SetActive(false);
        TopLeftpos1575.SetActive(false);
        TopLeftpos1600.SetActive(false);
        TopLeftpos1625.SetActive(false);
        TopLeftpos1650.SetActive(false);
        TopLeftpos1675.SetActive(false);
    }

    private void disableRight()
    {
        Rightneg1900.SetActive(false);
        Rightneg1875.SetActive(false);
        Rightneg1850.SetActive(false);
        Rightneg1825.SetActive(false);
        Rightneg1800.SetActive(false);
        Rightneg1775.SetActive(false);
        Rightneg1750.SetActive(false);
        Rightneg1725.SetActive(false);
        Rightneg1700.SetActive(false);
        Rightneg1675.SetActive(false);
        Rightneg1650.SetActive(false);
        Rightneg1625.SetActive(false);
        Rightneg1600.SetActive(false);
        Rightneg1575.SetActive(false);
        Rightneg1550.SetActive(false);
        Rightneg1525.SetActive(false);
        Rightneg1500.SetActive(false);
        Rightneg1475.SetActive(false);
        Rightneg1450.SetActive(false);
        Rightneg1425.SetActive(false);
        Rightneg1400.SetActive(false);
        Rightneg1375.SetActive(false);
        Rightneg1350.SetActive(false);
        Rightneg1325.SetActive(false);
        Rightneg1300.SetActive(false);
        Rightneg1275.SetActive(false);
        Rightneg1250.SetActive(false);
        Rightneg1225.SetActive(false);
        Rightneg1200.SetActive(false);
        Rightneg1175.SetActive(false);
        Rightneg1150.SetActive(false);
        Rightneg1125.SetActive(false);
        Rightneg1100.SetActive(false);
        Rightneg1075.SetActive(false);
        Rightneg1050.SetActive(false);
        Rightneg1025.SetActive(false);
        Rightneg1000.SetActive(false);
        Rightneg975.SetActive(false);
        Rightneg950.SetActive(false);
        Rightneg925.SetActive(false);
        Rightneg900.SetActive(false);
        Rightneg875.SetActive(false);
        Rightneg850.SetActive(false);
        Rightneg825.SetActive(false);
        Rightneg800.SetActive(false);
        Rightneg775.SetActive(false);
        Rightneg750.SetActive(false);
        Rightneg725.SetActive(false);
        Rightneg700.SetActive(false);
        Rightneg675.SetActive(false);
        Rightneg650.SetActive(false);
        Rightneg625.SetActive(false);
        Rightneg600.SetActive(false);
        Rightneg575.SetActive(false);
        Rightneg550.SetActive(false);
        Rightneg525.SetActive(false);
        Rightneg500.SetActive(false);
        Rightneg475.SetActive(false);
        Rightneg450.SetActive(false);
        Rightneg425.SetActive(false);
        Rightneg400.SetActive(false);
        Rightneg375.SetActive(false);
        Rightneg350.SetActive(false);
        Rightneg325.SetActive(false);
        Rightneg300.SetActive(false);
        Rightneg275.SetActive(false);
        Rightneg250.SetActive(false);
        Rightneg225.SetActive(false);
        Rightneg200.SetActive(false);
        Rightneg175.SetActive(false);
        Rightneg150.SetActive(false);
        Rightneg125.SetActive(false);
        Rightneg100.SetActive(false);
        Rightneg75.SetActive(false);
        Rightneg50.SetActive(false);
        Rightneg25.SetActive(false);

        Rightpos0.SetActive(false);

        Rightpos25.SetActive(false);
        Rightpos50.SetActive(false);
        Rightpos75.SetActive(false);
        Rightpos100.SetActive(false);
        Rightpos125.SetActive(false);
        Rightpos150.SetActive(false);
        Rightpos175.SetActive(false);
        Rightpos200.SetActive(false);
        Rightpos225.SetActive(false);
        Rightpos250.SetActive(false);
        Rightpos275.SetActive(false);
        Rightpos300.SetActive(false);
        Rightpos325.SetActive(false);
        Rightpos350.SetActive(false);
        Rightpos375.SetActive(false);
        Rightpos400.SetActive(false);
        Rightpos425.SetActive(false);
        Rightpos450.SetActive(false);
        Rightpos475.SetActive(false);
        Rightpos500.SetActive(false);
        Rightpos525.SetActive(false);
        Rightpos550.SetActive(false);
        Rightpos575.SetActive(false);
        Rightpos600.SetActive(false);
        Rightpos625.SetActive(false);
        Rightpos650.SetActive(false);
        Rightpos675.SetActive(false);
        Rightpos700.SetActive(false);
        Rightpos725.SetActive(false);
        Rightpos750.SetActive(false);
        Rightpos775.SetActive(false);
        Rightpos800.SetActive(false);
        Rightpos825.SetActive(false);
        Rightpos850.SetActive(false);
        Rightpos875.SetActive(false);
        Rightpos900.SetActive(false);
        Rightpos925.SetActive(false);
        Rightpos950.SetActive(false);
        Rightpos975.SetActive(false);
        Rightpos1000.SetActive(false);
        Rightpos1025.SetActive(false);
        Rightpos1050.SetActive(false);
        Rightpos1075.SetActive(false);
        Rightpos1100.SetActive(false);
        Rightpos1125.SetActive(false);
        Rightpos1150.SetActive(false);
        Rightpos1175.SetActive(false);
        Rightpos1200.SetActive(false);
        Rightpos1225.SetActive(false);
        Rightpos1250.SetActive(false);
        Rightpos1275.SetActive(false);
        Rightpos1300.SetActive(false);
        Rightpos1325.SetActive(false);
        Rightpos1350.SetActive(false);
        Rightpos1375.SetActive(false);
        Rightpos1400.SetActive(false);
        Rightpos1425.SetActive(false);
        Rightpos1450.SetActive(false);
        Rightpos1475.SetActive(false);
        Rightpos1500.SetActive(false);
        Rightpos1525.SetActive(false);
        Rightpos1550.SetActive(false);
        Rightpos1575.SetActive(false);
        Rightpos1600.SetActive(false);
        Rightpos1625.SetActive(false);
        Rightpos1650.SetActive(false);
        Rightpos1675.SetActive(false);

        TopRightneg1900.SetActive(false);
        TopRightneg1875.SetActive(false);
        TopRightneg1850.SetActive(false);
        TopRightneg1825.SetActive(false);
        TopRightneg1800.SetActive(false);
        TopRightneg1775.SetActive(false);
        TopRightneg1750.SetActive(false);
        TopRightneg1725.SetActive(false);
        TopRightneg1700.SetActive(false);
        TopRightneg1675.SetActive(false);
        TopRightneg1650.SetActive(false);
        TopRightneg1625.SetActive(false);
        TopRightneg1600.SetActive(false);
        TopRightneg1575.SetActive(false);
        TopRightneg1550.SetActive(false);
        TopRightneg1525.SetActive(false);
        TopRightneg1500.SetActive(false);
        TopRightneg1475.SetActive(false);
        TopRightneg1450.SetActive(false);
        TopRightneg1425.SetActive(false);
        TopRightneg1400.SetActive(false);
        TopRightneg1375.SetActive(false);
        TopRightneg1350.SetActive(false);
        TopRightneg1325.SetActive(false);
        TopRightneg1300.SetActive(false);
        TopRightneg1275.SetActive(false);
        TopRightneg1250.SetActive(false);
        TopRightneg1225.SetActive(false);
        TopRightneg1200.SetActive(false);
        TopRightneg1175.SetActive(false);
        TopRightneg1150.SetActive(false);
        TopRightneg1125.SetActive(false);
        TopRightneg1100.SetActive(false);
        TopRightneg1075.SetActive(false);
        TopRightneg1050.SetActive(false);
        TopRightneg1025.SetActive(false);
        TopRightneg1000.SetActive(false);
        TopRightneg975.SetActive(false);
        TopRightneg950.SetActive(false);
        TopRightneg925.SetActive(false);
        TopRightneg900.SetActive(false);
        TopRightneg875.SetActive(false);
        TopRightneg850.SetActive(false);
        TopRightneg825.SetActive(false);
        TopRightneg800.SetActive(false);
        TopRightneg775.SetActive(false);
        TopRightneg750.SetActive(false);
        TopRightneg725.SetActive(false);
        TopRightneg700.SetActive(false);
        TopRightneg675.SetActive(false);
        TopRightneg650.SetActive(false);
        TopRightneg625.SetActive(false);
        TopRightneg600.SetActive(false);
        TopRightneg575.SetActive(false);
        TopRightneg550.SetActive(false);
        TopRightneg525.SetActive(false);
        TopRightneg500.SetActive(false);
        TopRightneg475.SetActive(false);
        TopRightneg450.SetActive(false);
        TopRightneg425.SetActive(false);
        TopRightneg400.SetActive(false);
        TopRightneg375.SetActive(false);
        TopRightneg350.SetActive(false);
        TopRightneg325.SetActive(false);
        TopRightneg300.SetActive(false);
        TopRightneg275.SetActive(false);
        TopRightneg250.SetActive(false);
        TopRightneg225.SetActive(false);
        TopRightneg200.SetActive(false);
        TopRightneg175.SetActive(false);
        TopRightneg150.SetActive(false);
        TopRightneg125.SetActive(false);
        TopRightneg100.SetActive(false);
        TopRightneg75.SetActive(false);
        TopRightneg50.SetActive(false);
        TopRightneg25.SetActive(false);

        TopRightpos0.SetActive(false);

        TopRightpos25.SetActive(false);
        TopRightpos50.SetActive(false);
        TopRightpos75.SetActive(false);
        TopRightpos100.SetActive(false);
        TopRightpos125.SetActive(false);
        TopRightpos150.SetActive(false);
        TopRightpos175.SetActive(false);
        TopRightpos200.SetActive(false);
        TopRightpos225.SetActive(false);
        TopRightpos250.SetActive(false);
        TopRightpos275.SetActive(false);
        TopRightpos300.SetActive(false);
        TopRightpos325.SetActive(false);
        TopRightpos350.SetActive(false);
        TopRightpos375.SetActive(false);
        TopRightpos400.SetActive(false);
        TopRightpos425.SetActive(false);
        TopRightpos450.SetActive(false);
        TopRightpos475.SetActive(false);
        TopRightpos500.SetActive(false);
        TopRightpos525.SetActive(false);
        TopRightpos550.SetActive(false);
        TopRightpos575.SetActive(false);
        TopRightpos600.SetActive(false);
        TopRightpos625.SetActive(false);
        TopRightpos650.SetActive(false);
        TopRightpos675.SetActive(false);
        TopRightpos700.SetActive(false);
        TopRightpos725.SetActive(false);
        TopRightpos750.SetActive(false);
        TopRightpos775.SetActive(false);
        TopRightpos800.SetActive(false);
        TopRightpos825.SetActive(false);
        TopRightpos850.SetActive(false);
        TopRightpos875.SetActive(false);
        TopRightpos900.SetActive(false);
        TopRightpos925.SetActive(false);
        TopRightpos950.SetActive(false);
        TopRightpos975.SetActive(false);
        TopRightpos1000.SetActive(false);
        TopRightpos1025.SetActive(false);
        TopRightpos1050.SetActive(false);
        TopRightpos1075.SetActive(false);
        TopRightpos1100.SetActive(false);
        TopRightpos1125.SetActive(false);
        TopRightpos1150.SetActive(false);
        TopRightpos1175.SetActive(false);
        TopRightpos1200.SetActive(false);
        TopRightpos1225.SetActive(false);
        TopRightpos1250.SetActive(false);
        TopRightpos1275.SetActive(false);
        TopRightpos1300.SetActive(false);
        TopRightpos1325.SetActive(false);
        TopRightpos1350.SetActive(false);
        TopRightpos1375.SetActive(false);
        TopRightpos1400.SetActive(false);
        TopRightpos1425.SetActive(false);
        TopRightpos1450.SetActive(false);
        TopRightpos1475.SetActive(false);
        TopRightpos1500.SetActive(false);
        TopRightpos1525.SetActive(false);
        TopRightpos1550.SetActive(false);
        TopRightpos1575.SetActive(false);
        TopRightpos1600.SetActive(false);
        TopRightpos1625.SetActive(false);
        TopRightpos1650.SetActive(false);
        TopRightpos1675.SetActive(false);
    }
}