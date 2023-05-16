using UnityEngine;

public class Fade : MonoBehaviour
{
    public GameObject clicker;
    public GameObject fader;
    public CanvasGroup canvasGroup;
    public float fadeTime = 3f;
    private bool skipFade = false;
    public static bool ShouldFadeIn = true;

    private void Start()
    {
        if (ShouldFadeIn)
        {
            LeanTween.alphaCanvas(canvasGroup, to: 0, fadeTime).setOnComplete(OnFadeComplete);
        }
        else
        {
            SkipFade();
            ShouldFadeIn = true;
        }
    }

    public void OnFadeComplete()
    {
        clicker.SetActive(true);
        fader.SetActive(false);
    }

    public void SkipFade()
    {
        skipFade = true;
        canvasGroup.alpha = 0f;
        OnFadeComplete();
    }
}