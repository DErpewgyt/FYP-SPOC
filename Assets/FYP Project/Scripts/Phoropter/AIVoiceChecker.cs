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

        // Random Answer Generator
        int randomChange = Random.Range(0, 3); // Generates a random number between 0 and 2

        switch (randomChange)
        {
            case 0:
                pd = Mathf.Max(paper.pd - 2, 60);
                break;
            case 1:
                pd = Mathf.Min(paper.pd + 2, 74);
                break;
            default:
                pd = paper.pd; // Remain the same
                break;
        }

        // Print the retrieved value of pd
        print("Retrieved value: " + pd);

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
}