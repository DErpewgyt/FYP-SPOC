using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraTransformTransition : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform cameraCapTransform;
    public Transform cameraFolTransform;
    public Vector3 targetPosition;
    public Vector3 targetRotation;
    public Vector3 targetPos;
    public Vector3 targetRot;
    public Vector3 targetPo;
    public Vector3 targetRo;
    public float transitionDuration = 0.5f;

    private void Start()
    {
        // You can remove the StartCoroutine call from here since we'll handle the transition on X key press
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(TransitionCamera());
        }
    }

    private IEnumerator TransitionCamera()
    {
        Vector3 initialPosition = cameraTransform.position;
        Quaternion initialRotation = cameraTransform.rotation;

        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / transitionDuration);

            // Interpolate the position and rotation
            Vector3 newPosition = Vector3.Lerp(initialPosition, targetPosition, t);
            Quaternion newRotation = Quaternion.Euler(Vector3.Lerp(initialRotation.eulerAngles, targetRotation, t));
            
            Vector3 newPos = Vector3.Lerp(initialPosition, targetPos, t);
            Quaternion newRot = Quaternion.Euler(Vector3.Lerp(initialRotation.eulerAngles, targetRot, t));

            Vector3 newPo = Vector3.Lerp(initialPosition, targetPo, t);
            Quaternion newRo = Quaternion.Euler(Vector3.Lerp(initialRotation.eulerAngles, targetRo, t));
            // Apply the new position and rotation to the camera
            cameraTransform.position = newPosition;
            cameraTransform.rotation = newRotation;

            cameraCapTransform.position = newPos;
            cameraCapTransform.rotation = newRot;

            cameraFolTransform.position = newPo;
            cameraFolTransform.rotation = newRo;

            yield return null;
        }
    }
}
