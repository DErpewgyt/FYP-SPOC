using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FullScreeenHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text textComponent;
    public GameObject textAppear;

    private void Awake()
    {
        // Get the Text component attached to the same GameObject
        textComponent = GetComponent<Text>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textAppear.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textAppear.SetActive(false);
    }
}
