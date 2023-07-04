using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeLayerOnRaycast : MonoBehaviour
{
    public float fieldOfView = 60f; // camera's field of view
    public float raycastDistance = 3f; // how far the raycast can reach
    public LayerMask newLayerMask; // new layer mask to assign to the objects
    public LayerMask defaultMask;
    public string targetTag = "Keratometer"; // tag of the objects to change layer
    public string targetTag2 = "Phoropter"; // tag of the objects to change layer
    public GameObject keratometer;
    public GameObject phoropter;
    private int originalLayer; // original layer of the objects

    private Dictionary<Transform, int> originalLayers = new Dictionary<Transform, int>();

    private void Start()
    {
        originalLayer = gameObject.layer; // store the original layer of the script's GameObject
        gameObject.layer = 0;

        StoreOriginalLayers(keratometer.transform);
        StoreOriginalLayers(phoropter.transform);
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); // create raycast from the center of the camera

        if (Physics.Raycast(ray, out hit, raycastDistance)) // check if raycast hit anything
        {
            Debug.Log("Hit object: " + hit.transform.name); // print whatever raycast hits

            // Calculate the dot product between the raycast direction and camera forward direction
            Vector3 directionToHit = (hit.point - Camera.main.transform.position).normalized;
            float dotProduct = Vector3.Dot(directionToHit, Camera.main.transform.forward);

            if (dotProduct > Mathf.Cos(Mathf.Deg2Rad * fieldOfView / 2f)) // check if object is within camera's field of view
            {
                Debug.Log("Object is within the field of view!");

                // Check if the hit object has the target tag
                if (hit.transform.CompareTag(targetTag))
                {
                    // Change the layer of the hit object and its children to the new layer mask
                    SetLayerRecursively(keratometer.transform, LayerMask.NameToLayer("Outline Objects Active"));
                }
                if (hit.transform.CompareTag(targetTag2))
                {
                    // Change the layer of the hit object and its children to the new layer mask
                    SetLayerRecursively(phoropter.transform, LayerMask.NameToLayer("Outline Objects Active"));
                }
            }
        }
        else
        {
            // Reset the layer of the objects and their children to the original layer
            SetLayerRecursively(keratometer.transform, originalLayers[keratometer.transform]);
            SetLayerRecursively(phoropter.transform, originalLayers[phoropter.transform]);
        }
    }

    private void StoreOriginalLayers(Transform parent)
    {
        originalLayers[parent] = parent.gameObject.layer;

        foreach (Transform child in parent)
        {
            StoreOriginalLayers(child);
        }
    }

    private void SetLayerRecursively(Transform parent, int layer)
    {
        parent.gameObject.layer = layer;

        foreach (Transform child in parent)
        {
            SetLayerRecursively(child, layer);
        }
    }
}
