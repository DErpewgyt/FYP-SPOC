using UnityEngine;

public class RulerController : MonoBehaviour
{
    public RectTransform ruler;
    public RectTransform miniRuler;

    public int rulerDist;
    public int rulerLimit;

    public float rulerScroll;
    public float miniRulerScroll;

    public GameObject CheckBtn;

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
            print("increasing");
            ruler.anchoredPosition -= new Vector2(rulerScroll, 0f);
            miniRuler.anchoredPosition -= new Vector2(miniRulerScroll, 0f);
            rulerDist += 1;
            CheckBtn.SetActive(true);
        }
        else if (scrollInput < 0 && rulerDist > 0)
        {
            // Decrease
            ruler.anchoredPosition += new Vector2(rulerScroll, 0f);
            miniRuler.anchoredPosition += new Vector2(miniRulerScroll, 0f);
            rulerDist -= 1;
            CheckBtn.SetActive(true);
        }
    }
}
