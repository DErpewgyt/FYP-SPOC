using UnityEngine;

public class Fade : MonoBehaviour
{
    public GameObject background; // black screen to allow for smooth transition
    public CanvasGroup canvasGroup;
    public float fadeTime = 3f; // how long to wait before fading
    public GameObject clicker;
    public GameObject fader;

    private bool skipFade = false; // Flag to skip the fading process
    private int fadeTweenId; // ID of the fading tween
    public static bool ShouldFadeIn = true;

    // Start is called before the first frame update
    private void Start()
    {
        // Check if the scene should fade in or not
        if (ShouldFadeIn)
        {
            fadeTweenId = LeanTween.alphaCanvas(canvasGroup, 0f, fadeTime).setOnComplete(OnFadeComplete).id;
        }
        else
        {
            // If not, instantly finish the fade
            SkipFade();
            ShouldFadeIn = true;  // Reset the flag for the next scene load
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void OnFadeComplete()
    {
        clicker.SetActive(true);
        fader.SetActive(false);
    }

    public void SkipFade()
    {
        skipFade = true;

        // Cancel the tween animation if it is still playing
        if (LeanTween.isTweening(fadeTweenId))
        {
            LeanTween.cancel(fadeTweenId);
        }

        // Set the alpha value of the CanvasGroup to 0
        canvasGroup.alpha = 0f;

        OnFadeComplete();
    }
}