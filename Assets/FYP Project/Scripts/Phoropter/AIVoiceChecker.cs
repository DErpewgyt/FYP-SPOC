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
    public int rulerDist;
    public int correctDist;

    public GameObject CheckBtn;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(GetPd());
    }

    private IEnumerator GetPd()
    {
        // Wait for one frame to ensure that MeasureReadings initializes its variables
        yield return null;

        // Access the value of pd after it has been initialized in MeasureReadings
        pd = paper.pd;

        // Print the retrieved value of pd
        print("Retrieved value: " + pd);
        if (pd == 60)
        {
            correctDist = 167;
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
}