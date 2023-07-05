using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class ZoomOnInstrument1FINAL : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private Animator newkeratometer;
    [SerializeField] private Animator tablestand;
    [SerializeField] private Animator phoropterstand;
    [SerializeField] private Animator phoropter;
    public GameObject maincam;
    public GameObject zoomincam;
    public float transitionDuration = 0.5f;
    
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

    private bool isPaused = false;
    private float pauseTime = 160f; // The time in seconds to pause the animation (2 minutes and 40 seconds)

    private float targetFOV; // target fov after zoomed
    private float zoomSpeed; // zoom speed
    public float raycastDistance = 10f; // how far instrument can be clicked
    private float currentFOV; // current fov of camera
    public float fadeTime = 3f; // fade duration

    public GameObject controls; // player control

    public string sceneToLoad; // scene to transition to

    public CanvasGroup canvasGroup; // canvasGroup to control alpha

    private Dictionary<Animator, string> animatorDictionary = new Dictionary<Animator, string>(); // Dictionary to store animators and their animation names

    private bool canPlayAnimator = false; // flag to control animator playback

    private void Start()
    {
        currentFOV = cam.m_Lens.FieldOfView; // get current fov

        // Disable the animator component on start
        if (newkeratometer != null)
        {
            newkeratometer.enabled = false;
            animatorDictionary.Add(newkeratometer, "keratometertransit");
        }
        if (tablestand != null)
        {
            tablestand.enabled = false;
            animatorDictionary.Add(tablestand, "TableStandAnimation");
        }
        if (phoropterstand != null)
        {
            phoropterstand.enabled = false;
            animatorDictionary.Add(phoropterstand, "phoropterStand");
        }
        if (phoropter != null)
        {
            phoropter.enabled = false;
            animatorDictionary.Add(phoropter, "phoropterAnim0");
        }

        // Enable animator playback after a short delay
        StartCoroutine(EnableAnimatorPlayback());
    }

    private IEnumerator EnableAnimatorPlayback()
    {
        yield return new WaitForSeconds(0.1f); // Delay before enabling animator playback
        canPlayAnimator = true;
    }

    private bool IsAnimatorPlaying()
    {
        if (newkeratometer != null && newkeratometer.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
            return true;

        if (tablestand != null && tablestand.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
            return true;

        if (phoropterstand != null && phoropterstand.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
            return true;

        if (phoropter != null && phoropter.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
            return true;

        return false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            RaycastHit hit; // raycast variable
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); // create raycast from the center of the camera
            if (Physics.Raycast(ray, out hit, raycastDistance)) // check if raycast hit anything
            {
                
                Debug.Log("Hit object: " + hit.transform.name); // print whatever raycast hits
                if (hit.transform.name == "newkeratometer") // if keratometer is clicked
                {
                    
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

                    Debug.Log("Clicked");
                    // Your code here to handle the left-click on the "newkeratometer" game object
                    
                    maincam.SetActive(false);
                    zoomincam.SetActive(true);
                    controls.SetActive(false);
                    LeanTween.alphaCanvas(canvasGroup, to: 1, fadeTime).setOnComplete(OnFadeComplete);
                    StartCoroutine(ZoomIn());

                    if (canPlayAnimator)
                    {
                        foreach (var animator in animatorDictionary.Keys)
                        {
                            objective.SetBool("Complete2", true);
                            animator.enabled = true; // Enable the animator component
                            animator.Play(animatorDictionary[animator]); // Play the corresponding animation
                        }
                    }
                }
            }
        }

        // Check if all the animators have finished playing
        if (!IsAnimatorPlaying())
        {
            // Disable the animator components
            if (newkeratometer != null)
                newkeratometer.enabled = false;

            if (tablestand != null)
                tablestand.enabled = false;

            if (phoropterstand != null)
                phoropterstand.enabled = false;

            if (phoropter != null)
                phoropter.enabled = false;
        }
    }

    private IEnumerator ZoomIn()
    {
        
        float initialFOV = cam.m_Lens.FieldOfView;
        float elapsedTime = 0f;
        float zoomDuration = 4f;
        targetFOV = 30f; // Set the desired field of view value

        while (Mathf.Abs(currentFOV - targetFOV) > 0.01f || elapsedTime < zoomDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / transitionDuration);
        
            
        

            float newFOV = Mathf.Lerp(initialFOV, targetFOV, t);
            cam.m_Lens.FieldOfView = newFOV;
            
            if (elapsedTime >= pauseTime && elapsedTime < pauseTime + Time.deltaTime)
            {
                PauseAnimation();
            }
            
            yield return null;
        }
        
        if (canPlayAnimator && newkeratometer != null)
        {
            newkeratometer.enabled = true; // Enable the animator component
            tablestand.enabled = true; // Enable the animator component
            phoropterstand.enabled = true; // Enable the animator component
            phoropter.enabled = true; // Enable the animator component
            newkeratometer.Play("YourAnimationName", 0, pauseTime / newkeratometer.GetCurrentAnimatorStateInfo(0).length); // Play the animator animation from the paused time
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

    private void PauseAnimation()
    {
        if (newkeratometer != null)
        {
            newkeratometer.enabled = false; // Disable the animator component
            tablestand.enabled = false; // Disable the animator component
            phoropterstand.enabled = false; // Disable the animator component
            phoropter.enabled = false; // Disable the animator component
            isPaused = true;
        }
    }

    public void OnFadeComplete() // go to next scene
    {
        StartCoroutine(FadeDelay());
    }

    private IEnumerator FadeDelay()
    {
        yield return new WaitForSeconds(1f); // Wait for 1 second

        LeanTween.alphaCanvas(canvasGroup, to: 1, fadeTime).setOnComplete(LoadNextScene);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
        controls.SetActive(false); // deactivate control
        controls = null; // reset control
    }
}
