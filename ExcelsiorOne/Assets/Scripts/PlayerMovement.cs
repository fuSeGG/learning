using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Animator animator;
    public PlayerController controller;

    bool slide = false;
    bool jump = false;
    bool sprint = false;

    float runSpeed = 8f;
    float sprintSpeed = 1.5f;
    float horizontalMove = 0f;
    float jumpStart;


    // Update is called once per frame
    void Update() {

        // Jump
        if (Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("isJumping", true);
            jumpStart = Time.time;            
        }
        if (Input.GetButtonUp("Jump")) {
            animator.SetBool("isJumping", false);
            jump = false;
        }
        


        // Slide 
        if (Input.GetButtonDown("Slide")) {
            slide = true;
            animator.SetBool("isSliding", true);
        }
        else if (Input.GetButtonUp("Slide")) {
            slide = false;
            animator.SetBool("isSliding", false);
        }

        // Sprint
        if (Input.GetButtonDown("Sprint")) {
            sprint = true;
        }
        else if (Input.GetButtonUp("Sprint")) {
            sprint = false;
        }       
            
        

        animator.SetFloat("Speed", horizontalMove);
        if (!slide) {
            if (sprint) { horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed * sprintSpeed; }
            else { horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; }
        }
    }

    // param: move, crouch, slide, jump
    private void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, slide, jump);
        // jump = false;
        // slide = false;
        // animator.SetBool("isSliding", false);
        // animator.SetBool("isJumping", false);

    }
}

