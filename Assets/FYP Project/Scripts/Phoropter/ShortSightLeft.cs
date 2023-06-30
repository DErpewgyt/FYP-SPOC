using System.Collections;
using UnityEngine;

public class ShortSightLeft : MonoBehaviour
{
    [SerializeField] private Animator ShortAndLongSet1;
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
           
            ShortAndLongSet1.SetTrigger("MWheelUp");
        }
         else if (scrollInput < 0)
        {
           
            ShortAndLongSet1.SetTrigger("MWheelDown");
        }

       
    }

}
