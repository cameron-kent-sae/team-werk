using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGravity2 : MonoBehaviour
{
    //Add this script to the player, player can walk on the ceiling after chicked the button (Tag "Gravity Button")

    private Rigidbody2D rb;

    //refer to the player controllor stript
    private CharacterController2D player;


    private bool top;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<CharacterController2D>();
    }


    //If player Enter the area tag(UpSide Down)
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("UpSide Down"))
        {
            rb.gravityScale *= -1;
            Rotation();
        }

    }

    void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("UpSide Down"))
        {
            rb.gravityScale *= -1;
            Rotation();

        }
    }

    //filing the character when the gravity was changed 
    void Rotation()
    {
        if (top == false)
        {
            //Rotate player 180
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }


        //player.facingRight = ! player.facingRight;
        player.m_FacingRight = !player.m_FacingRight;

        //changing jump force to "- value" when upside down, so player can jump on the ceiling
        player.m_JumpForce *= -1;
        player.m_jetpackJumpForce *= -1;

        top = !top;
    }
}
