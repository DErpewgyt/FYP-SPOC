using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public GameObject ViewPortMiddle;
    public GameObject ViewPortCircles;  

    public GameObject BlackCircle;
    public GameObject BlackCircleOptimalDist;

    public GameObject MiddleCircle;
    public GameObject LeftCircle;
    public GameObject TopCircle;

    public float BlackCircleBlur;
    public float CircleGrpDist;
    public float LeftAndMiddleCircleDist;
    public float TopAndMiddleCircleDist;

    public GameObject BlurCircleWin;
    public GameObject GroupCircleWin;
    public GameObject LeftCircleWin;
    public GameObject TopCircleWin;


    void Start()
    {
        BlurCircleWin.SetActive(false);
        GroupCircleWin.SetActive(false);
        LeftCircleWin.SetActive(false);
        TopCircleWin.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        BlackCircleBlur = Vector3.Distance(BlackCircle.transform.position, BlackCircleOptimalDist.transform.position);
            if (BlackCircleBlur < 0.06)
            {
                BlurCircleWin.SetActive(true);
            }
            else
            {
                BlurCircleWin.SetActive(false);
            }
        CircleGrpDist = Vector3.Distance(ViewPortMiddle.transform.position, ViewPortCircles.transform.position);
            if (CircleGrpDist < 0.002)
            {
                GroupCircleWin.SetActive(true);
            }
            else
            {
                GroupCircleWin.SetActive(false);
            }
        LeftAndMiddleCircleDist = Vector3.Distance(MiddleCircle.transform.position, LeftCircle.transform.position);
            if (LeftAndMiddleCircleDist < 0.1 && LeftAndMiddleCircleDist > 0.09)
        {
                LeftCircleWin.SetActive(true);
            }
            else
            {
                LeftCircleWin.SetActive(false);
            }
        TopAndMiddleCircleDist = Vector3.Distance(MiddleCircle.transform.position, TopCircle.transform.position);
            if (TopAndMiddleCircleDist < 0.11 && TopAndMiddleCircleDist > 0.1)
            {
                TopCircleWin.SetActive(true);
            }
            else
            {
                TopCircleWin.SetActive(false);
            }
    }

    private void DistanceChecker()
    {
        //CircleGrpDist = Vector3.Distance(ViewPortMiddle.transform.position, ViewPortCircles.transform.position);
    }


}
