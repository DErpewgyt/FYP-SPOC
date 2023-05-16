using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Checker : MonoBehaviour
{
    public GameObject ViewPortMiddle;
    public GameObject ViewPortCircles;

    public GameObject ViewPortBlurOptimal;
    public GameObject ViewPortBlur;

    public GameObject BlackCircle;
    public GameObject BlackCircleOptimalDist;

    public GameObject MiddleCircle;
    public GameObject LeftCircle;
    public GameObject TopCircle;

    public float BlackCircleBlur;
    public float CircleGrpDist;
    public float CircleGrpDistBlur;
    public float LeftAndMiddleCircleDist;
    public float TopAndMiddleCircleDist;

    public GameObject BlurCircleWin;
    public GameObject GroupCircleWin;
    public GameObject LeftCircleWin;
    public GameObject TopCircleWin;

    public Toggle FocusBlackCircle;
    public Toggle Center3Circles;
    public Toggle AlignLeftCircle;
    public Toggle AlignTopCircle;

    public Toggle FocusBlackCircleViewPort;
    public Toggle Center3CirclesViewPort;
    public Toggle AlignLeftCircleViewPort;
    public Toggle AlignTopCircleViewPort;

    public float BlackCirlceDist;
    public float GrpCirlceDist;
    public float GrpCirlceDistBlur;
    public float LeftCircleMin;
    public float LeftCircleMax;
    public float TopCircleMin;
    public float TopCircleMax;

    public bool objextive1 = false;
    public bool objextive2 = false;
    public bool objextive3 = false;
    public bool objextive4 = false;

    public Stopwatch timerScript;
    public bool saved = false;
    public GameObject submit;
    private void Start()
    {
        BlurCircleWin.SetActive(false);
        GroupCircleWin.SetActive(false);
        LeftCircleWin.SetActive(false);
        TopCircleWin.SetActive(false);

        FocusBlackCircle.isOn = false;
        Center3Circles.isOn = false;
        AlignLeftCircle.isOn = false;
        AlignTopCircle.isOn = false;

        FocusBlackCircleViewPort.isOn = false;
        Center3CirclesViewPort.isOn = false;
        AlignLeftCircleViewPort.isOn = false;
        AlignTopCircleViewPort.isOn = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (objextive1 && objextive2 && objextive3 && objextive4 && !saved)
        {
            /*timerScript.CompleteConditions();
            saved = true;*/
            submit.SetActive(true);
        }

        BlackCircleBlur = Vector3.Distance(BlackCircle.transform.position, BlackCircleOptimalDist.transform.position);
        //print(BlackCircleBlur);
        if (BlackCircleBlur < BlackCirlceDist)
        {
            objextive1 = true;
            FocusBlackCircle.isOn = true;
            FocusBlackCircleViewPort.isOn = true;
            BlurCircleWin.SetActive(true);
        }
        else
        {
            FocusBlackCircle.isOn = false;            
            FocusBlackCircleViewPort.isOn = false;
            BlurCircleWin.SetActive(false);
            objextive1 = false;
}


        CircleGrpDist = Vector3.Distance(ViewPortMiddle.transform.position, ViewPortCircles.transform.position);
        CircleGrpDistBlur = Vector3.Distance(ViewPortBlur.transform.position, ViewPortBlurOptimal.transform.position);
        //print(CircleGrpDist);
        print(CircleGrpDistBlur);
        if (CircleGrpDist < GrpCirlceDist && CircleGrpDistBlur < GrpCirlceDistBlur)
        {
            Center3Circles.isOn = true;
            Center3CirclesViewPort.isOn = true;
            GroupCircleWin.SetActive(true);
            objextive2 = true;
        }
        else
        {
            Center3Circles.isOn = false;
            Center3CirclesViewPort.isOn = false;
            GroupCircleWin.SetActive(false);
            objextive2 = false;
        }


        LeftAndMiddleCircleDist = Vector3.Distance(MiddleCircle.transform.position, LeftCircle.transform.position);
        //print(LeftAndMiddleCircleDist);
        if (LeftAndMiddleCircleDist < LeftCircleMax && LeftAndMiddleCircleDist > LeftCircleMin)
        {
            AlignLeftCircle.isOn = true;
            AlignLeftCircleViewPort.isOn = true;
            LeftCircleWin.SetActive(true);
            objextive3 = true;
        }
        else
        { 
            AlignLeftCircle.isOn = false;
            AlignLeftCircleViewPort.isOn = false;
            LeftCircleWin.SetActive(false);
            objextive3 = false;
        }


        TopAndMiddleCircleDist = Vector3.Distance(MiddleCircle.transform.position, TopCircle.transform.position);
        //print(TopAndMiddleCircleDist);
        if (TopAndMiddleCircleDist < TopCircleMax && TopAndMiddleCircleDist > TopCircleMin)
        {
            AlignTopCircle.isOn = true;
            AlignTopCircleViewPort.isOn = true;
            TopCircleWin.SetActive(true);
            objextive4 = true;
        }
        else
        {
            AlignTopCircle.isOn = false;
            AlignTopCircleViewPort.isOn = false;
            TopCircleWin.SetActive(false);
            objextive4 = false;
        }
    }
    private void DistanceChecker()
    {
        //CircleGrpDist = Vector3.Distance(ViewPortMiddle.transform.position, ViewPortCircles.transform.position);
    }
}