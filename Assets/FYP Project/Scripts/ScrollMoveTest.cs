using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMoveTest : MonoBehaviour
{
    public float speed = .25f;
    public bool VerticalCircle;
    public bool HorizontalCircle;
    // Update is called once per frame
    void Update()
    {
        if (HorizontalCircle)
        {
            float xDirection = Input.GetAxis("Mouse ScrollWheel");

            Vector3 moveDirectionX = new Vector3(xDirection, 0.0f, 0.0f);

            transform.position += moveDirectionX * speed;
        } 
        else if (VerticalCircle)
        {
            float yDirection = Input.GetAxis("Mouse ScrollWheel");

            Vector3 moveDirectionY = new Vector3(0.0f, yDirection, 0.0f);

            transform.position += moveDirectionY * speed;
        } 

    }

}
