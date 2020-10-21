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
    public float walkSpeed = 40f;
    private float runSpeed = 0f;
    private float movementSpeed;
    private float horizontalMove = 0f;

    private bool jump = false;
    private bool jumpJetpack = false;
    private bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        movementSpeed = walkSpeed + runSpeed;
        horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed;

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
        if (Input.GetButtonDown("Run"))
        {
            runSpeed = 40f;
        }
        else if (Input.GetButtonUp("Run"))
        {
            runSpeed = 0f;
        }
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
