using UnityEngine;

public class PhoropterController : MonoBehaviour
{
    public Texture2D linkCursorTexture;
    private float multiplier = 0.25f;
    private bool isOverObject;
    private GameObject highlightedObject;
    private bool isObjectClicked = false; // New variable to track object click status
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
                                     "AstigmatismAxisKnobLeft"
                                   };
    private string activeTag;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (IsComponentTag(hit.collider.gameObject.tag))
            {
                // Check if highlighted object has changed
                if (hit.collider.gameObject != highlightedObject)
                {
                    // Reset the layer of the previously highlighted object if any
                    if (highlightedObject != null)
                    {
                        // Check if the object was clicked
                        if (activeTag != hit.collider.gameObject.tag && highlightedObject.tag != activeTag)
                        {
                            // Reset the layer to default only if the object was not clicked
                            highlightedObject.layer = LayerMask.NameToLayer("Default");
                        }
                        else
                        {
                            // If the object was clicked, set the layer to "Outline Objects Active"
                            highlightedObject.layer = LayerMask.NameToLayer("Outline Objects Active");
                        }
                    }

                    // Set the new highlighted object
                    highlightedObject = hit.collider.gameObject;

                    // Set the cursor to custom clicker
                    if (activeTag != hit.collider.gameObject.tag)
                    {
                        highlightedObject.layer = LayerMask.NameToLayer("Outline Objects");
                    }
                    SetCursor(linkCursorTexture);
                }

                // Update the flag indicating the mouse is over a valid object
                //isOverObject = true;

                // If left-clicked and isOverObject is true, identify the clicked component
                if (Input.GetMouseButtonDown(0))
                {
/*                    if (isOverObject)
                    {*/
                        // Execute the functionality based on the tag
                        string tag = highlightedObject.tag;
                        IdentifyInteractable(tag);
                        activeTag = tag;
                        //highlightedObject.layer = LayerMask.NameToLayer("Outline Objects Active"); // Change the layer to "Outline Objects Active"
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
                        //isObjectClicked = true; // Set the isObjectClicked flag to true
                    //}
                }
            }
        }
        else
        {
            // Reset the layer and highlighted object only if the mouse is not over the object and the left mouse button is not being held down
            if (highlightedObject != null && !Input.GetMouseButton(0))
            {
                // Check if the object was clicked
                if (activeTag != highlightedObject.tag)
                {
                    // Reset the layer to default only if the object was not clicked
                    highlightedObject.layer = LayerMask.NameToLayer("Default");
                }
                else
                {
                    // If the object was clicked, set the layer to "Outline Objects Active"
                    highlightedObject.layer = LayerMask.NameToLayer("Outline Objects Active");
                }
                highlightedObject = null;
            }

            ResetCursor();
            isOverObject = false;
            //isObjectClicked = false; // Reset the isObjectClicked flag
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
        // Check if the tag is valid
/*        return tag == "PupillaryDistanceKnobLeft" ||
               tag == "PupillaryDistanceKnobRight" ||
               tag == "OpenAndCloseKnobLeft" ||
               tag == "OpenAndCloseKnobRight" ||
               tag == "ShortAndLongSightedGearLeft" ||
               tag == "ShortAndLongSightedGearRight" ||
               tag == "AstigmatismLensLeft" ||
               tag == "AstigmatismLensRight" ||
               tag == "AstigmatismMagnitudeKnobLeft" ||
               tag == "AstigmatismMagnitudeKnobRight" ||
               tag == "AstigmatismAxisKnobLeft" ||
               tag == "AstigmatismAxisKnobRight";*/
         foreach(string i in allowedTags)
        {
            if (i == tag)
                return true;
        }
         return false;
    }

    private void IdentifyInteractable(string tag)
    {
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
                break;

            // Handle functionality for AstigmatismLensRight
            case "AstigmatismLensRight":
                print("AstigmatismLensRight clicked");
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