using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoomOnInstrument : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;

    public float targetFOV; // target fov after zoomed
    public float zoomSpeed; // zoom speed
    public float raycastDistance = 10f; // how far instrument can be clicked
    private float currentFOV; // current fov of camera
    public float fadeTime = 3f; // fade duration

    public GameObject background; // black screen
    public GameObject controls; // player control

    public string sceneToLoad; // scene to transition to
    public CanvasGroup canvasGroup; // canvasGroup to control alpha

    private void Start()
    {
        currentFOV = cam.m_Lens.FieldOfView; // get current fov
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            {
                RaycastHit hit; // raycast variable
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); // create raycast from the center of the camera

                if (Physics.Raycast(ray, out hit, raycastDistance)) // check if raycast hit anything
                {
                    Debug.Log("Hit object: " + hit.transform.name); // print whatever raycast hits
                    if (hit.transform.name == "newkeratometer") // if keratometer zoom in
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

    private IEnumerator ZoomIn() // zoom in gradually
    {
        while (Mathf.Abs(currentFOV - targetFOV) > 0.01f)
        {
            currentFOV = Mathf.Lerp(currentFOV, targetFOV, Time.deltaTime * zoomSpeed);
            cam.m_Lens.FieldOfView = currentFOV;
            yield return null;
        }
    }

    public void FadeToLevel(string sceneName)// fade 
    {
        sceneToLoad = sceneName;
        LeanTween.alphaCanvas(canvasGroup, to: 1, fadeTime).setOnComplete(OnFadeComplete); // fade to black
    }

    public void OnFadeComplete() // go to next scene
    {
        SceneManager.LoadScene(sceneToLoad);
        controls.SetActive(false); // deactivate control
        controls = null; // reset control
    }
}