using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    public Texture2D linkCursorTexture;
    public GameObject parent;
    private Animator anim;
    private bool zoomedIn = false;
    private bool isOverObject = false;
    private float multiplier = 0.25f;

    void Start()
    {
        anim = parent.GetComponentInParent<Animator>();
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
                    ZoomIn();
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
        }
    }

    private void PrintName(GameObject target)
    {
        print(target.name);
    }

    private void ZoomIn()
    {
        anim.Play("keratometerviewer");
        zoomedIn = true;
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