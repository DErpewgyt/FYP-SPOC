using UnityEngine;

public class Fade : MonoBehaviour
{
    public GameObject clicker; // clicker gameobject
    public GameObject fader; // fader gameobject

    public CanvasGroup canvasGroup; // canvas group to control black screen

    public float fadeTime = 3f; // duration of fade

    public static bool FadeChecker = true; // indicator to skip fade animation or not

    private void Start()
    {
        if (FadeChecker)
        {
            LeanTween.alphaCanvas(canvasGroup, to: 0, fadeTime).setOnComplete(OnFadeComplete);
        }
        else
        {
            SkipFade();
            FadeChecker = true; // reset indicator
        }
    }

    public void OnFadeComplete() // after fade completes do this
    {
        clicker.SetActive(true);
        fader.SetActive(false);
    }

    public void SkipFade()
    {
        canvasGroup.alpha = 0f;
        OnFadeComplete();
    }
}