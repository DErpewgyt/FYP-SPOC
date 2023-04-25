using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
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

    public float speed = .25f;
    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W)) moveDir.z = +1f;
        if (Input.GetKey(KeyCode.S)) moveDir.z = -1f;
        if (Input.GetKey(KeyCode.A)) moveDir.x = -1f;
        if (Input.GetKey(KeyCode.D)) moveDir.x = +1f;
        if (Input.GetKey(KeyCode.Q)) moveDir.y = -1f;
        if (Input.GetKey(KeyCode.E)) moveDir.y = +1f;

        transform.position += moveDir * speed * Time.deltaTime;
    }

}
