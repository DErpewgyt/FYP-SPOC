using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhoropterHighlightController : MonoBehaviour
{
    public Texture2D customCursorTexture;
    public LayerMask outlineLayer;
    public LayerMask outlineActiveLayer;
    public LayerMask defaultLayer;

    private GameObject highlightedObject;
    private GameObject blueHighlightedObject;
    private GameObject whiteHighlightedObject;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool wasOverObject = IsPointerOverComponent();

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            bool isOverObject = IsComponentTag(hit.collider.gameObject.tag);

            if (isOverObject)
            {
                // Highlight the object and change cursor to custom texture
                if (hit.collider.gameObject != highlightedObject)
                {
                    highlightedObject = hit.collider.gameObject;
                    SetHighlightedObject(LayerMask.NameToLayer("Outline Objects"));
                    SetCursor(customCursorTexture);
                }

                // Check for left-click to set blue highlight
                if (Input.GetMouseButtonDown(0))
                {
                    if (highlightedObject != blueHighlightedObject)
                    {
                        if (blueHighlightedObject != null)
                            blueHighlightedObject.layer = defaultLayer;

                        blueHighlightedObject = highlightedObject;
                        SetHighlightedObject(LayerMask.NameToLayer("Outline Objects Active"));
                        SetCursor(customCursorTexture);
                    }
                }
            }
            else
            {
                // Not hovering over a component
                // Remove highlight and change cursor to default texture
                if (wasOverObject)
                {
                    ResetHighlightedObject();

                    if (blueHighlightedObject == null)
                        ResetCursor();
                    else
                        SetCursor(customCursorTexture);
                }
            }
        }
        else
        {
            // Not hitting any collider, reset highlights and cursor
            if (wasOverObject)
            {
                ResetHighlightedObject();

                if (blueHighlightedObject == null)
                    ResetCursor();
                else
                    SetCursor(customCursorTexture);
            }
        }
    }

    private void SetHighlightedObject(int layer)
    {
        highlightedObject.layer = layer;

        if (highlightedObject != blueHighlightedObject)
        {
            if (whiteHighlightedObject != null && whiteHighlightedObject != blueHighlightedObject)
                whiteHighlightedObject.layer = defaultLayer;
            whiteHighlightedObject = highlightedObject;
        }
    }

    private void ResetHighlightedObject()
    {
        if (highlightedObject != null && highlightedObject != blueHighlightedObject)
        {
            highlightedObject.layer = defaultLayer;
            highlightedObject = null;
        }

        if (whiteHighlightedObject != null && whiteHighlightedObject != blueHighlightedObject)
        {
            whiteHighlightedObject.layer = defaultLayer;
            whiteHighlightedObject = null;
        }
    }

    private bool IsPointerOverComponent()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        foreach (RaycastResult result in results)
        {
            if (IsComponentTag(result.gameObject.tag))
                return true;
        }

        return false;
    }

    private bool IsComponentTag(string tag)
    {
        string[] allowedTags = {
            "PupillaryDistanceKnobLeft",
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

        foreach (string i in allowedTags)
        {
            if (i == tag)
                return true;
        }
        return false;
    }

    private void SetCursor(Texture2D cursorTexture)
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    private void ResetCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
