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
    public bool zoomedIn = false;
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

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Blur.SetActive(false);
        Blur2.SetActive(false);
        anim = parent.GetComponentInParent<Animator>();
        DisableMovements();

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
/*        if (!helpController.helpImage.activeInHierarchy)
        {
            return;
        }*/

        // Highlight
        if (highlight != null)
        {
            highlight.GetComponent<MeshRenderer>().sharedMaterial = originalMaterialHighlight;
            highlight = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Cursor.visible && !EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
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
                print("YCMA");
                ZoomOut();
                DisableMovements();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("YCMA");
            ZoomIn();
            IdentifyInteractable("EyePiece");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("YCMA");
            ZoomIn();
            IdentifyInteractable("JoyStick");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("YCMA");
            ZoomIn();
            IdentifyInteractable("LeftKnob");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            print("YCMA");
            ZoomIn();
            IdentifyInteractable("Gripper");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            print("YCMA");
            ZoomIn();
            IdentifyInteractable("RightKnob");
        }

        CheckScrollWheelInput();

        print(currentSelectedObject);


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
        if (!zoomedIn && !animationInProgress)
        {
            animationInProgress = true;
            anim.Play("keratometerviewer");
            zoomedIn = true;

            // Hide the cursor during the animation
            Cursor.visible = false;

            // Start timer
            GameObject timer = GameObject.Find("Script manager");
            Stopwatch timerScript = timer.GetComponent<Stopwatch>();
            timerScript.timerRunning = true;

            // Activate the blur effect after the animation is finished
            StartCoroutine(ActivateBlurAfterDelay(anim.GetCurrentAnimatorStateInfo(0).length));
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
        if (zoomedIn && !animationInProgress)
        {
            animationInProgress = true;
            // Deactivate the blur effect before starting the zoom out animation
            Blur.SetActive(false);
            Blur2.SetActive(false);

            anim.Play("keratometerunviewer");
            zoomedIn = false;

            // Show the cursor when the animation is finished
            StartCoroutine(ShowCursorAfterDelay(anim.GetCurrentAnimatorStateInfo(0).length));
        }
    }

    private IEnumerator ShowCursorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Cursor.visible = true;
        animationInProgress = false;
    }

    private IEnumerator ActivateBlurAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Blur.SetActive(true);
        Blur2.SetActive(true);
        animationInProgress = false;
    }
}