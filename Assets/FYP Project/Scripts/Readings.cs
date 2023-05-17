using UnityEngine;
using TMPro;

public class Readings : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    void Start()
    {
        float randomNum1 = Random.Range(5.5f, 12f);
        float randomNum2 = Random.Range(12f, 28f);

        text1.text = randomNum1.ToString("F2");
        text2.text = randomNum2.ToString("F2");
    }
}
