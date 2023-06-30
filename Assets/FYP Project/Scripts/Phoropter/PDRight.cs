using System.Collections;
using UnityEngine;

public class PDRight : MonoBehaviour
{
    [SerializeField] private Animator PDRightAnim;
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
           
            PDRightAnim.SetTrigger("MWheelUp");
        }
         else if (scrollInput < 0)
        {
           
            PDRightAnim.SetTrigger("MWheelDown");
        }

       
    }

}
