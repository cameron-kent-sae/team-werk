using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRollingstone : MonoBehaviour
{

    public float speed;

    int direction;

    public bool isGrounded;
    public Transform hitGround;
    public float landed = 1;
    public LayerMask whatIsGround;
    public float checkRadius;

    public bool movingRight = true;

    private Rigidbody2D rb;

    public Transform wallCheck;

    // Start is called before the first frame update
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


        RaycastHit2D wallInfo = Physics2D.Raycast(wallCheck.position, Vector2.down, 0.01f);
        if (wallInfo.collider == true && wallInfo.collider.gameObject.CompareTag("Tilemap"))
        {
            Retune();
        }
        if (wallInfo.collider == true && wallInfo.collider.gameObject.CompareTag("AI"))
        {
            Retune();
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Tilemap"))
        {
            if (landed == 1)
            {
                direction = Random.Range(1, 3);
                landed -= 1;
            }

            if (direction == 1)
            {
                Retune();
                landed += 1;
            }
            else
            {
                landed += 1;
            }
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