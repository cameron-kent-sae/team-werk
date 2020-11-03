using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGravity : MonoBehaviour
{
    private Rigidbody2D rb;

    //refer to the player controllor stript
    private TestControl player;
    
    private bool top;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<TestControl>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            rb.gravityScale *= -1;
            Rotation();
        }

        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    Physics2D.gravity = new Vector2(-9.81f, 0f);
        //    transform.eulerAngles = new Vector3(0, 0, -90f);
       // }
    }

    void Rotation()
    {
        if (top == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
        player.facingRight = ! player.facingRight;
        player.jumpVelocity *= -1;
        top = !top;
    }
}
