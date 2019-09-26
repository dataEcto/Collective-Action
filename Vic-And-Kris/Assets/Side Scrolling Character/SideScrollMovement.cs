using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollMovement : MonoBehaviour
{
    //A reference to our script and not the component
    public CharacterController2D controller;

    public float runSpeed = 40f;

    private float horizontalMove = 0f;

    //We will place this variable as an argument fufillment for the 
    //CharacterController2D Move function
    private bool jump = false;
    private bool crouch = false;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        //Get input and multiply it by speed
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

       if (Input.GetButtonDown("Jump"))
       {
           jump = true;
       }

       if (Input.GetButtonDown("Crouch"))
       {
           crouch = true;
       } 
       else if (Input.GetButtonUp("Crouch"))
       {
           crouch = false;
       }
      
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
