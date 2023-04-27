using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

[SerializeField] private float speed = 0.5f;
[SerializeField] private float horizRange = 6f;
[SerializeField] private float vertiRange = 6f;

void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        float horizOffset = horizontalMove * speed * Time.deltaTime;
        float vertioffset = verticalMove * speed * Time.deltaTime;

        float rawHorizPos = transform.position.x + horizOffset;
        float clampedHorizPos = Mathf.Clamp(rawHorizPos, -horizRange, horizRange);

        float rawVertiPos = transform.position.z + vertioffset;
        float clampedVertiPos = Mathf.Clamp(rawVertiPos, -vertiRange, vertiRange);

        transform.position = new Vector3(clampedHorizPos, transform.position.y, clampedVertiPos);
    }
}