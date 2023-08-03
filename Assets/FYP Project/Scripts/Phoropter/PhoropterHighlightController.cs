using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhoropterHighlightController : MonoBehaviour
{
    public Texture2D customCursorTexture;
    public GameObject highlightedObject;
    public GameObject activeObject;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            bool isOverObject = IsComponentTag(hit.collider.gameObject.tag);

            if (isOverObject)
            {
                // Set the custom cursor when hovering over a valid tag
                Cursor.SetCursor(customCursorTexture, Vector2.zero, CursorMode.Auto);

                if (highlightedObject != hit.collider.gameObject)
                {
                    // Reset previously highlighted object to default
                    if (highlightedObject != null && highlightedObject != activeObject && highlightedObject.layer != LayerMask.NameToLayer("Outline Objects Active"))
                        highlightedObject.layer = LayerMask.NameToLayer("Default");

                    // Highlight new object and make it highlightedObject
                    highlightedObject = hit.collider.gameObject;
                    if (highlightedObject.layer != LayerMask.NameToLayer("Outline Objects Active"))
                        highlightedObject.layer = LayerMask.NameToLayer("Outline Objects");
                }
            }
            else
            {
                // Reset highlighted object to default when raycast hits object that doesn't have valid tag
                if (highlightedObject != null && highlightedObject != activeObject)
                {
                    highlightedObject.layer = LayerMask.NameToLayer("Default");
                    highlightedObject = null;
                }

                // Reset the cursor to the default cursor when not hovering over a valid tag
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
        }
        else
        {
            Debug.Log("I am not hitting any collider.");
            // Reset highlighted object to default when raycast hits nothing
            if (highlightedObject != null && highlightedObject != activeObject)
            {
                highlightedObject.layer = LayerMask.NameToLayer("Default");
                highlightedObject = null;
            }

            // Reset the cursor to the default cursor when not hitting anything
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }

        // left click sets "Outline Objects Active" and updates activeObject
        if (Input.GetMouseButtonDown(0) && highlightedObject != null)
        {
            if (activeObject != null && activeObject != highlightedObject)
            {
                activeObject.layer = LayerMask.NameToLayer("Default");
            }
            highlightedObject.layer = LayerMask.NameToLayer("Outline Objects Active");
            activeObject = highlightedObject;
        }
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
}
