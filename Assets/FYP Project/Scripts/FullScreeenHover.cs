using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FullScreeenHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text textComponent;
    public GameObject defaultDisappear;
    public GameObject textAppear;

    private void Awake()
    {
        textComponent = GetComponent<Text>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textAppear.SetActive(true);
        defaultDisappear.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textAppear.SetActive(false);
        defaultDisappear.SetActive(true);
    }
}
