using System.IO;
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

    public float BlackCirlceDist;
    public float GrpCirlceDist;
    public float LeftCircleMin;
    public float LeftCircleMax;
    public float TopCircleMin;
    public float TopCircleMax;

    private void Start()
    {
        BlurCircleWin.SetActive(false);
        GroupCircleWin.SetActive(false);
        LeftCircleWin.SetActive(false);
        TopCircleWin.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        BlackCircleBlur = Vector3.Distance(BlackCircle.transform.position, BlackCircleOptimalDist.transform.position);
        //print(BlackCircleBlur);
        if (BlackCircleBlur < BlackCirlceDist)
        {
            BlurCircleWin.SetActive(true);
            SaveData data = new SaveData();
            data.black_circle_z = BlackCircle.transform.position.z;
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(Application.dataPath + "/SaveDataFile.json", json);
            Debug.Log("saved" + BlackCircle.transform.position.z);
        }
        else
        {
            BlurCircleWin.SetActive(false);
        }
        CircleGrpDist = Vector3.Distance(ViewPortMiddle.transform.position, ViewPortCircles.transform.position);
        //print(CircleGrpDist);
        if (CircleGrpDist < GrpCirlceDist)
        {
            GroupCircleWin.SetActive(true);
        }
        else
        {
            GroupCircleWin.SetActive(false);
        }
        LeftAndMiddleCircleDist = Vector3.Distance(MiddleCircle.transform.position, LeftCircle.transform.position);
        /*print(LeftAndMiddleCircleDist);*/
        if (LeftAndMiddleCircleDist < LeftCircleMax && LeftAndMiddleCircleDist > LeftCircleMin)
        {
            LeftCircleWin.SetActive(true);
        }
        else
        {
            LeftCircleWin.SetActive(false);
        }
        TopAndMiddleCircleDist = Vector3.Distance(MiddleCircle.transform.position, TopCircle.transform.position);
        //print(TopAndMiddleCircleDist);
        if (TopAndMiddleCircleDist < TopCircleMax && TopAndMiddleCircleDist > TopCircleMin)
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