using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ZoomOnInstrument2 : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private Animator dissectedphoropter;
    [SerializeField] private Animator tablestand;
    [SerializeField] private Animator phoropterstand;
    [SerializeField] private Animator keratometer;
    public GameObject maincam;
    public GameObject zoomincam;

    public float transitionDuration = 0.5f;
    
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

    private bool canPlayAnimator = false; // flag to control animator playback

    private Dictionary<Animator, string> animatorDictionary = new Dictionary<Animator, string>(); // Dictionary to store animators and their animation names

    private void Start()
    {
        currentFOV = cam.m_Lens.FieldOfView; // get current fov

        // Disable the animator components on start
        if (dissectedphoropter != null)
        {
            dissectedphoropter.enabled = false;
            animatorDictionary.Add(dissectedphoropter, "PhoropterTransit");
        }
        if (tablestand != null)
        {
            tablestand.enabled = false;
            animatorDictionary.Add(tablestand, "TableStandAnimPhoropt");
        }
        if (phoropterstand != null)
        {
            phoropterstand.enabled = false;
            animatorDictionary.Add(phoropterstand, "phoropterStandTransit");
        }
        if (keratometer != null)
        {
            keratometer.enabled = false;
            animatorDictionary.Add(keratometer, "Keratometer");
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
        foreach (var animator in animatorDictionary.Keys)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
                return true;
        }

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
                if (hit.transform.name == "dissectedphoropter") // if dissectedphoropter is clicked
                {
                    Debug.Log("Clicked");
                    // Your code here to handle the left-click on the "dissectedphoropter" game object
                    maincam.SetActive(false);
                    zoomincam.SetActive(true);
                    controls.SetActive(false);
                    LeanTween.alphaCanvas(canvasGroup, to: 1, fadeTime).setOnComplete(OnFadeComplete);
                    StartCoroutine(ZoomIn());

                    if (canPlayAnimator)
                    {
                        foreach (var animator in animatorDictionary.Keys)
                        {
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
            foreach (var animator in animatorDictionary.Keys)
            {
                animator.enabled = false;
            }
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
            float rotationSpeed = 5f;
            


            float newFOV = Mathf.Lerp(initialFOV, targetFOV, t);
            cam.m_Lens.FieldOfView = newFOV;
            
            if (elapsedTime >= pauseTime && elapsedTime < pauseTime + Time.deltaTime)
            {
                PauseAnimation();
            }
            
            yield return null;
        }
        
        if (canPlayAnimator)
        {
            foreach (var animator in animatorDictionary.Keys)
            {
                animator.enabled = true; // Enable the animator component
                animator.Play(animatorDictionary[animator], 0, pauseTime / animator.GetCurrentAnimatorStateInfo(0).length); // Play the animation from the paused time
            }
        }
    }

    private void PauseAnimation()
    {
        foreach (var animator in animatorDictionary.Keys)
        {
            animator.enabled = false; // Disable the animator component
        }
        isPaused = true;
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
