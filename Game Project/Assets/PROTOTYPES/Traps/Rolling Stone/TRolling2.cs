using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRolling2 : MonoBehaviour
{

    public float speed;

    int direction;

    public bool isGrounded;
    public Transform hitGround;
    public LayerMask whatIsGround;
    public float checkRadius;

    public bool movingRight = true;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // to set which way the AI facing
        if (movingRight == false)
        {
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
            movingRight = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(hitGround.position, checkRadius, whatIsGround);

        if (isGrounded == true)
        {
            rb.velocity = new Vector2(transform.localScale.x, 0) * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("AI"))
        {
            Retune();
        }
    }


    void Retune() //Filp the object
    {
        if (movingRight == true) //If facing right, filp the object 
        {
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
            movingRight = false;
        }
        else //If facing left, filp the object 
        {
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
            movingRight = true;
        }
    }


}
