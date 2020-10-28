using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    // Calls controller script
    public CharacterController2D controller;
    public grappler grappleRope;

    // Calls the animator
    // public Animator animator;

    // Creating transform points
    public Transform grapplePoint;
    public Transform spawn;

    public float health = 1f;

    // Speed variables
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
        if (health <= 0)
        {
            gameObject.transform.position = spawn.position;
            health = 1;
        }
    }

    public void OnLanding()
    {
        // animator.SetBool("isJumping", false);
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
        if (other.gameObject.tag == "Grapple")
        {
            grapplePoint = other.gameObject.transform;
            grappleRope.enabled = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Damage") || other.gameObject.CompareTag("AI"))
        {
            Debug.Log("dead");
            health -= 1;
        }
    }
}
