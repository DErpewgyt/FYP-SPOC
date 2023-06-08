using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectClicker : MonoBehaviour
{
    public Material highlightMaterial;
    public Texture2D linkCursorTexture;
    public GameObject parent;
    public MoveTest KeratometerMovement;
    private Material originalMaterialHighlight;
    private Transform highlight;
    private RaycastHit raycastHit;
    private Animator anim;
    public static bool zoomedIn = false;
    public bool zoom = false;
    private bool isOverObject = false;
    private bool animationInProgress = false;
    private float multiplier = 0.25f;
    public Dictionary<string, GameObject> imageDictionary;
    public GameObject Blur;
    public GameObject Blur2;
    private GameObject currentSelectedObject = null;
    private float timer = 0f;
    private const float TIMER_RESET_VALUE = 1f;
    private GameObject eyePieceObject;
    public KeratometerHelpController helpController;
    public GameObject ExitIcon;
    public static bool ExitActive;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Blur.SetActive(false);
        Blur2.SetActive(false);
        anim = parent.GetComponentInParent<Animator>();
        DisableMovements();
        ExitActive = true;

        // Initialize the image dictionary and add the corresponding images for each component
        imageDictionary = new Dictionary<string, GameObject>()
        {
            { "EyePiece", GameObject.FindWithTag("EyePieceImage") },
            { "LeftKnob", GameObject.FindWithTag("LeftKnobImage") },
            { "RightKnob", GameObject.FindWithTag("RightKnobImage") },
            { "Gripper", GameObject.FindWithTag("GripperImage") },
            { "JoyStick", GameObject.FindWithTag("JoyStickImage") }
        };

        // Set all images to inactive initially
        foreach (GameObject image in imageDictionary.Values)
        {
            image.SetActive(false);
        }

        eyePieceObject = GameObject.FindWithTag("EyePiece");

    }

    private void Update()
    {
        if (highlight != null)
        {
            highlight.GetComponent<MeshRenderer>().sharedMaterial = originalMaterialHighlight;
            highlight = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Cursor.visible && !EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        if (Cursor.visible && !IsPointerOverGameObjectWithTag("CursorChangeOnly") && Physics.Raycast(ray, out raycastHit))
        {
            highlight = raycastHit.transform;
            if (highlight.CompareTag("Selectable") || highlight.CompareTag("EyePiece") || highlight.CompareTag("Gripper") || highlight.CompareTag("JoyStick") || highlight.CompareTag("LeftKnob") || highlight.CompareTag("RightKnob"))
            {
                if (highlight.GetComponent<MeshRenderer>().material != highlightMaterial)
                {
                    originalMaterialHighlight = highlight.GetComponent<MeshRenderer>().material;
                    highlight.GetComponent<MeshRenderer>().material = highlightMaterial;
                }

                if (!isOverObject)
                {
                    isOverObject = true;
                    Cursor.SetCursor(linkCursorTexture, new Vector2(linkCursorTexture.width * multiplier, linkCursorTexture.height * multiplier), CursorMode.Auto);
                }

                if (Input.GetMouseButtonDown(0))
                {
                    ZoomIn();
                    IdentifyInteractable(highlight.tag);
                }
            }
            else
            {
                highlight = null;
                if (isOverObject)
                {
                    isOverObject = false;
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                }
            }
        }
        //else if (EventSystem.current.IsPointerOverGameObject())
        else if (IsPointerOverGameObjectWithTag("CursorChangeOnly"))
        {
            if (!isOverObject)
            {
                isOverObject = true;
                Cursor.SetCursor(linkCursorTexture, new Vector2(linkCursorTexture.width * multiplier, linkCursorTexture.height * multiplier), CursorMode.Auto);
            }
        }
        else
        {
            if (isOverObject)
            {
                isOverObject = false;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!animationInProgress)
            {
                ZoomOut();
                DisableMovements();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ZoomIn();
            IdentifyInteractable("EyePiece");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ZoomIn();
            IdentifyInteractable("JoyStick");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ZoomIn();
            IdentifyInteractable("LeftKnob");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ZoomIn();
            IdentifyInteractable("Gripper");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ZoomIn();
            IdentifyInteractable("RightKnob");
        }

        CheckScrollWheelInput();

        if (ExitActive == true)
        {
            ExitIcon.SetActive(true);
        }
        else if (ExitActive == false)
        {
            ExitIcon.SetActive(false);
        }
    }



    private void IdentifyInteractable(string tag)
    {
        // Set all images to inactive before activating the specific image
        foreach (GameObject image in imageDictionary.Values)
        {
            image.SetActive(false);
        }

        // Reset the timer when switching to a new component
        if (currentSelectedObject != null && currentSelectedObject.tag != tag)
        {
            timer = 0f;

            // If the previously selected object was "EyePiece", reset its image to the default state
            if (currentSelectedObject.tag == "EyePiece" && imageDictionary.ContainsKey("EyePiece"))
            {
                imageDictionary["EyePiece"].transform.GetChild(0).gameObject.SetActive(false);
                imageDictionary["EyePiece"].transform.GetChild(1).gameObject.SetActive(false);
            }
        }

        if (tag == "EyePiece")
        {
            currentSelectedObject = eyePieceObject;
        }
        else
        {
            currentSelectedObject = GameObject.FindWithTag(tag);
        }

        // Activate the specific image corresponding to the clicked component
        if (imageDictionary.ContainsKey(tag))
        {
            imageDictionary[tag].SetActive(true);
        }

        DisableMovements();
        switch (tag) //switch statement for identifying the tags
        {
            case "EyePiece": //tag 1
                {
                    print("EyePiece Chosen");
                    KeratometerMovement.BlurCircle = true;
                }
                break;

            case "JoyStick": //tag 2
                {
                    print("JoyStick Chosen");
                    KeratometerMovement.CircleMovement = true;
                }
                break;

            case "Gripper": //tag 3
                {
                    print("Gripper Chosen");
                }
                break;

            case "LeftKnob": //tag 4
                {
                    print("LeftKnob Chosen");
                    KeratometerMovement.HorizontalCircle = true;
                }
                break;

            case "RightKnob"://tag 5
                {
                    print("RightKnob Chosen");
                    KeratometerMovement.VerticalCircle = true;
                }
                break;

            case "Untagged": //Untagged (similar ot default)
                {
                    print("Untagged Chosen");
                }
                break;

            default: //default tag
                {
                }
                break;
        }
    }

    private void CheckScrollWheelInput()
    {
        if (currentSelectedObject != null)
        {
            float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");

            if (currentSelectedObject.tag == "EyePiece")
            {
                if (scrollWheelInput > 0f)
                {
                    // Scroll up anti-clockwise arrow
                    imageDictionary["EyePiece"].transform.GetChild(0).gameObject.SetActive(false);
                    imageDictionary["EyePiece"].transform.GetChild(1).gameObject.SetActive(true);
                    timer = TIMER_RESET_VALUE;
                }
                else if (scrollWheelInput < 0f)
                {
                    // Scroll up clockwise arrow
                    imageDictionary["EyePiece"].transform.GetChild(0).gameObject.SetActive(true);
                    imageDictionary["EyePiece"].transform.GetChild(1).gameObject.SetActive(false);
                    timer = TIMER_RESET_VALUE;
                }

                // Decrease the timer every frame
                if (timer > 0f)
                {
                    timer -= Time.deltaTime;
                }
                else
                {
                    //back to default image
                    imageDictionary["EyePiece"].transform.GetChild(0).gameObject.SetActive(false);
                    imageDictionary["EyePiece"].transform.GetChild(1).gameObject.SetActive(false);
                }
            }
        }
    }

    private void ZoomIn()
    {
        /*ExitIcon.SetActive(false);*/
        ExitActive = false;

        if (!zoomedIn && !animationInProgress)
        {
            animationInProgress = true;
            anim.Play("keratometerviewer");
            zoomedIn = true;
            zoom = true;

            // Hide cursor during the animation
            Cursor.visible = false;

            // Start timer
            GameObject timer = GameObject.Find("Script manager");
            Stopwatch timerScript = timer.GetComponent<Stopwatch>();
            timerScript.timerRunning = true;

            // Activate blur effect and show the cursor after animation finishes
            StartCoroutine(ActivateBlurAndShowCursorAfterDelay(anim.GetCurrentAnimatorStateInfo(0).length));
        }
    }


    private void DisableMovements()
    {
        KeratometerMovement.CircleMovement = false;
        KeratometerMovement.HorizontalCircle = false;
        KeratometerMovement.VerticalCircle = false;
        KeratometerMovement.BlurCircle = false;
    }

    private void ZoomOut()
    {
        ExitActive = true;

        if (zoomedIn && !animationInProgress)
        {
            animationInProgress = true;
            // Deactivate blur effect and show the cursor before starting zoom out animation
            Blur.SetActive(false);
            Blur2.SetActive(false);
            Cursor.visible = true;  // make cursor visible here

            anim.Play("keratometerunviewer");
            zoomedIn = false;
            zoom = false;

            // Show cursor when the animation finishes
            StartCoroutine(ShowCursorAfterDelay(anim.GetCurrentAnimatorStateInfo(0).length));
        }
    }


    private IEnumerator ShowCursorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Cursor.visible = true;
        animationInProgress = false;
    }
    private IEnumerator ActivateBlurAndShowCursorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Blur.SetActive(true);
        Blur2.SetActive(true);
        animationInProgress = false;
        Cursor.visible = true;  // make cursor visible here
    }

    private bool IsPointerOverGameObjectWithTag(string tag)
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.CompareTag(tag))
            {
                return true;
            }
        }

        return false;
    }
}
