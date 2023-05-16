using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoomOnInstrument : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    public float targetFOV;
    public float zoomSpeed;
    public float raycastDistance = 10f;
    private float currentFOV;
    public GameObject background;// black screen to allow for smooth transition
    public CanvasGroup canvasGroup;
    public float fadeTime = 3f;// how long to wait before fading
    public string sceneToLoad;// scene to transition to
    public GameObject controls;

    private void Start()
    {
        currentFOV = cam.m_Lens.FieldOfView;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            {
                RaycastHit hit; // Create a RaycastHit variable to store information about the hit object
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); // Cast a ray from the center of the camera's viewport

                if (Physics.Raycast(ray, out hit, raycastDistance)) // Check if the raycast hits any object within a certain distance
                {
                    Debug.Log("Hit object: " + hit.transform.name); // Print the name of the object hit by the raycast
                    if (hit.transform.name == "newkeratometer")
                    {
                        Debug.Log("clicked");
                        controls.SetActive(false);
                        StartCoroutine(ZoomIn());
                        FadeToLevel(sceneToLoad);
                    }
                }
            }
        }
    }

    private IEnumerator ZoomIn()
    {
        while (Mathf.Abs(currentFOV - targetFOV) > 0.01f)
        {
            currentFOV = Mathf.Lerp(currentFOV, targetFOV, Time.deltaTime * zoomSpeed);
            cam.m_Lens.FieldOfView = currentFOV;
            yield return null;
        }
    }

    public void FadeToLevel(string sceneName)// fade to next level function
    {
        sceneToLoad = sceneName;
        LeanTween.alphaCanvas(canvasGroup, to: 1, fadeTime).setOnComplete(OnFadeComplete);
    }

    public void OnFadeComplete() // go to next scene
    {
        SceneManager.LoadScene(sceneToLoad);
        controls.SetActive(false); // Ensure controls are deactivated
        controls = null; // Set controls to null if it's not needed in the next scene
    }
}