using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public float raycastDistance = 100f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check if the left mouse button is clicked
        {
            RaycastHit hit; // Create a RaycastHit variable to store information about the hit object
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); // Cast a ray from the center of the camera's viewport

            if (Physics.Raycast(ray, out hit, raycastDistance)) // Check if the raycast hits any object within a certain distance
            {
                Debug.Log("Hit object: " + hit.transform.name); // Print the name of the object hit by the raycast
            }
        }
    }
}
