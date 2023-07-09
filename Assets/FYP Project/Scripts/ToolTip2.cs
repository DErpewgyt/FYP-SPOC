using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToolTip2 : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public TextMeshProUGUI textMesh2;
    public TextMeshProUGUI textMesh3;
    private Coroutine textAlphaChangeCoroutine1; // Coroutine reference for Text1 alpha change
    private Coroutine textAlphaChangeCoroutine2; // Coroutine reference for Text2 alpha change
    private Coroutine textAlphaChangeCoroutine3; // Coroutine reference for Text3 alpha change
    public float alphaChangeSpeed = 2f; // Speed of alpha change
    public float alphaChangeDelay = 1f; // Delay before alpha change
    private bool keyPressHandled = false;


    /*
    void Update()
    {
      if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse input detected");
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
            }
             if (textMesh3 != null)
            {
                if (textAlphaChangeCoroutine3 != null)
                    StopCoroutine(textAlphaChangeCoroutine3);
                textAlphaChangeCoroutine3 = StartCoroutine(ChangeTextAlphaOverTimeWithDelay(textMesh3, 0f, alphaChangeSpeed, alphaChangeDelay));
            }
        }
    }
    */

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse input detected");
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
            }
            if (textMesh3 != null && !keyPressHandled)
            {
                keyPressHandled = true;
                if (textAlphaChangeCoroutine3 != null)
                    StopCoroutine(textAlphaChangeCoroutine3);
                textAlphaChangeCoroutine3 = StartCoroutine(ChangeTextAlphaOverTimeWithDelay(textMesh3, 0f, alphaChangeSpeed, alphaChangeDelay));
                //textMesh3.color = Color.red;
                Color blueColor = ColorUtility.TryParseHtmlString("#008BFF", out Color color) ? color : Color.white;
                textMesh3.color = blueColor;

            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            if (textMesh2 != null)
            {
                //textMesh2.color = Color.red; 
                textMesh2.color = new Color(0f, 0.545f, 1f);
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