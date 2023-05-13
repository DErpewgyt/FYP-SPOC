using UnityEngine;

public class LogDisable : MonoBehaviour
{
    private void OnDisable()
    {
        Debug.Log(gameObject.name + " was disabled at " + Time.time + " seconds");
        Debug.Log(new System.Diagnostics.StackTrace());
    }
}