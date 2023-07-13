using TMPro;
using UnityEngine.UI;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveScript : MonoBehaviour
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

    public Animator LineObjective3;
    public TextMeshProUGUI PlaceHolderTMP;
    public RawImage PlaceHolderIMG;
    public bool PlaceHolderBool = false;




    public float alphaChangeSpeed = 2f; // Speed of alpha change
    public float alphaChangeDelay = 2f; // Delay before alpha change

    private Coroutine whiteBGAlphaChangeCoroutine; // Coroutine reference for whiteBG alpha change
    private Coroutine textAlphaChangeCoroutine; // Coroutine reference for Text alpha change
    private Coroutine lineAlphaChangeCoroutine; // Coroutine reference for Line alpha change
    private Coroutine iconAlphaChangeCoroutine; // Coroutine reference for Icon alpha change

    public AIVoiceChecker Checker;

    void Start()
    {
        MakeAlpha0(AstigMagTMP, AstigMagLine);
        MakeAlpha0(PlaceHolderTMP, PlaceHolderIMG);
    }

    void MakeAlpha0(TextMeshProUGUI TMP, RawImage IMG)
    {
        TMP.alpha = 0f;
        Color lineColor = IMG.color;
        lineColor.a = 0f;
        IMG.color = lineColor;
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

            if (AstigAxisTMP != null && AstigMagTMP != null)
            {
                print("1");
                if (textAlphaChangeCoroutine != null)
                    StopCoroutine(textAlphaChangeCoroutine);

                textAlphaChangeCoroutine = StartCoroutine(FadeOutAndInTextOverTimeWithDelay(AstigAxisTMP, 0f, AstigMagTMP, 1f, alphaChangeSpeed, alphaChangeDelay));
            }

            if (AstigAxisLine != null && AstigMagLine != null)
            {
                print("1");
                if (lineAlphaChangeCoroutine != null)
                    StopCoroutine(lineAlphaChangeCoroutine);

                lineAlphaChangeCoroutine = StartCoroutine(FadeOutAndInAlphaOverTimeWithDelay(AstigAxisLine, 0f, AstigMagLine, 1f, alphaChangeSpeed, alphaChangeDelay));
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

                textAlphaChangeCoroutine = StartCoroutine(FadeOutAndInTextOverTimeWithDelay(AstigMagTMP, 0f, PlaceHolderTMP, 1f, alphaChangeSpeed, alphaChangeDelay));
            }
            if (AstigMagLine != null)
            {
                print("1");
                if (lineAlphaChangeCoroutine != null)

                lineAlphaChangeCoroutine = StartCoroutine(FadeOutAndInAlphaOverTimeWithDelay(AstigMagLine, 0f, PlaceHolderIMG, 1f, alphaChangeSpeed, alphaChangeDelay));
            }
            isAstigMagAnimationPlayed = true;
        }
    }

    IEnumerator FadeOutAndInTextOverTimeWithDelay(TextMeshProUGUI fadeOutText, float fadeOutTargetAlpha, TextMeshProUGUI fadeInText, float fadeInTargetAlpha, float speed, float delay)
    {
        print("3");
        yield return new WaitForSeconds(delay);

        Color fadeOutColor = fadeOutText.color;
        Color fadeInColor = fadeInText.color;

        float fadeOutStartTime = Time.time;
        float fadeOutEndTime = fadeOutStartTime + Mathf.Abs(fadeOutTargetAlpha - fadeOutColor.a) / speed;

        float fadeInStartTime = fadeOutEndTime;
        float fadeInEndTime = fadeInStartTime + Mathf.Abs(fadeInTargetAlpha - fadeInColor.a) / speed;

        while (Time.time < fadeInEndTime)
        {
            float fadeOutElapsedTime = Time.time - fadeOutStartTime;
            float fadeOutNormalizedTime = Mathf.Clamp01(fadeOutElapsedTime / (fadeOutEndTime - fadeOutStartTime));
            float fadeOutNewAlpha = Mathf.Lerp(fadeOutColor.a, fadeOutTargetAlpha, fadeOutNormalizedTime);
            fadeOutColor.a = fadeOutNewAlpha;
            fadeOutText.color = fadeOutColor;

            float fadeInElapsedTime = Time.time - fadeInStartTime;
            float fadeInNormalizedTime = Mathf.Clamp01(fadeInElapsedTime / (fadeInEndTime - fadeInStartTime));
            float fadeInNewAlpha = Mathf.Lerp(fadeInColor.a, fadeInTargetAlpha, fadeInNormalizedTime);
            fadeInColor.a = fadeInNewAlpha;
            fadeInText.color = fadeInColor;

            yield return null;
        }

        fadeOutColor.a = fadeOutTargetAlpha;
        fadeOutText.color = fadeOutColor;

        fadeInColor.a = fadeInTargetAlpha;
        fadeInText.color = fadeInColor;
    }

    IEnumerator FadeOutAndInAlphaOverTimeWithDelay(RawImage fadeOutImage, float fadeOutTargetAlpha, RawImage fadeInImage, float fadeInTargetAlpha, float speed, float delay)
    {
        print("3");
        yield return new WaitForSeconds(delay);

        Color fadeOutColor = fadeOutImage.color;
        Color fadeInColor = fadeInImage.color;

        float fadeOutStartTime = Time.time;
        float fadeOutEndTime = fadeOutStartTime + Mathf.Abs(fadeOutTargetAlpha - fadeOutColor.a) / speed;

        float fadeInStartTime = fadeOutEndTime;
        float fadeInEndTime = fadeInStartTime + Mathf.Abs(fadeInTargetAlpha - fadeInColor.a) / speed;

        while (Time.time < fadeInEndTime)
        {
            float fadeOutElapsedTime = Time.time - fadeOutStartTime;
            float fadeOutNormalizedTime = Mathf.Clamp01(fadeOutElapsedTime / (fadeOutEndTime - fadeOutStartTime));
            float fadeOutNewAlpha = Mathf.Lerp(fadeOutColor.a, fadeOutTargetAlpha, fadeOutNormalizedTime);
            fadeOutColor.a = fadeOutNewAlpha;
            fadeOutImage.color = fadeOutColor;

            float fadeInElapsedTime = Time.time - fadeInStartTime;
            float fadeInNormalizedTime = Mathf.Clamp01(fadeInElapsedTime / (fadeInEndTime - fadeInStartTime));
            float fadeInNewAlpha = Mathf.Lerp(fadeInColor.a, fadeInTargetAlpha, fadeInNormalizedTime);
            fadeInColor.a = fadeInNewAlpha;
            fadeInImage.color = fadeInColor;

            yield return null;
        }

        fadeOutColor.a = fadeOutTargetAlpha;
        fadeOutImage.color = fadeOutColor;

        fadeInColor.a = fadeInTargetAlpha;
        fadeInImage.color = fadeInColor;
    }


}

