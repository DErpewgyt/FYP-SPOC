using TMPro;
using UnityEngine.UI;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveBackup : MonoBehaviour
{
    /*
    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5;
    public AudioSource DoorOpen;
    public AudioSource DoorClose;
    private bool opened = false;
    */
    private Animator anim;


    public RawImage whiteBG; // Reference to the RawImage component
    public RawImage Icon;

    public Animator LineObjective;
    public TextMeshProUGUI AstigAxisTMP;
    public RawImage AstigAxisLine;
    public bool isAstigAxisAnimationPlayed = false;

    public Animator LineObjective2;
    public TextMeshProUGUI AstigMagTMP;
    public RawImage AstigMagLine;
    public bool isAstigMagAnimationPlayed = false;




    public float alphaChangeSpeed = 2f; // Speed of alpha change
    public float alphaChangeDelay = 2f; // Delay before alpha change
    public float alphaChangeDelayCanva = 6f; // Delay before alpha change

    private Coroutine whiteBGAlphaChangeCoroutine; // Coroutine reference for whiteBG alpha change
    private Coroutine textAlphaChangeCoroutine; // Coroutine reference for Text alpha change
    private Coroutine lineAlphaChangeCoroutine; // Coroutine reference for Line alpha change
    private Coroutine iconAlphaChangeCoroutine; // Coroutine reference for Icon alpha change

    public AIVoiceChecker Checker;

    void Start()
    {
        AstigMagTMP.gameObject.SetActive(false);
        AstigMagLine.gameObject.SetActive(false);

    }
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Pressed();
            Debug.Log("You Left Clicked");
        }
        */

        if (Checker.isRightSideAstigAxisComplete && !isAstigAxisAnimationPlayed)
        {
            LineObjective.SetBool("Complete", true);

            if (AstigAxisTMP != null)
            {
                print("1");
                if (textAlphaChangeCoroutine != null)
                    print("2");
                //StopCoroutine(textAlphaChangeCoroutine); Somehow removing this line solves all my problems
                textAlphaChangeCoroutine = StartCoroutine(ChangeTextAlphaOverTimeWithDelay(AstigAxisTMP, 0f, alphaChangeSpeed, alphaChangeDelay));
            }
            if (AstigAxisLine != null)
            {
                print("1");
                if (lineAlphaChangeCoroutine != null)
                    print("2");
                //StopCoroutine(textAlphaChangeCoroutine); Somehow removing this line solves all my problems
                lineAlphaChangeCoroutine = StartCoroutine(ChangeAlphaOverTimeWithDelay(AstigAxisLine, 0f, alphaChangeSpeed, alphaChangeDelay));
            }
            isAstigAxisAnimationPlayed = true;
        }
        else if (Checker.isRightSideAstigMagComplete && !isAstigMagAnimationPlayed)
        {
            LineObjective2.SetBool("Complete", true);

            if (AstigMagTMP != null)
            {
                print("1");
                if (textAlphaChangeCoroutine != null)
                    print("2");
                textAlphaChangeCoroutine = StartCoroutine(ChangeTextAlphaOverTimeWithDelay(AstigMagTMP, 0f, alphaChangeSpeed, alphaChangeDelay));
            }
            if (AstigMagLine != null)
            {
                print("1");
                if (lineAlphaChangeCoroutine != null)
                    print("2");
                lineAlphaChangeCoroutine = StartCoroutine(ChangeAlphaOverTimeWithDelay(AstigMagLine, 0f, alphaChangeSpeed, alphaChangeDelay));
            }
            isAstigAxisAnimationPlayed = true;
        }
    }

    IEnumerator ChangeAlphaOverTimeWithDelay(RawImage image, float targetAlpha, float speed, float delay)
    {
        print("3");
        yield return new WaitForSeconds(delay);

        Color currentColor = image.color;
        float currentAlpha = currentColor.a;
        float startTime = Time.time;
        float endTime = startTime + Mathf.Abs(targetAlpha - currentAlpha) / speed;

        while (Time.time < endTime)
        {
            print("4");
            float elapsedTime = Time.time - startTime;
            float normalizedTime = Mathf.Clamp01(elapsedTime / (endTime - startTime));
            float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, normalizedTime);
            currentColor.a = newAlpha;
            image.color = currentColor;
            yield return null;
        }

        currentColor.a = targetAlpha;
        image.color = currentColor;
    }

    IEnumerator ChangeTextAlphaOverTimeWithDelay(TextMeshProUGUI text, float targetAlpha, float speed, float delay)
    {
        print("3");
        yield return new WaitForSeconds(delay);

        Color currentColor = text.color;
        float currentAlpha = currentColor.a;
        float startTime = Time.time;
        float endTime = startTime + Mathf.Abs(targetAlpha - currentAlpha) / speed;

        while (Time.time < endTime)
        {
            print("4");
            float elapsedTime = Time.time - startTime;
            float normalizedTime = Mathf.Clamp01(elapsedTime / (endTime - startTime));
            float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, normalizedTime);
            currentColor.a = newAlpha;
            text.color = currentColor;
            yield return null;
        }

        currentColor.a = targetAlpha;
        text.color = currentColor;
    }
}