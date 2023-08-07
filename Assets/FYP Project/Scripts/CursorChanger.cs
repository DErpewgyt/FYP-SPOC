using UnityEngine;
using UnityEngine.EventSystems;

public class CursorChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Texture2D customCursorTexture1; // Assign your custom cursor texture here
    private CursorMode cursorMode = CursorMode.Auto;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(customCursorTexture1, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
