using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AIVoiceChecker : MonoBehaviour
{
    public MeasureReadings paper;
    public RulerController ruler;

    public AudioSource perfect;

    public int pd;
    public int rulerDist;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetPd());
    }

    IEnumerator GetPd()
    {
        // Wait for one frame to ensure that MeasureReadings initializes its variables
        yield return null;

        // Access the value of pd after it has been initialized in MeasureReadings
        pd = paper.pd;

        // Print the retrieved value of pd
        print("Retrieved value: " + pd);
    }

    public void check()
    {
        rulerDist = ruler.rulerDist;
        print(rulerDist);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
