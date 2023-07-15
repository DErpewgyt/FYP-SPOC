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

    public int OBJIndicator1 = 1;
    public Animator LineObjective;
    public TextMeshProUGUI AstigAxisTMPleft;
    public RawImage AstigAxisLineleft;
    public bool isAstigAxisAnimationPlayedleft = false;

    public int OBJIndicator2 = 2;
    public Animator LineObjective2;
    public TextMeshProUGUI AstigMagTMPleft;
    public RawImage AstigMagLineleft;
    public bool isAstigMagAnimationPlayedleft = false;
    
    public int OBJIndicator3 = 3;
    public Animator LineObjective3;
    public TextMeshProUGUI AstigAxisTMPright;
    public RawImage AstigAxisLineright;
    public bool isAstigAxisAnimationPlayedright = false;

    public int OBJIndicator4 = 4;
    public Animator LineObjective4;
    public TextMeshProUGUI AstigMagTMPright;
    public RawImage AstigMagLineright;
    public bool isAstigMagAnimationPlayedright = false;
    

    public int OBJIndicator5 = 5;
    public Animator LineObjective5;
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
        MakeAlpha0(AstigMagTMPleft, AstigMagLineleft);
        MakeAlpha0(AstigAxisTMPright, AstigAxisLineright);
        MakeAlpha0(AstigMagTMPright, AstigMagLineright);
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
        
        QuestItems(Checker.isRightSideAstigAxisComplete, isAstigAxisAnimationPlayedleft, LineObjective, AstigAxisTMPleft, AstigMagTMPleft, AstigAxisLineleft, AstigMagLineleft, OBJIndicator1);

        //QuestItems(Checker.isRightSideAstigMagComplete, isAstigMagAnimationPlayedleft, LineObjective2, AstigMagTMPleft, PlaceHolderTMP, AstigMagLineleft, PlaceHolderIMG, OBJIndicator2);

        QuestItems(Checker.isRightSideAstigMagComplete, isAstigMagAnimationPlayedleft, LineObjective2, AstigMagTMPleft, AstigAxisTMPright, AstigMagLineleft, AstigAxisLineright, OBJIndicator2);

        QuestItems(Checker.isLeftSideAstigAxisComplete, isAstigAxisAnimationPlayedright, LineObjective3, AstigAxisTMPright, AstigMagTMPright, AstigAxisLineright, AstigMagLineright, OBJIndicator3);

        QuestItems(Checker.isLeftSideAstigMagComplete, isAstigMagAnimationPlayedright, LineObjective4, AstigMagTMPright, PlaceHolderTMP, AstigMagLineright, PlaceHolderIMG, OBJIndicator4);

        /*
        if (Checker.isRightSideAstigAxisComplete && !isAstigAxisAnimationPlayedleft)
        {
            LineObjective.SetBool("Complete", true);

            if (AstigAxisTMPleft != null && AstigMagTMPleft != null)
            {
                print("1");
                if (textAlphaChangeCoroutine != null)
                    StopCoroutine(textAlphaChangeCoroutine);

                textAlphaChangeCoroutine = StartCoroutine(FadeOutAndInTextOverTimeWithDelay(AstigAxisTMPleft, 0f, AstigMagTMPleft, 1f, alphaChangeSpeed, alphaChangeDelay));
            }

            if (AstigAxisLineleft != null && AstigMagLineleft != null)
            {
                print("1");
                if (lineAlphaChangeCoroutine != null)
                    StopCoroutine(lineAlphaChangeCoroutine);

                lineAlphaChangeCoroutine = StartCoroutine(FadeOutAndInAlphaOverTimeWithDelay(AstigAxisLineleft, 0f, AstigMagLineleft, 1f, alphaChangeSpeed, alphaChangeDelay));
            }
            isAstigAxisAnimationPlayedleft = true;
        }
        else if (Checker.isRightSideAstigMagComplete && !isAstigMagAnimationPlayedleft)
        {
            LineObjective2.SetBool("Complete", true);

            if (AstigMagTMPleft != null)
            {
                print("1");
                if (textAlphaChangeCoroutine != null)

                textAlphaChangeCoroutine = StartCoroutine(FadeOutAndInTextOverTimeWithDelay(AstigMagTMPleft, 0f, PlaceHolderTMP, 1f, alphaChangeSpeed, alphaChangeDelay));
            }
            if (AstigMagLineleft != null)
            {
                print("1");
                if (lineAlphaChangeCoroutine != null)

                lineAlphaChangeCoroutine = StartCoroutine(FadeOutAndInAlphaOverTimeWithDelay(AstigMagLineleft, 0f, PlaceHolderIMG, 1f, alphaChangeSpeed, alphaChangeDelay));
            }
            isAstigMagAnimationPlayedleft = true;
        }
        */
    }



    public void QuestItems(bool previousOBJcompleted, bool isanimationPlayed, Animator lineAnimator, TextMeshProUGUI currentTMP, TextMeshProUGUI nextTMP, RawImage currentIMG, RawImage nextIMG, int CurrentIndicator)
    {
        if (previousOBJcompleted && !isanimationPlayed)
        {
            lineAnimator.SetBool("Complete", true);

            if (currentTMP != null && nextTMP != null)
            {
                print("1");
                if (textAlphaChangeCoroutine != null)
                    StopCoroutine(textAlphaChangeCoroutine);

                textAlphaChangeCoroutine = StartCoroutine(FadeOutAndInTextOverTimeWithDelay(currentTMP, 0f, nextTMP, 1f, alphaChangeSpeed, alphaChangeDelay));
            }

            if (currentIMG != null && nextIMG != null)
            {
                print("1");
                if (lineAlphaChangeCoroutine != null)
                    StopCoroutine(lineAlphaChangeCoroutine);

                lineAlphaChangeCoroutine = StartCoroutine(FadeOutAndInAlphaOverTimeWithDelay(currentIMG, 0f, nextIMG, 1f, alphaChangeSpeed, alphaChangeDelay));
            }
            boolswitch(CurrentIndicator);
        }
    }

    public void boolswitch(int CurrentIndicator)
    {
        switch (CurrentIndicator)
        {
            case 1:
                isAstigAxisAnimationPlayedleft = true;
            break; 
            
            case 2:
                isAstigMagAnimationPlayedleft = true;
            break;

            case 3:
                isAstigAxisAnimationPlayedright = true;
            break;

            case 4:
                isAstigMagAnimationPlayedright= true;
            break;

            case 5:
                PlaceHolderBool = true;
            break;

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

