using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class DoorScript : MonoBehaviour
{
    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5;
    public AudioSource DoorOpen;
    public AudioSource DoorClose;
    private bool opened = false;
    private  Animator anim;
 
 
 
    void Update()
    {
        //This will tell if the player press F on the Keyboard. P.S. You can change the key if you want.
        if (Input.GetMouseButtonDown(0))
        {
            Pressed();
            //Delete if you dont want Text in the Console saying that You Left Clicked.
            Debug.Log("You Left Clicked");
        }
    }
 
    void Pressed()
{
    RaycastHit doorhit;

    if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
    {
        if (doorhit.transform.tag == "Door")
        {
            anim = doorhit.transform.GetComponentInParent<Animator>();

            // Play the door sound based on whether the door is being opened or closed.
            if (!opened)
            {
                DoorOpen.Play();
            }
            else
            {
                DoorClose.Play();
            }

            opened = !opened;
            anim.SetBool("Opened", opened);
        }
    }
}
}