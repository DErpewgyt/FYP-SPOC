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
    public GameObject RulerController;
    public GameObject Ruler;
    public ShortLongSightMovement ShortLongSightScript;
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
    public AstigmatismLensMovement AstigmatismLensMovement;
    public Dictionary<string, GameObject> imageDictionary;

    private void Start()
    {
        AstigmatismLensMovement = FindObjectOfType<AstigmatismLensMovement>();
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
                PDManager.SetActive(true);
                Ruler.SetActive(true);
                RulerController.SetActive(true);
                break;

            // Handle functionality for PupillaryDistanceKnobRight
            case "PupillaryDistanceKnobRight":
                print("PupillaryDistanceKnobRight clicked");
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
                break;

            // Handle functionality for ShortAndLongSightedGearRight
            case "ShortAndLongSightedGearRight":
                ShortLongSightScript.RightLSSightBool = true;
                print("ShortAndLongSightedGearRight clicked");
                break;

            // Handle functionality for AstigmatismLensLeft
            case "AstigmatismLensLeft":
                print("AstigmatismLensLeft clicked");
                AstigmatismLensMovement.LeftLensAnimate();
                break;

            // Handle functionality for AstigmatismLensRight
            case "AstigmatismLensRight":
                print("AstigmatismLensRight clicked");
                AstigmatismLensMovement.RightLensAnimate();
                break;

            // Handle functionality for AstigmatismMagnitudeKnobLeft
            case "AstigmatismMagnitudeKnobLeft":
                print("AstigmatismMagnitudeKnobLeft clicked");
                break;

            // Handle functionality for AstigmatismMagnitudeKnobRight
            case "AstigmatismMagnitudeKnobRight":
                print("AstigmatismMagnitudeKnobRight clicked");
                break;

            // Handle functionality for AstigmatismAxisKnobLeft
            case "AstigmatismAxisKnobLeft":
                print("AstigmatismAxisKnobLeft clicked");
                break;

            // Handle functionality for AstigmatismAxisKnobRight
            case "AstigmatismAxisKnobRight":
                print("AstigmatismAxisKnobRight clicked");
                break;

            default:
                break;
        }
    }

    private void DisableAll()
    {
        PDManager.SetActive(false);
        Ruler.SetActive(false);
        RulerController.SetActive(false);
        ShortLongSightScript.LeftLSSightBool = false;
        ShortLongSightScript.RightLSSightBool = false;
    }
}