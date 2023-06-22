using UnityEngine;

public class PhoropterController : MonoBehaviour
{
    public Texture2D linkCursorTexture;
    private float multiplier = 0.25f;
    private bool isOverObject;
    private GameObject highlightedObject;
    public GameObject PDManager;
    public GameObject RulerController;
    public GameObject Ruler;
    public ShortLongSightMovement ShortLongSightScript;
    //public GameObject OpenCloseManager;

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
                        highlightedObject.layer = LayerMask.NameToLayer("Default");
                    }

                    // Set the new highlighted object
                    highlightedObject = hit.collider.gameObject;

                    // Set the cursor to custom clicker
                    highlightedObject.layer = LayerMask.NameToLayer("Outline Objects");
                    SetCursor(linkCursorTexture);
                }

                // Update the flag indicating the mouse is over a valid object
                isOverObject = true;
            }
            else
            {
                // Reset the layer and highlighted object
                if (highlightedObject != null)
                {
                    highlightedObject.layer = LayerMask.NameToLayer("Default");
                    highlightedObject = null;
                }

                ResetCursor();
                isOverObject = false;
            }
        }
        else
        {
            // Reset the layer and highlighted object
            if (highlightedObject != null)
            {
                highlightedObject.layer = LayerMask.NameToLayer("Default");
                highlightedObject = null;
            }

            ResetCursor();
            isOverObject = false;
        }

        // If left-clicked and isOverObject is true, identify the clicked component
        if (Input.GetMouseButtonDown(0))
        {
            if (isOverObject)
            {
                // Execute the functionality based on the tag
                string tag = highlightedObject.tag;
                IdentifyInteractable(tag);

            }
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
        return tag == "PupillaryDistanceKnobLeft" ||
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
               tag == "AstigmatismAxisKnobRight";
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