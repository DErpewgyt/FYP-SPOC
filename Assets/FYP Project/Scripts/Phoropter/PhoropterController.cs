using UnityEngine;

public class PhoropterController : MonoBehaviour
{
    public Material highlightMaterial;
    public Texture2D linkCursorTexture;
    private float multiplier = 0.25f;

    private Transform highlight;
    private Material originalMaterialHighlight;
    private bool isOverObject;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.CompareTag("PhoropterComponent"))
            {
                // Handle the interaction with the specific phoropter component
                GameObject phoropterComponent = hit.collider.gameObject;

                // Highlight the phoropter component
                if (highlight != phoropterComponent.transform)
                {
                    ClearHighlight();
                    highlight = phoropterComponent.transform;
                    originalMaterialHighlight = highlight.GetComponent<MeshRenderer>().material;
                    highlight.GetComponent<MeshRenderer>().material = highlightMaterial;
                }

                // Set the cursor to the linkCursorTexture
                SetCursor(linkCursorTexture);
                isOverObject = true;
            }
            else
            {
                // Clear highlight if the raycast is off the phoropter component
                ClearHighlight();
                ResetCursor();
                isOverObject = false;
            }
        }
        else
        {
            // Clear highlight if the raycast doesn't hit any object
            ClearHighlight();
            ResetCursor();
            isOverObject = false;
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
        if (highlight != null)
        {
            highlight.GetComponent<MeshRenderer>().material = originalMaterialHighlight;
            highlight = null;
        }
    }
}