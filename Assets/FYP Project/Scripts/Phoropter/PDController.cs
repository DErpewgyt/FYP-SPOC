using UnityEngine;
using TMPro;

public class PDController : MonoBehaviour
{
    public GameObject leftHalf;
    public GameObject rightHalf;

    /*public float moveSpeed = 1f;
    public float scrollSensitivity = 1f;*/

    public int scrollLimit;
    public int pd;

    /*public TextMeshProUGUI PDText;*/

    public Vector3 scrollDirection = new Vector3(1f, 0f, 0f);

    private void Start()
    {
        scrollLimit = 0;
    }
    public void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0 && scrollLimit < 21)
        {
            // Scroll outwards
            leftHalf.transform.position -= scrollDirection;
            rightHalf.transform.position += scrollDirection;
            scrollLimit += 1;
            pd += 1;
            pd = Mathf.Clamp(pd, 0, 20);
            //UpdateTmp();
        }
        else if (scrollInput < 0 && scrollLimit > 0)
        {
            // Scroll inwards
            leftHalf.transform.position += scrollDirection;
            rightHalf.transform.position -= scrollDirection;
            scrollLimit -= 1;
            pd -= 1;
            pd = Mathf.Clamp(pd, 0, 20);
           //UpdateTmp();
        }
    }

/*    private void UpdateTmp()
    {
        PDText.text = pd.ToString();
    }*/
}