using UnityEngine;

public class RulerController : MonoBehaviour
{
    public GameObject ruler;
    public GameObject miniRuler;

    public int rulerDist;
    public int rulerLimit;

    public Vector3 RulerScroll = new Vector3(1f, 0f, 0f);
    public Vector3 MiniRulerScroll = new Vector3(1f, 0f, 0f);

    private void Start()
    {
        rulerDist = 0;
    }

    private void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0 && rulerDist < rulerLimit)
        {
            // Increase
            ruler.transform.position -= RulerScroll;
            miniRuler.transform.position -= MiniRulerScroll;
            rulerDist += 1;
        }
        else if (scrollInput < 0 && rulerDist > 0)
        {
            // Decrease
            ruler.transform.position += RulerScroll;
            miniRuler.transform.position += MiniRulerScroll;
            rulerDist -= 1;
        }
    }
}