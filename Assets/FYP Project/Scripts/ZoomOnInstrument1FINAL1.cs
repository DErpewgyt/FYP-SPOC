using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoomOnInstrument1FINAL1 : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private Animator newkeratometer;
    [SerializeField] private Animator tablestand;
    [SerializeField] private Animator phoropterstand;
    [SerializeField] private Animator phoropter;
    private float targetFOV; // target fov after zoomed
    private float zoomSpeed; // zoom speed
    public float raycastDistance = 10f; // how far instrument can be clicked
    private float currentFOV; // current fov of camera
    public float fadeTime = 3f; // fade duration
    public Transform camTransform;

    public GameObject controls; // player control

    public string sceneToLoad; // scene to transition to

    public CanvasGroup canvasGroup; // canvasGroup to control alpha

    private bool canPlayAnimator = false; // flag to control animator playback

    private void Start()
    {
        currentFOV = cam.m_Lens.FieldOfView; // get current fov

        // Disable the animator component on start
        if (newkeratometer != null)
        {
            newkeratometer.enabled = false;
        }
        if (tablestand != null)
        {
            tablestand.enabled = false;
        }
        if (phoropterstand != null)
        {
            phoropterstand.enabled = false;
        }
        if (phoropter != null)
        {
            phoropter.enabled = false;
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
                    Debug.Log("clicked");
                    controls.SetActive(false);
                    LeanTween.alphaCanvas(canvasGroup, to: 1, fadeTime).setOnComplete(OnFadeComplete);
                    StartCoroutine(ZoomIn());

                    if (canPlayAnimator && newkeratometer != null)
                    {
                        newkeratometer.enabled = true; // Enable the animator component
                        tablestand.enabled = true; // Enable the animator component
                        phoropterstand.enabled = true; // Enable the animator component
                        phoropter.enabled = true; // Enable the animator component
                        newkeratometer.SetTrigger("PlayAnimation"); // Play the animator trigger
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

 private IEnumerator ZoomIn() // zoom in gradually
    {
        while (Mathf.Abs(currentFOV - targetFOV) > 0.01f)
        {
            currentFOV = Mathf.Lerp(currentFOV, targetFOV, Time.deltaTime * zoomSpeed);
            cam.m_Lens.FieldOfView = currentFOV;
            yield return null;
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
