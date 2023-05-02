using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public GameObject background;// black screen to allow for smooth transition
    public CanvasGroup canvasGroup;
    public float fadeTime = 3f;// how long to wait before fading
    public GameObject clicker;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.alphaCanvas(canvasGroup, to: 0, fadeTime).setOnComplete(OnFadeComplete);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnFadeComplete()
    {
        clicker.SetActive(true);
    }
}
