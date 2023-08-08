using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeCursor : MonoBehaviour
{
    public Texture2D customCursorTexture;

    private void Update()
    {
        // Check if the cursor is over a UI element (button)
        if (EventSystem.current.IsPointerOverGameObject())
        {
            // Change cursor to custom texture when hovering over a UI element
            Cursor.SetCursor(customCursorTexture, Vector2.zero, CursorMode.Auto);

            // Check for button click (e.g., left mouse button)
            if (Input.GetMouseButtonDown(0))
            {
                // Handle button click action here
                // This is where you can put the code to perform actions when a button is clicked
                Debug.Log("Button Clicked!");
            }
        }
        else
        {
            // Reset cursor to default when not hovering over a UI element
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}
