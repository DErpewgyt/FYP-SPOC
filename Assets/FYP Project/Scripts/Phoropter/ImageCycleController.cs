using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageCycleController : MonoBehaviour
{
   
    public GameObject[] background;
    int index;

    void Start()
    {
        index = 0;
    }
        

    void Update()
    {
        if(index >= 6)
           index = 6 ; 

        if(index < 0)
           index = 0 ;
        


        if(index == 0)
        {
            background[0].gameObject.SetActive(true);
        }
        
    }

    public void Next()
{
    index += 1;

    if (index >= background.Length)
        index = 0;

    UpdateBackground();
}

public void Previous()
{
    index -= 1;

    if (index < 0)
        index = background.Length - 1;

    UpdateBackground();
}

private void UpdateBackground()
{
    for (int i = 0; i < background.Length; i++)
    {
        background[i].gameObject.SetActive(i == index);
    }

    Debug.Log(index);
}
   
}