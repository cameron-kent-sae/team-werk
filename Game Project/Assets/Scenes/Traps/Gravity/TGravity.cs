using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TGravity : MonoBehaviour
{
    private Rigidbody2D rb;

    //refer to the player controllor stript
    private TestControl player;

    //UI message
    public Text message;

    private bool top;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<TestControl>();
    }


    //If player OnTrigger, Press E to invoke the event
    void OnTriggerStay2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Gravity Buttom"))
        {
            message.text = "Press A to change the gravity";

            if (Input.GetKeyDown(KeyCode.A))
            {
                rb.gravityScale *= -1;
                Rotation();
            }

        }
    }

    void OnTriggerExit2D(Collider2D trigger)
    {

        if (trigger.gameObject.CompareTag("Gravity Buttom"))
        {
            message.text = " ";
        }
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
