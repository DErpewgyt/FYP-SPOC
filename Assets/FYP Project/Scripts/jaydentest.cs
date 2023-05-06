using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jaydentest : MonoBehaviour
{
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = cube.transform.position;
        Debug.Log("X: " + currentPosition.x + " Y: " + currentPosition.y);
    }
}
