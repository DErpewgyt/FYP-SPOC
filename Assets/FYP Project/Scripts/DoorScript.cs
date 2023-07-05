using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorScript : MonoBehaviour
{
    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5;
    public AudioSource DoorOpen;
    public AudioSource DoorClose;
    private bool opened = false;
    private Animator anim;
    public Animator objective;
    public RawImage whiteBG; // Reference to the RawImage component
    public TextMeshProUGUI textMesh;
    public RawImage Line;
    public RawImage Icon;
    public float alphaChangeSpeed = 2f; // Speed of alpha change
    public float alphaChangeDelay = 1f; // Delay before alpha change

    private Coroutine whiteBGAlphaChangeCoroutine; // Coroutine reference for whiteBG alpha change
    private Coroutine textAlphaChangeCoroutine; // Coroutine reference for Text alpha change
    private Coroutine lineAlphaChangeCoroutine; // Coroutine reference for Line alpha change
    private Coroutine iconAlphaChangeCoroutine; // Coroutine reference for Icon alpha change

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Pressed();
            Debug.Log("You Left Clicked");
        }
    }

    void Pressed()
    {
        RaycastHit doorhit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
        {
            if (doorhit.transform.tag == "Door")
            {
                anim = doorhit.transform.GetComponentInParent<Animator>();

                if (!opened)
                {
                    objective.SetBool("Complete", true);
                    DoorOpen.Play();

                    if (whiteBG != null)
                    {
                        if (whiteBGAlphaChangeCoroutine != null)
                            StopCoroutine(whiteBGAlphaChangeCoroutine);
                        whiteBGAlphaChangeCoroutine = StartCoroutine(ChangeAlphaOverTimeWithDelay(whiteBG, 0f, alphaChangeSpeed, alphaChangeDelay));
                    }
                    if (textMesh != null)
                    {
                        if (textAlphaChangeCoroutine != null)
                            StopCoroutine(textAlphaChangeCoroutine);
                        textAlphaChangeCoroutine = StartCoroutine(ChangeTextAlphaOverTimeWithDelay(textMesh, 0f, alphaChangeSpeed, alphaChangeDelay));
                    }
                    if (Line != null)
                    {
                        if (lineAlphaChangeCoroutine != null)
                            StopCoroutine(lineAlphaChangeCoroutine);
                        lineAlphaChangeCoroutine = StartCoroutine(ChangeAlphaOverTimeWithDelay(Line, 0f, alphaChangeSpeed, alphaChangeDelay));
                    }
                    if (Icon != null)
                    {
                        if (iconAlphaChangeCoroutine != null)
                            StopCoroutine(iconAlphaChangeCoroutine);
                        iconAlphaChangeCoroutine = StartCoroutine(ChangeAlphaOverTimeWithDelay(Icon, 0f, alphaChangeSpeed, alphaChangeDelay));
                    }
                }
                else
                {
                    DoorClose.Play();
                }

                opened = !opened;
                anim.SetBool("Opened", opened);
            }
        }
    }

    IEnumerator ChangeAlphaOverTimeWithDelay(RawImage image, float targetAlpha, float speed, float delay)
    {
        yield return new WaitForSeconds(delay);

        Color currentColor = image.color;
        float currentAlpha = currentColor.a;
        float startTime = Time.time;
        float endTime = startTime + Mathf.Abs(targetAlpha - currentAlpha) / speed;

        while (Time.time < endTime)
        {
            float elapsedTime = Time.time - startTime;
            float normalizedTime = Mathf.Clamp01(elapsedTime / (endTime - startTime));
            float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, normalizedTime);
            currentColor.a = newAlpha;
            image.color = currentColor;
            yield return null;
        }

        currentColor.a = targetAlpha;
        image.color = currentColor;
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
