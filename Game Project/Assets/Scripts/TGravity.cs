﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TGravity : MonoBehaviour
{
    //Add this script to the player, player can walk on the ceiling after chicked the button (Tag "Gravity Button")

    private Rigidbody2D rb;

    //refer to the player controllor stript
    private CharacterController2D player;

    //UI message, showing message to tell player press the key 
    public Text message;

    private bool top;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<CharacterController2D>();
    }


    //If player OnTrigger, Press A to active the effect, upside down
    void OnTriggerStay2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Gravity Button"))
        {
            message.text = "Press A to change the gravity";

            if (Input.GetKeyDown(KeyCode.A))
            {
                //change the gravity upside down
                rb.gravityScale *= -1;
                Rotation();
            }
        }
    }

    void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Gravity Button"))
        {
            message.text = " ";
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
