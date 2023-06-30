using System.Collections;
using UnityEngine;

public class PDLeft : MonoBehaviour
{
    [SerializeField] private Animator PDLEFTAnim;
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
           
            PDLEFTAnim.SetTrigger("MWheelUp");
        }
         else if (scrollInput < 0)
        {
           
            PDLEFTAnim.SetTrigger("MWheelDown");
        }

       
    }

}
