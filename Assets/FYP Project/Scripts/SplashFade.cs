using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashFade : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 4;
    public Color fadeColor;
    public Image image;

    private IEnumerator Start()
    {
        image = GetComponent<Image>();
        if (fadeOnStart)
            FadeIn();
        yield return new WaitForSeconds(fadeDuration);
        FadeOut();
    }

    public void FadeIn()
    {
        Fade(Color.black, Color.white);
    }

    public void FadeOut()
    {
        Fade(Color.white, Color.black);
    }

    public void Fade(Color startColor, Color endColor)
    {
        StartCoroutine(FadeRoutine(startColor, endColor));
    }

    public IEnumerator FadeRoutine(Color startColor, Color endColor)
    {
        float timer = 0;

        while (timer <= fadeDuration)
        {
            float t = timer / fadeDuration;
            Color newColor = Color.Lerp(startColor, endColor, t);
            image.color = new Color(newColor.r, newColor.g, newColor.b, image.color.a);

            timer += Time.deltaTime;
            yield return null;
        }

        image.color = endColor;
    }
}