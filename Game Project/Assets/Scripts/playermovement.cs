using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    // Calls scripts
    public CharacterController2D controller;
    public grappler grappleRope;

    // Creating transform points
    public Transform grapplePoint;

    // Movement variables
    public float walkSpeed = 40f;
    
    private float runSpeed = 0f;
    private float movementSpeed;
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool jumpJetpack = false;

    // Start is called before the first frame update
    void Start()
    {
        grappleRope.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        movementSpeed = walkSpeed + runSpeed;
        horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
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

    private void FixedUpdate()
    {
        // Move the character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump, jumpJetpack);
        jump = false;
        jumpJetpack = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Activates the grapple
        if (other.gameObject.tag == "Grapple")
        {
            grapplePoint = other.gameObject.transform;
            grappleRope.enabled = true;
        }

        if (other.gameObject.tag == "movable")
        {
            MovableBlock();
        }
    }

    private void MovableBlock()
    {
        if (Input.GetButtonDown("Grapple"))
        {

        }
        else if (Input.GetButtonUp("Grapple"))
        {

        }
    }
}
