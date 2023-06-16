using UnityEngine;
using TMPro;

public class Readings : MonoBehaviour
{
    public TextMeshProUGUI vtopreadings1;
    public TextMeshProUGUI vtopreadings2;
    public TextMeshProUGUI vbottomreadings1;
    public TextMeshProUGUI vbottomreadings2;
    public TextMeshProUGUI vbottomreadings3;

    public TextMeshProUGUI htopreadings1;
    public TextMeshProUGUI htopreadings2;
    public TextMeshProUGUI htopreadings3;
    public TextMeshProUGUI hbottomreadings1;
    public TextMeshProUGUI hbottomreadings2;

    void Start()
    {
        float vtopreadings = Random.Range(60f, 28f);
        float vtopreadingstwo = vtopreadings - 1f;

        float vbottomreadings = Random.Range(12f, 5.5f);
        float vbottomreadingstwo = vbottomreadings + 0.1f;
        float vbottomreadingsthree = vbottomreadings + 0.2f;

        float htopreadings = Random.Range(12f, 5.5f);
        float htopreadingsDecimal = htopreadings - Mathf.Floor(htopreadings); // Extract the decimal only
        float htopreadingstwo = htopreadings + 0.1f;
        float htopreadingsthree = htopreadings + 0.2f;

        float hbottomreadings = Random.Range(60f, 28f);
        float hbottomreadingstwo = hbottomreadings - 1f;


        vtopreadings1.text = vtopreadings.ToString("F0"); //no dp
        vtopreadings2.text = vtopreadingstwo.ToString("F0");

        vbottomreadings1.text = vbottomreadings.ToString("F1");
        vbottomreadings2.text = vbottomreadingstwo.ToString("F1");
        vbottomreadings3.text = vbottomreadingsthree.ToString("F0");


        htopreadings1.text = htopreadingsDecimal.ToString(".0");
        htopreadings2.text = htopreadingstwo.ToString("F1");
        htopreadings3.text = htopreadingsthree.ToString("F1");

        hbottomreadings1.text = hbottomreadings.ToString("F0");
        hbottomreadings2.text = hbottomreadingstwo.ToString("F0");
    }
}
