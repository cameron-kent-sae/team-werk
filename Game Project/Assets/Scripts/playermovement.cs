using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    // Calls controller script
    public CharacterController2D controller;

    // Calls the animator
    // public Animator animator;

    // Speed variables
    public float runSpeed = 40f;
    float horizontalMove = 0f;

    bool jump = false;
    bool jumpJetpack = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            // animator.SetBool("isJumping", true);
        }
        if (Input.GetButtonDown("Jetpack"))
        {
            jumpJetpack = true;
        }
        /* if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }*/
    }

    public void OnLanding()
    {
        // animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        // animator.SetBool("isCrouching", isCrouching);
    }
    private void FixedUpdate()
    {
        // Move the character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, jumpJetpack);
        jump = false;
        jumpJetpack = false;
    }
}
