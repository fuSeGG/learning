using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Animator animator;
    public PlayerController controller;

    bool slide = false;
    bool jump = false;

    float runSpeed = 15f;

    float horizontalMove = 0f;

    // Update is called once per frame
    void Update() {


        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (!slide) {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }
        

        if (Input.GetButtonDown("Jump")) { jump = true; }
        if (Input.GetButtonDown("Slide")){
            slide = true;
            animator.SetBool("isSliding", true);
        }
        else if (Input.GetButtonUp("Slide")) {
            slide = false;
            animator.SetBool("isSliding", false);
        }
    }
    // param: move, crouch, slide, jump
    private void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, slide, jump);
        jump = false;
        slide = false;
        animator.SetBool("isSliding", false); 
    }

}
