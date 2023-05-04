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
    private bool zoomedIn = false;
    private bool isOverObject = false;
    private float multiplier = 0.25f;

    public GameObject Blur;

    void Start()
    {
        Blur.SetActive(false);
        anim = parent.GetComponentInParent<Animator>();
        DisableMovements();
    }

    void Update()
    {
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
            ZoomOut();
            DisableMovements();
        }
    }

    private void IdentifyInteractable(string tag)
    {
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

    private void ZoomIn()
    {
        anim.Play("keratometerviewer");
        zoomedIn = true;

        // Hide the cursor during the animation
        Cursor.visible = false;

        // Activate the blur effect after the animation is finished
        StartCoroutine(ActivateBlurAfterDelay(anim.GetCurrentAnimatorStateInfo(0).length));
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
        if (zoomedIn)
        {
            // Deactivate the blur effect before starting the zoom out animation
            Blur.SetActive(false);

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
    }

    private IEnumerator ActivateBlurAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Blur.SetActive(true);
    }
}
