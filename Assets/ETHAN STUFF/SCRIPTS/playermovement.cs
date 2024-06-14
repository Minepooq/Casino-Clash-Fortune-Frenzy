using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    //charachter controller 2D (part of unity built in movement settings which stores key names)
    // can assign different keys to diff functions (only the name not the actual function)
    public CharacterController2D controller;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public GameObject swordselectionscreen;
    
    //part of unity animation toolkit
    public Animator animator;
    void Update() 
    {
        if(!swordselectionscreen.activeInHierarchy || mainmenu.istrue == false)
        {
            //gets the horizontal movement of the charachter 
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }
        }
       
        
    }
    private void FixedUpdate()
    {
        if (!swordselectionscreen.activeInHierarchy && mainmenu.istrue == false)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        }
    }

}
