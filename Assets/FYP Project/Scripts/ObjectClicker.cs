using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour


{
    public GameObject parent;
    private Animator anim;

    void Start()
    {
        anim = parent.GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    PrintName(hit.transform.gameObject);
                    anim.Play("keratometerviewer");
                }
            }
        }
    }

    private void PrintName(GameObject go)
    {
        print(go.name);
        anim.Play("keratometerviewer");
    }
}




/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour


{
    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    PrintName(hit.transform.gameObject);
                    anim.Play("keratometerzoom");
                }
            }
        }
    }

    private void PrintName(GameObject go)
    {
        print(go.name);
        anim.Play("keratometerzoom");
    }
}
*/