using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    public Texture2D linkCursorTexture;
    public GameObject parent;
    private Animator anim;
    private bool zoomedIn = false;
    private bool isOverObject = false;
    private float multiplier = 0.25f;

    public MoveTest KeratometerMovement; //Call my other script

    void Start()
    {
        anim = parent.GetComponentInParent<Animator>();
        DisableMovements();
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform != null)
            {
                if (!isOverObject)
                {
                    isOverObject = true;
                    Cursor.SetCursor(linkCursorTexture, new Vector2(linkCursorTexture.width * multiplier, linkCursorTexture.height * multiplier), CursorMode.Auto);
                }

                if (Input.GetMouseButtonDown(0))
                {
                    PrintName(hit.transform.gameObject);
                    print(hit.transform.tag);
                    ZoomIn();
                    IdentifyInteractable(hit.transform.tag); //call functions
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

    private void PrintName(GameObject target)
    {
        print(target.name);
    }

    private void IdentifyInteractable(string tag)
    { 
        switch (tag) //switch statement for identifying the tags  
        {
            case "EyePiece": //tag 1
                {
                    print("EyePiece Chosen");
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
                    KeratometerMovement.HorizontalCircle= true;
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
    }

    private void DisableMovements() //Prevents objects from moving
    {
        KeratometerMovement.CircleMovement = false;
        KeratometerMovement.HorizontalCircle = false;
        KeratometerMovement.VerticalCircle = false;
    }

    private void ZoomOut()
    {
        if (zoomedIn)
        {
            anim.Play("keratometerunviewer");
            zoomedIn = false;
        }
    }
}