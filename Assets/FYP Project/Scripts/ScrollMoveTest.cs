using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMoveTest : MonoBehaviour
{
    public float speed = .25f;
    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Mouse ScrollWheel");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, 0.0f);

        transform.position += moveDirection * speed;
    }

}
