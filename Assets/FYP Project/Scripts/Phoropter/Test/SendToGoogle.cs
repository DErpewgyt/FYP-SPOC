using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendToGoogle : MonoBehaviour
{
    public GameObject name;
    public GameObject pd;
    public GameObject ls;

    private string Name;
    private string PD;
    private string LS;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/d/1e0w0i7eA6NkmPuTeAmae_ANiDry78au9dnvt_Humqqg/formResponse";

    IEnumerator Post(string NAME, string Pd, string Ls)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.21854963", NAME);
        form.AddField("entry.334586437", Pd);
        form.AddField("entry.180919550", Ls);
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www;
    }

    public void Send()
    {
        Name = name.GetComponent<InputField>().text;
        PD = pd.GetComponent<InputField>().text;
        LS = ls.GetComponent<InputField>().text;
        StartCoroutine(Post(Name, PD, LS));
    }
}
