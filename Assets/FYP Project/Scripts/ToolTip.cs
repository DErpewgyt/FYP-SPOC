using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToolTip : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public TextMeshProUGUI textMesh2;
    private Coroutine textAlphaChangeCoroutine1; // Coroutine reference for Text1 alpha change
    private Coroutine textAlphaChangeCoroutine2; // Coroutine reference for Text2 alpha change
    public float alphaChangeSpeed = 2f; // Speed of alpha change
    public float alphaChangeDelay = 1f; // Delay before alpha change
    public Canvas canvas;
    public float alphaChangeDelayCanva = 6f; // Delay before alpha change
    public ToolTip2 toolTip2Script;

    void Update()
    {
        if (Input.anyKeyDown && ContainsAnyKey(new[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D }))
        {
            Debug.Log("You pressed a key");
            if (textMesh != null)
            {
                if (textAlphaChangeCoroutine1 != null)
                    StopCoroutine(textAlphaChangeCoroutine1);
                textAlphaChangeCoroutine1 = StartCoroutine(ChangeTextAlphaOverTimeWithDelay(textMesh, 0f, alphaChangeSpeed, alphaChangeDelay));
            }
            if (textMesh2 != null)
            {
                if (textAlphaChangeCoroutine2 != null)
                    StopCoroutine(textAlphaChangeCoroutine2);
                textAlphaChangeCoroutine2 = StartCoroutine(ChangeTextAlphaOverTimeWithDelay(textMesh2, 0f, alphaChangeSpeed, alphaChangeDelay));
                StartCoroutine(ActivateCanvasWithDelay());
                toolTip2Script.gameObject.SetActive(true);
            }
             
        }
    }

    bool ContainsAnyKey(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKey(key))
                return true;
        }
        return false;
    }

    IEnumerator ActivateCanvasWithDelay()
{
    yield return new WaitForSeconds(alphaChangeDelayCanva);
    canvas.gameObject.SetActive(true);
}

    IEnumerator ChangeTextAlphaOverTimeWithDelay(TextMeshProUGUI text, float targetAlpha, float speed, float delay)
    {
        yield return new WaitForSeconds(delay);

        Color currentColor = text.color;
        float currentAlpha = currentColor.a;
        float startTime = Time.time;
        float endTime = startTime + Mathf.Abs(targetAlpha - currentAlpha) / speed;

        while (Time.time < endTime)
        {
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
