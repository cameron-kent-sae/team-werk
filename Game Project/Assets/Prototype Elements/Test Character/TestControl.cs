using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControl : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    public Animator animator;


    [Range(1, 10)]
    public float jumpVelocity;

    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;

    public bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }




    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        animator.SetFloat("yVelocity", rb.velocity.y);

        if (isGrounded == true)
        {
            //animator.SetBool("Jumping", false);
            animator.SetBool("Grounded", true);

            if (Input.GetButtonDown("Jump"))
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
                //animator.SetBool("Jumping", true);
            }
        }
        else
        {
            animator.SetBool("Grounded", false);
        }

        if (isGrounded == true)
        {
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

            animator.SetFloat("speed", Mathf.Abs(moveInput));
        }


        if (facingRight == false && moveInput > 0)
        {
            Filp();
        }

        else if (facingRight == true && moveInput < 0)
        {
            Filp();
        }

    }

    void Filp()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


}
