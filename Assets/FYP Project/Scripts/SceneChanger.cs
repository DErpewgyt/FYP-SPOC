using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 4;
    public Color fadeColor;
    public Image image;

    private IEnumerator Start()
    {
        //image = GetComponent<Image>();
        if (fadeOnStart)
            FadeIn();
        yield return new WaitForSeconds(4);
        gameObject.active = false;
    }

    public void FadeIn()
    {
        Fade(1, 0, fadeColor);
    }

    public void FadeOut()
    {
        Fade(0, 1, fadeColor);
    }

    public void Fade(float alphaIn, float alphaOut, Color fadeColor)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut, fadeColor));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut, Color fadeColor)
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            image.color = newColor;

            timer += Time.deltaTime;
            yield return null;
        }
        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        image.color = newColor2;
    }
}