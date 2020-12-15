using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRollStone : MonoBehaviour
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

        // facing left when start
        if (movingRight == false)
        {
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
            movingRight = false;
        }

    }

    void Update()
    {
        //object only moving x or y when on the ground
        isGrounded = Physics2D.OverlapCircle(hitGround.position, checkRadius, whatIsGround);

        if (isGrounded == true)
        {
            rb.velocity = new Vector2(transform.localScale.x, 0) * speed;
        }
    }

    //Object filp when hit the wall or AI
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("AI"))
        {
            Retune();
        }

        if (other.gameObject.CompareTag("Damage"))
        {
            Destroy(gameObject);
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
