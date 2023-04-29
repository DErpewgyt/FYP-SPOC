using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomOnInstrument : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    public float targetFOV;
    public float zoomSpeed;

    private float currentFOV;

    private void Start()
    {
        currentFOV = cam.m_Lens.FieldOfView;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicked");
            StartCoroutine(ZoomIn());
        }
    }

    private IEnumerator ZoomIn()
    {
        while (Mathf.Abs(currentFOV - targetFOV) > 0.01f)
        {
            currentFOV = Mathf.Lerp(currentFOV, targetFOV, Time.deltaTime * zoomSpeed);
            cam.m_Lens.FieldOfView = currentFOV;
            yield return null;
        }
    }
}

