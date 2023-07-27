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
    public TextMeshProUGUI ObjectiveRefraction;
    public RawImage ObjectiveRefractionLine;
    public bool ObjectiveRefractionLineBool = false;
    public GameObject Obj1;

    public int OBJIndicator2 = 2;
    public Animator LineObjective2;
    public TextMeshProUGUI CloseLeftEye;
    public RawImage CloseLeftEyeLine;
    public bool CloseLeftEyeLineBool = false;
    public GameObject Obj2;

    public int OBJIndicator3 = 3;
    public Animator LineObjective3;
    public TextMeshProUGUI LSRight;
    public RawImage LSRightLine;
    public bool LSRightLineBool = false;
    public GameObject Obj3;

    public int OBJIndicator4 = 4;
    public Animator LineObjective4;
    public TextMeshProUGUI AstigAxisTMPright;
    public RawImage AstigAxisLineright;
    public bool isAstigAxisAnimationPlayedright = false;
    public GameObject Obj4;

    public int OBJIndicator5 = 5;
    public Animator LineObjective5;
    public TextMeshProUGUI AstigMagTMPright;
    public RawImage AstigMagLineright;
    public bool isAstigMagAnimationPlayedright = false;
    public GameObject Obj5;

    public int OBJIndicator6 = 6;
    public Animator LineObjective6;
    public TextMeshProUGUI RightEyeFinal;
    public RawImage RightEyeFinalLine;
    public bool RightEyeFinalLineBool = false;
    public GameObject Obj6;

    public int OBJIndicator7 = 7;
    public Animator LineObjective7;
    public TextMeshProUGUI SwitchEyes;
    public RawImage SwitchEyesLine;
    public bool SwitchEyesLineBool = false;
    public GameObject Obj7;

    public int OBJIndicator8 = 8;
    public Animator LineObjective8;
    public TextMeshProUGUI LSLeft;
    public RawImage LSLeftLine;
    public bool LSLeftLineBool = false;
    public GameObject Obj8;

    public int OBJIndicator9 = 9;
    public Animator LineObjective9;
    public TextMeshProUGUI AstigAxisTMPleft;
    public RawImage AstigAxisLineleft;
    public bool isAstigAxisAnimationPlayedleft = false;
    public GameObject Obj9;

    public int OBJIndicator10 = 10;
    public Animator LineObjective10;
    public TextMeshProUGUI AstigMagTMPleft;
    public RawImage AstigMagLineleft;
    public bool isAstigMagAnimationPlayedleft = false;
    public GameObject Obj10;

    public int OBJIndicator11 = 11;
    public Animator LineObjective11;
    public TextMeshProUGUI LeftEyeFinal;
    public RawImage LeftEyeFinalLine;
    public bool LeftEyeFinalLineBool = false;
    public GameObject Obj11;

    public int OBJIndicator12 = 12;
    public Animator LineObjective12;
    public TextMeshProUGUI Congrats;
    public RawImage CongratsLine ;
    public bool CongratsLineBool = false;
    public GameObject Obj12;

    public int OBJIndicatorleftJCC = 13;
    public Animator LineObjectiveleftJCC;
    public TextMeshProUGUI leftJCCTMP;
    public RawImage leftJCCIMG;
    public bool leftJCCBool = false;
    public GameObject leftJCC;

    public int OBJIndicatorrightJCC = 14;
    public Animator LineObjectiverightJCC;
    public TextMeshProUGUI rightJCCTMP;
    public RawImage rightJCCIMG;
    public bool rightJCCBool = false;
    public GameObject rightJCC;



    public float alphaChangeSpeed = 2f; // Speed of alpha change
    public float alphaChangeDelay = 2f; // Delay before alpha change
    public AstigmatismLensMovement AstigmatismLensMove;

    private Coroutine whiteBGAlphaChangeCoroutine; // Coroutine reference for whiteBG alpha change
    private Coroutine textAlphaChangeCoroutine; // Coroutine reference for Text alpha change
    private Coroutine lineAlphaChangeCoroutine; // Coroutine reference for Line alpha change
    private Coroutine iconAlphaChangeCoroutine; // Coroutine reference for Icon alpha change

    public AIVoiceChecker Checker;

    public GameObject Submit;

    void Start()
    {
        MakeAlpha0(CloseLeftEye, CloseLeftEyeLine);
        MakeAlpha0(LSRight, LSRightLine);
        MakeAlpha0(AstigAxisTMPright, AstigAxisLineright);
        MakeAlpha0(AstigMagTMPright, AstigMagLineright);
        MakeAlpha0(RightEyeFinal, RightEyeFinalLine);

        MakeAlpha0(SwitchEyes, SwitchEyesLine);
        MakeAlpha0(LSLeft, LSLeftLine);
        MakeAlpha0(AstigAxisTMPleft, AstigAxisLineleft);
        MakeAlpha0(AstigMagTMPleft, AstigMagLineleft);
        MakeAlpha0(LeftEyeFinal, LeftEyeFinalLine);
        MakeAlpha0(Congrats, CongratsLine);

        MakeAlpha0(leftJCCTMP, leftJCCIMG);
        MakeAlpha0(rightJCCTMP, rightJCCIMG);

        Submit.SetActive(false);


        //MakeAlpha0(AstigMagTMPleft, AstigMagLineleft);
        //MakeAlpha0(AstigAxisTMPright, AstigAxisLineright);
        //MakeAlpha0(AstigMagTMPright, AstigMagLineright);


        //MakeAlpha0(PlaceHolderTMP, PlaceHolderIMG);
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
        //between 5 and 6
        //between 10 and 11
        QuestItems(Checker.isSetupComplete, ObjectiveRefractionLineBool, LineObjective, ObjectiveRefraction, CloseLeftEye, ObjectiveRefractionLine, CloseLeftEyeLine, OBJIndicator1, Obj1);

        QuestItems(Checker.IsRighteyeOpen, CloseLeftEyeLineBool, LineObjective2, CloseLeftEye, LSRight, CloseLeftEyeLine, LSRightLine, OBJIndicator2, Obj2);

        QuestItems(Checker.isRightSideLSComplete, LSRightLineBool, LineObjective3, LSRight, AstigAxisTMPright, LSRightLine, AstigAxisLineright, OBJIndicator3, Obj3);

        QuestItems(Checker.isRightSideAstigAxisComplete, isAstigAxisAnimationPlayedright, LineObjective4, AstigAxisTMPright, AstigMagTMPright, AstigAxisLineright, AstigMagLineright, OBJIndicator4, Obj4);

        QuestItems(Checker.isRightSideAstigMagComplete, isAstigMagAnimationPlayedright, LineObjective5, AstigMagTMPright, leftJCCTMP, AstigMagLineright, leftJCCIMG, OBJIndicator5, Obj5);



        QuestItems(AstigmatismLensMove.isLeftJccFlippedBack, leftJCCBool, LineObjectiveleftJCC, leftJCCTMP, RightEyeFinal, leftJCCIMG, RightEyeFinalLine, OBJIndicatorleftJCC, leftJCC);



        QuestItems(Checker.isRightSideFinalComplete, RightEyeFinalLineBool, LineObjective6, RightEyeFinal, SwitchEyes, RightEyeFinalLine, SwitchEyesLine, OBJIndicator6, Obj6);

        QuestItems(Checker.IsLefteyeOpen, SwitchEyesLineBool, LineObjective7, SwitchEyes, LSLeft, SwitchEyesLine, LSLeftLine, OBJIndicator7, Obj7);

        QuestItems(Checker.isLeftSideLSComplete, LSLeftLineBool, LineObjective8, LSLeft, AstigAxisTMPleft, LSLeftLine, AstigAxisLineleft, OBJIndicator8, Obj8);

        QuestItems(Checker.isLeftSideAstigAxisComplete, isAstigAxisAnimationPlayedleft, LineObjective9, AstigAxisTMPleft, AstigMagTMPleft, AstigAxisLineleft, AstigMagLineleft, OBJIndicator9, Obj9);

        QuestItems(Checker.isLeftSideAstigMagComplete, isAstigMagAnimationPlayedleft, LineObjective10, AstigMagTMPleft , rightJCCTMP, AstigMagLineleft , rightJCCIMG, OBJIndicator10, Obj10);



        QuestItems(AstigmatismLensMove.isRightJccFlippedBack, rightJCCBool, LineObjectiverightJCC, rightJCCTMP, LeftEyeFinal, rightJCCIMG, LeftEyeFinalLine, OBJIndicatorrightJCC, rightJCC);

        QuestItems(Checker.isLeftSideFinalComplete, LeftEyeFinalLineBool, LineObjective11, LeftEyeFinal, Congrats, LeftEyeFinalLine, CongratsLine, OBJIndicator11, Obj11);
    }



    public void QuestItems(bool previousOBJcompleted, bool isanimationPlayed, Animator lineAnimator, TextMeshProUGUI currentTMP, TextMeshProUGUI nextTMP, RawImage currentIMG, RawImage nextIMG, int CurrentIndicator, GameObject Obj)
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
            boolswitch(CurrentIndicator, Obj);
        }
    }

    IEnumerator WaitAndSetActive(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }



    public void boolswitch(int CurrentIndicator, GameObject Obj)
    {
        switch (CurrentIndicator)
        {
            case 1:
                ObjectiveRefractionLineBool = true;
                break; 
            
            case 2:
                CloseLeftEyeLineBool = true;
                break;

            case 3:
                LSRightLineBool = true;
                break;

            case 4:
                isAstigAxisAnimationPlayedright = true;
                break;

            case 5:
                isAstigMagAnimationPlayedright = true;
                break;

            case 6:
                RightEyeFinalLineBool = true;
                break;

            case 7:
                SwitchEyesLineBool = true;
                break;

            case 8:
                LSLeftLineBool = true;
                break;

            case 9:
                isAstigAxisAnimationPlayedleft = true;
                break;

            case 10:
                isAstigMagAnimationPlayedleft = true;
                break;

            case 11:
                LeftEyeFinalLineBool = true; 
                Submit.SetActive(true);
                break;

            case 12:
                CongratsLineBool = true;

                break;

            case 13:
                leftJCCBool = true;

                break;

            case 14:
                rightJCCBool = true;

                break;



            default:
                print("Ono :( its a logical error");
                break;

        }

        StartCoroutine(WaitAndSetActive(Obj, 3.5f));

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

