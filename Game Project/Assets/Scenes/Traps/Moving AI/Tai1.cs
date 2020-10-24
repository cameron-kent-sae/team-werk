using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tai1 : MonoBehaviour
{
    public float speed = 10f; //AI speed

    public bool movingRight = true; //facing right or not
    public Transform groundDetection; //object for ground check
    public Transform wallCheck; //object for wall check

    private Rigidbody2D body2D;

 
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();

        // to set which way the AI facing when start
        if (movingRight == false)
        {
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
    }

  
    void Update()
    {
        body2D.velocity = new Vector2(transform.localScale.x, 0) * speed; //AI moving 

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f); //create a raycast, checking any ground tile in the front

        if (groundInfo.collider == false) //if the edge in the front, turn back
        {
            Retune();
        }

        RaycastHit2D wallInfo = Physics2D.Raycast(wallCheck.position, Vector2.down, 0.05f); //create a raycast, checking any wall in the front


        //if hit the collider and the tag is Tilemap then turn back
        if (wallInfo.collider == true && wallInfo.collider.gameObject.CompareTag("Tilemap")) 
        {
            Retune();
        }
        if (wallInfo.collider == true && wallInfo.collider.gameObject.CompareTag("AI"))
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
