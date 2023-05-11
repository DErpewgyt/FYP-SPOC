using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeLogo : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 4f;
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
        StartCoroutine(FadeRoutine(0f, 1f));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeRoutine(1f, 0f));
    }

    public IEnumerator FadeRoutine(float alphaStart, float alphaEnd)
    {
        float timer = 0f;

        while (timer <= fadeDuration)
        {
            float t = timer / fadeDuration;
            float alpha = Mathf.Lerp(alphaStart, alphaEnd, t);
            Color newColor = image.color;
            newColor.a = alpha;
            image.color = newColor;

            timer += Time.deltaTime;
            yield return null;
        }

        Color finalColor = image.color;
        finalColor.a = alphaEnd;
        image.color = finalColor;
    }
}