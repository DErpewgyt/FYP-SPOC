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

    public bool Wkey;
    public bool Akey;
    public bool Skey;
    public bool Dkey;
    private bool keyPressHandled = false;
    private void Start()
    {
        Wkey = false;
        Akey = false;
        Skey = false;
        Dkey = false;
    }

    void Update()
    {

            if (Input.GetKeyDown(KeyCode.W))
            {
                Wkey = true;

                if (textMesh2 != null)
                {
                    // Get the current text of textMesh2
                    string currentText = textMesh2.text;

                    // Replace "[W]" with the colored version
                    string modifiedText = currentText.Replace("[W]", "<color=#FF0000>[W]</color>");

                    // Set the modified text back to textMesh2
                    textMesh2.text = modifiedText;
                }
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                if (textMesh2 != null)
                {
                    // Get the current text of textMesh2
                    string currentText = textMesh2.text;

                    // Replace the colored version of "[W]" with the original version
                    string modifiedText = currentText.Replace("<color=#FF0000>[W]</color>", "[W]");

                    // Set the modified text back to textMesh2
                    textMesh2.text = modifiedText;
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Akey = true;

                if (textMesh2 != null)
                {
                    // Get the current text of textMesh2
                    string currentText = textMesh2.text;

                    // Replace "[A]" with the colored version
                    string modifiedText = currentText.Replace("[A]", "<color=#00FF00>[A]</color>");

                    // Set the modified text back to textMesh2
                    textMesh2.text = modifiedText;
                }
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                if (textMesh2 != null)
                {
                    // Get the current text of textMesh2
                    string currentText = textMesh2.text;

                    // Replace the colored version of "[A]" with the original version
                    string modifiedText = currentText.Replace("<color=#00FF00>[A]</color>", "[A]");

                    // Set the modified text back to textMesh2
                    textMesh2.text = modifiedText;
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Skey = true;

                if (textMesh2 != null)
                {
                    // Get the current text of textMesh2
                    string currentText = textMesh2.text;

                    // Replace "[S]" with the colored version
                    string modifiedText = currentText.Replace("[S]", "<color=#0000FF>[S]</color>");

                    // Set the modified text back to textMesh2
                    textMesh2.text = modifiedText;
                }
            }
            if (Input.GetKeyUp(KeyCode.S))
            {

                if (textMesh2 != null)
                {
                    // Get the current text of textMesh2
                    string currentText = textMesh2.text;

                    // Replace the colored version of "[S]" with the original version
                    string modifiedText = currentText.Replace("<color=#0000FF>[S]</color>", "[S]");

                    // Set the modified text back to textMesh2
                    textMesh2.text = modifiedText;
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Dkey = true;

                if (textMesh2 != null)
                {
                    // Get the current text of textMesh2
                    string currentText = textMesh2.text;

                    // Replace "[D]" with the colored version
                    string modifiedText = currentText.Replace("[D]", "<color=#FF00FF>[D]</color>");

                    // Set the modified text back to textMesh2
                    textMesh2.text = modifiedText;
                }
            }
            if (Input.GetKeyUp(KeyCode.D))
            {


                if (textMesh2 != null)
                {
                    // Get the current text of textMesh2
                    string currentText = textMesh2.text;

                    // Replace the colored version of "[D]" with the original version
                    string modifiedText = currentText.Replace("<color=#FF00FF>[D]</color>", "[D]");

                    // Set the modified text back to textMesh2
                    textMesh2.text = modifiedText;
                }
            }


        //if (Input.anyKeyDown && ContainsAnyKey(new[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D }))
        if (Wkey && Akey && Skey && Dkey && !keyPressHandled)
            {
            keyPressHandled = true;
            Debug.Log("You pressed a key");
            if (textMesh != null)
            {
                print("1");
                if (textAlphaChangeCoroutine1 != null)
                StopCoroutine(textAlphaChangeCoroutine1);
                textAlphaChangeCoroutine1 = StartCoroutine(ChangeTextAlphaOverTimeWithDelay(textMesh, 0f, alphaChangeSpeed, alphaChangeDelay));
                print("2");
            }
            if (textMesh2 != null)
            {
                print("3");
                if (textAlphaChangeCoroutine2 != null)
                    StopCoroutine(textAlphaChangeCoroutine2);
                textAlphaChangeCoroutine2 = StartCoroutine(ChangeTextAlphaOverTimeWithDelay(textMesh2, 0f, alphaChangeSpeed, alphaChangeDelay));
                StartCoroutine(ActivateCanvasWithDelay());
                print("4");
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
        toolTip2Script.gameObject.SetActive(true);
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