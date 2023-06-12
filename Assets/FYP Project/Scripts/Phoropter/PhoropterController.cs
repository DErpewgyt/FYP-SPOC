using UnityEngine;

public class PhoropterController : MonoBehaviour
{
    public Material highlightMaterial;
    public Texture2D linkCursorTexture;
    private float multiplier = 0.25f;
    private Transform highlight;
    private Material[] originalMaterials;
    private Renderer highlightRenderer;
    private bool isOverObject;

    public GameObject PDManager;
    public ShortLongSightMovement ShortLongSightScript;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (IsComponentTag(hit.collider.gameObject.tag))
            {
                // phoropterComponent is whatever valid component that is hit w raycast
                GameObject phoropterComponent = hit.collider.gameObject;

                // Highlight the phoropter component
                if (highlight != phoropterComponent.transform)
                {
                    ClearHighlight();
                    highlight = phoropterComponent.transform;
                    highlightRenderer = highlight.GetComponent<Renderer>();
                    originalMaterials = highlightRenderer.materials;
                    Material[] highlightMaterials = new Material[originalMaterials.Length];

                    for (int i = 0; i < originalMaterials.Length; i++)
                    {
                        highlightMaterials[i] = highlightMaterial;
                    }

                    highlightRenderer.materials = highlightMaterials;
                }

                // Set the cursor to custom clicker
                SetCursor(linkCursorTexture);
                isOverObject = true;
            }
            else
            {
                // Clear highlight if the raycast is off the valid phoropter component
                ClearHighlight();
                ResetCursor();
                isOverObject = false;
            }
        }
        else
        {
            // Clear the highlight if raycast never hit valid phoropter component
            ClearHighlight();
            ResetCursor();
            isOverObject = false;
        }

        //if leftclicked and isOverObject check is true, Identify which component is clicked based on the respective tags
        if (Input.GetMouseButtonDown(0))
        {
            if (isOverObject)
            {
                // Execute the functionality based on the tag
                string tag = highlight.gameObject.tag;
                IdentifyInteractable(tag);
            }
        }
    }

    private void SetCursor(Texture2D cursorTexture)
    {
        Cursor.SetCursor(linkCursorTexture, new Vector2(linkCursorTexture.width * multiplier, linkCursorTexture.height * multiplier), CursorMode.Auto);
    }

    private void ResetCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void ClearHighlight()
    {
        if (highlight != null && originalMaterials != null)
        {
            highlightRenderer.materials = originalMaterials;
            highlight = null;
            originalMaterials = null;
        }
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
                break;


            // Handle functionality for PupillaryDistanceKnobRight
            case "PupillaryDistanceKnobRight":
                print("PupillaryDistanceKnobRight clicked");
                PDManager.SetActive(true);
                break;


            // Handle functionality for OpenAndCloseKnobLeft
            case "OpenAndCloseKnobLeft":
                print("OpenAndCloseKnobLeft clicked");
                break;


            // Handle functionality for OpenAndCloseKnobRight
            case "OpenAndCloseKnobRight":
                print("OpenAndCloseKnobRight clicked");
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
        ShortLongSightScript.LeftLSSightBool = false;
        ShortLongSightScript.RightLSSightBool = false;
    }

}
