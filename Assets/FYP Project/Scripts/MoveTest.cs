using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{

    public float speed = .25f;


    public float maxDistX = .3f;
    public float maxDistZ = .25f;
    public float maxDistY = .1f;
    private Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        Vector3 moveDir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            moveDir.z = 1f;
            print(moveDir.z);
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDir.z = -1f;
            print(moveDir.z);
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDir.x = -1f;
            print(moveDir.x);
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDir.x = 1f;
            print(moveDir.x);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            moveDir.y = -1f;
            print(moveDir.y);
        }

        if (Input.GetKey(KeyCode.E))
        {
            moveDir.y = 1f;
            print(moveDir.y);
        }

        // calculate the target position based on move direction and distance limit
        Vector3 targetPos = transform.position + moveDir * speed * Time.deltaTime;
        targetPos = new Vector3(
            Mathf.Clamp(targetPos.x, startingPos.x - maxDistX, startingPos.x + maxDistX),
            Mathf.Clamp(targetPos.y, startingPos.y - maxDistY, startingPos.y + maxDistY),
            Mathf.Clamp(targetPos.z, startingPos.z - maxDistZ, startingPos.z + maxDistZ)
        );

        transform.position = targetPos; // set the new position of the object
    }

    /**
    public float speed = .05f;
    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");
        float zDirection = Input.GetAxis("Depth");

        Vector3 moveDirection = new Vector3(xDirection, yDirection, zDirection);

        transform.position += moveDirection * speed;
    }
    **/




    /**
    public float speed = .25f;
    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W)) {
            moveDir.z = +1f;
            print(moveDir.z);
        }
        
        if (Input.GetKey(KeyCode.S)) {
            moveDir.z = -1f;
            print(moveDir.z);
        }

        if (Input.GetKey(KeyCode.A)) {
            moveDir.x = -1f;
            print(moveDir.x);
        }

        if (Input.GetKey(KeyCode.D)) {
            moveDir.x = +1f;
            print(moveDir.x);
        }

        if (Input.GetKey(KeyCode.Q)) {
            moveDir.y = -1f;
            print(moveDir.y);
        }

        if (Input.GetKey(KeyCode.E)) {
            moveDir.y = +1f;
            print(moveDir.y);
        }


        transform.position += moveDir * speed * Time.deltaTime;
    }
    **/

    /**
    public float speed = .25f;
    public float moveLimit = 5f;

    void Update()
    {
        Vector3 moveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDir.z = 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDir.z = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDir.x = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDir.x = 1f;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            moveDir.y = -1f;
        }

        if (Input.GetKey(KeyCode.E))
        {
            moveDir.y = 1f;
        }

        
        moveDir = new Vector3(
            Mathf.Clamp(moveDir.x, -moveLimit, moveLimit),
            Mathf.Clamp(moveDir.y, -moveLimit, moveLimit),
            Mathf.Clamp(moveDir.z, -moveLimit, moveLimit)
        );

        transform.position += moveDir * speed * Time.deltaTime;
    }
    **/


}
