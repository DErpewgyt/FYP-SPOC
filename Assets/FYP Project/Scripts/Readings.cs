using UnityEngine;
using TMPro;

public class Readings : MonoBehaviour
{
    public TextMeshProUGUI reading1;
    public TextMeshProUGUI reading2;

    void Start()
    {
        float readingrandom1 = Random.Range(5.5f, 12f);
        float readingrandom2 = Random.Range(12f, 28f);

        reading1.text = readingrandom1.ToString("F2"); //2 dp
        reading2.text = readingrandom2.ToString("F2");
    }
}
