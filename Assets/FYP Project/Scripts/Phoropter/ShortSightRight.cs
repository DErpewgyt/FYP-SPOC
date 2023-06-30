using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortSightRight : MonoBehaviour
{
    [SerializeField] private Animator ShortAndLongSet2;
    [SerializeField] private GameObject clickedObject;
    private bool isPlayingAnimation;
    public int scrollLimit;

    private void Start()
    {
      
    }

    private void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput > 0)
        {
           
            ShortAndLongSet2.SetTrigger("MWheelUp2");
        }
         else if (scrollInput < 0)
        {
           
            ShortAndLongSet2.SetTrigger("MWheelDown2");
        }

       
    }

}
