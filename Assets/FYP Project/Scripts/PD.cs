using TMPro;
using UnityEngine;

public class PD : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private int pd;

    private void Awake()
    {
        pd = 0;
        UpdateTmp();
    }

    private void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0f)
        {
            pd += (int)Mathf.Sign(scrollInput);
            pd = Mathf.Clamp(pd, 0, 20); // Limit pd to a range of 0 to 20
            UpdateTmp();
        }
    }

    private void UpdateTmp()
    {
        textMeshPro.text = pd.ToString();
    }
}