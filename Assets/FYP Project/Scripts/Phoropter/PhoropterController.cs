using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhoropterController : MonoBehaviour
{
    public Texture2D linkCursorTexture;
    private float multiplier = 0.25f;
    private GameObject highlightedObject;
    public GameObject PDManager;
    public GameObject PDLeftManager;
    public GameObject PDRightManager;
    public GameObject ShortSightLeftManager;
    public GameObject ShortSightRightManager;
    public GameObject RulerController;
    public GameObject Ruler;
    public GameObject PdBtn;
    public GameObject LSBtn;
    public GameObject RSBtn;
    public GameObject leftMagBtn;
    public GameObject rightMagBtn;
    public GameObject leftAxisBtn;
    public GameObject rightAxisBtn;
    public GameObject leftFinalBtn;
    public GameObject rightFinalBtn;
    public GameObject leftFlipBtn;
    public GameObject rightFlipBtn;
    public ShortLongSightMovement ShortLongSightScript;
    public AstigmatismLensMovement AstigmatismLensMovement;
    public AstigmatismMagnitudeControl AstigmatismMagnitudeControl;
    public AstigmatismAxisControl AstigmatismAxisControl;
    public LensFlip LensController;
    private string[] allowedTags = { "PupillaryDistanceKnobLeft",
                                     "PupillaryDistanceKnobRight",
                                     "OpenAndCloseKnobLeft",
                                     "OpenAndCloseKnobRight",
                                     "ShortAndLongSightedGearLeft",
                                     "ShortAndLongSightedGearRight",
                                     "AstigmatismLensLeft",
                                     "AstigmatismLensRight",
                                     "AstigmatismMagnitudeKnobLeft",
                                     "AstigmatismMagnitudeKnobRight",
                                     "AstigmatismAxisKnobLeft",
                                     "AstigmatismAxisKnobRight"
                                   };
    private string activeTag;
    public Dictionary<string, GameObject> imageDictionary;
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        AstigmatismLensMovement = FindObjectOfType<AstigmatismLensMovement>();
        AstigmatismAxisControl = FindObjectOfType<AstigmatismAxisControl>();
        // Initialize the image dictionary and add the corresponding images for each component
        imageDictionary = new Dictionary<string, GameObject>()
        {
            { "PupillaryDistanceKnobLeft", GameObject.FindWithTag("PupillaryDistanceKnobLeftImage") },
            { "PupillaryDistanceKnobRight", GameObject.FindWithTag("PupillaryDistanceKnobRightImage") },
            { "OpenAndCloseKnobLeft", GameObject.FindWithTag("OpenAndCloseKnobLeftImage") },
            { "OpenAndCloseKnobRight", GameObject.FindWithTag("OpenAndCloseKnobRightImage") },
            { "ShortAndLongSightedGearLeft", GameObject.FindWithTag("ShortAndLongSightedGearLeftImage") },
            { "ShortAndLongSightedGearRight", GameObject.FindWithTag("ShortAndLongSightedGearRightImage") },
            { "AstigmatismLensLeft", GameObject.FindWithTag("AstigmatismLensLeftImage") },
            { "AstigmatismLensRight", GameObject.FindWithTag("AstigmatismLensRightImage") },
            { "AstigmatismMagnitudeKnobLeft", GameObject.FindWithTag("AstigmatismMagnitudeKnobLeftImage") },
            { "AstigmatismMagnitudeKnobRight", GameObject.FindWithTag("AstigmatismMagnitudeKnobRightImage") },
            { "AstigmatismAxisKnobLeft", GameObject.FindWithTag("AstigmatismAxisKnobLeftImage") },
            { "AstigmatismAxisKnobRight", GameObject.FindWithTag("AstigmatismAxisKnobRightImage") }
        };

        // Set all images to inactive initially
        foreach (GameObject image in imageDictionary.Values)
        {
            image.SetActive(false);
        }
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (IsComponentTag(hit.collider.gameObject.tag))
            {
                if (hit.collider.gameObject != highlightedObject)
                {
                    if (highlightedObject != null)
                    {
                        if (activeTag != hit.collider.gameObject.tag && highlightedObject.tag != activeTag)
                        {
                            highlightedObject.layer = LayerMask.NameToLayer("Default");
                        }
                    }

                    highlightedObject = hit.collider.gameObject;

                    if (activeTag != hit.collider.gameObject.tag)
                    {
                        highlightedObject.layer = LayerMask.NameToLayer("Outline Objects");
                    }
                    SetCursor(linkCursorTexture);
                }

                if (Input.GetMouseButtonDown(0))
                {
                    string tag = highlightedObject.tag;
                    IdentifyInteractable(tag);
                    activeTag = tag;
                    foreach (string i in allowedTags)
                    {
                        if (i == tag)
                        {
                            highlightedObject.layer = LayerMask.NameToLayer("Outline Objects Active");
                        }
                        else
                        {
                            GameObject ge = GameObject.FindGameObjectWithTag(i);
                            if (ge != null)
                            {
                                ge.layer = LayerMask.NameToLayer("Default");
                            }
                        }

                    }
                }
            }
        }
        else
        {
            if (highlightedObject != null && !Input.GetMouseButton(0))
            {
                if (activeTag != highlightedObject.tag)
                {
                    highlightedObject.layer = LayerMask.NameToLayer("Default");
                }
                else
                {
                    highlightedObject.layer = LayerMask.NameToLayer("Outline Objects Active");
                }
                highlightedObject = null;
            }

            ResetCursor();
        }
    }

    private void SetCursor(Texture2D cursorTexture)
    {
        Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width * multiplier, cursorTexture.height * multiplier), CursorMode.Auto);
    }

    private void ResetCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private bool IsComponentTag(string tag)
    {
        foreach (string i in allowedTags)
        {
            if (i == tag)
                return true;
        }
        return false;
    }

    private void IdentifyInteractable(string tag)
    {
        foreach (GameObject image in imageDictionary.Values)
        {
            image.SetActive(false);
        }

        // Activate the specific image corresponding to the clicked component
        if (imageDictionary.ContainsKey(tag))
        {
            imageDictionary[tag].SetActive(true);
        }

        DisableAll();
        switch (tag)
        {
            // Handle functionality for PupillaryDistanceKnobLeft
            case "PupillaryDistanceKnobLeft":
                print("PupillaryDistanceKnobLeft clicked");
                PDLeftManager.SetActive(true);
                PDManager.SetActive(true);
                Ruler.SetActive(true);
                RulerController.SetActive(true);
                break;

            // Handle functionality for PupillaryDistanceKnobRight
            case "PupillaryDistanceKnobRight":
                print("PupillaryDistanceKnobRight clicked");
                PDRightManager.SetActive(true);
                PDManager.SetActive(true);
                Ruler.SetActive(true);
                RulerController.SetActive(true);
                break;

            // Handle functionality for OpenAndCloseKnobLeft
            case "OpenAndCloseKnobLeft":
                print("OpenAndCloseKnobLeft clicked");
                //OpenCloseManager.SetActive(true);
                break;

            // Handle functionality for OpenAndCloseKnobRight
            case "OpenAndCloseKnobRight":
                print("OpenAndCloseKnobRight clicked");
                //OpenCloseManager.SetActive(true);
                break;

            // Handle functionality for ShortAndLongSightedGearLeft
            case "ShortAndLongSightedGearLeft":
                ShortLongSightScript.LeftLSSightBool = true;
                print("ShortAndLongSightedGearLeft clicked");
                ShortSightLeftManager.SetActive(true);
                break;

            // Handle functionality for ShortAndLongSightedGearRight
            case "ShortAndLongSightedGearRight":
                ShortLongSightScript.RightLSSightBool = true;
                print("ShortAndLongSightedGearRight clicked");
                ShortSightRightManager.SetActive(true);
                break;

            // Handle functionality for AstigmatismLensLeft
            case "AstigmatismLensLeft":
                print("AstigmatismLensLeft clicked");
                AstigmatismLensMovement.LeftLensAnimate();
                LensController.leftFlip();
                break;

            // Handle functionality for AstigmatismLensRight
            case "AstigmatismLensRight":
                print("AstigmatismLensRight clicked");
                AstigmatismLensMovement.RightLensAnimate();
                LensController.rightFlip();
                break;

            // Handle functionality for AstigmatismMagnitudeKnobLeft
            case "AstigmatismMagnitudeKnobLeft":
                print("AstigmatismMagnitudeKnobLeft clicked");
                AstigmatismMagnitudeControl.AstigMagLeftBool = true;
                break;

            // Handle functionality for AstigmatismMagnitudeKnobRight
            case "AstigmatismMagnitudeKnobRight":
                print("AstigmatismMagnitudeKnobRight clicked");
                AstigmatismMagnitudeControl.AstigMagRightBool = true;
                break;

            // Handle functionality for AstigmatismAxisKnobLeft
            case "AstigmatismAxisKnobLeft":
                print("AstigmatismAxisKnobLeft clicked");
                AstigmatismAxisControl.HandleLeftKnobClick();
                break;

            // Handle functionality for AstigmatismAxisKnobRight
            case "AstigmatismAxisKnobRight":
                print("AstigmatismAxisKnobRight clicked");
                AstigmatismAxisControl.HandleRightKnobClick();
                break;

            default:
                break;
        }
    }

    private void DisableAll()
    {
        PDLeftManager.SetActive(false);
        PDRightManager.SetActive(false);
        ShortSightRightManager.SetActive(false);
        ShortSightLeftManager.SetActive(false);
        PDManager.SetActive(false);
        Ruler.SetActive(false);
        RulerController.SetActive(false);
        ShortLongSightScript.LeftLSSightBool = false;
        ShortLongSightScript.RightLSSightBool = false;
        AstigmatismMagnitudeControl.AstigMagRightBool = false;
        AstigmatismMagnitudeControl.AstigMagLeftBool = false;
        AstigmatismAxisControl.isRotatingLeft = false;
        AstigmatismAxisControl.isRotatingRight = false;
        /*PdBtn.SetActive(false);*/
        LSBtn.SetActive(false);
        RSBtn.SetActive(false);
        leftMagBtn.SetActive(false);
        rightMagBtn.SetActive(false);
        leftAxisBtn.SetActive(false);
        rightAxisBtn.SetActive(false);
        leftFinalBtn.SetActive(false);
        //rightFinalBtn.SetActive(false);
        //leftFlipBtn.SetActive(false);
        rightFlipBtn.SetActive(false);
        LensController.leftFlippedOnce = false;
        LensController.leftFlippedTwice = false;
        LensController.rightFlippedOnce = false;
        LensController.rightFlippedTwice = false;
    }
}