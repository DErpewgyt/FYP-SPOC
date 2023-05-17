using UnityEngine;

public class ZoomController : MonoBehaviour
{
    public GameObject guide;
    public float zoomSpeed = 0.1f;
    public float dragSpeed = 0.1f;
    public float dragLimit = 2f;

    private bool isZooming = false;
    private bool isDragging = false;
    private Vector3 initialScale;
    private Vector3 initialPosition;
    private Vector3 dragOrigin;

    private void Start()
    {
        initialScale = guide.transform.localScale;
        initialPosition = guide.transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && HelpImageIsClicked())
        {
            if (!isZooming)
            {
                isZooming = true;
            }
            else
            {
                // Only allow dragging when the image is zoomed
                if (guide.transform.localScale.x > initialScale.x && guide.transform.localScale.y > initialScale.y && guide.transform.localScale.z > initialScale.z)
                {
                    isDragging = true;
                    dragOrigin = Input.mousePosition;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isZooming)
        {
            if (isDragging)
            {
                Vector3 difference = Camera.main.ScreenToViewportPoint(dragOrigin - Input.mousePosition);
                Vector3 move = new Vector3(difference.x * -dragSpeed, difference.y * -dragSpeed); // Invert the drag direction

                if (Mathf.Abs(guide.transform.position.x - initialPosition.x + move.x) <= dragLimit &&
                    Mathf.Abs(guide.transform.position.y - initialPosition.y + move.y) <= dragLimit)
                {
                    guide.transform.Translate(move, Space.World);
                }

                dragOrigin = Input.mousePosition;
            }

            float scrollData = Input.GetAxis("Mouse ScrollWheel");
            Vector3 scaleChange = new Vector3(scrollData, scrollData, scrollData);
            Vector3 newScale = guide.transform.localScale + scaleChange * zoomSpeed;

            if (newScale.x >= initialScale.x && newScale.y >= initialScale.y && newScale.z >= initialScale.z)
            {
                guide.transform.localScale = newScale;
            }

            // If the scale is reduced back to initial scale, reset the position
            if (guide.transform.localScale == initialScale)
            {
                guide.transform.position = initialPosition;
            }
        }
        else
        {
            guide.transform.localScale = initialScale;
            guide.transform.position = initialPosition;
        }
    }

    private bool HelpImageIsClicked()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject == guide)
            {
                return true;
            }
        }
        return false;
    }
}