using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tshooter : MonoBehaviour
{
    public Transform shootPoint;  //shooting point
    public GameObject bullet; //bullet Object

    public Animator animator;
    //public bool trigger;

    private float time = 0;

    [Range(0, 5)]
    public float bulletDelay; //Delay time

    public bool fromRight = false; //filp the trap's direction
    public bool shoot; //trigger trap or keep to shoot

    void Start()
    {
        //using to filp the trap and the bullet direction
        if (fromRight == true)
        {
            transform.Rotate(0f, 180f, 0f);
        }
    }

    void Update()
    {
        //Instantiaste the bullet if shoot in true
        if (shoot == true)
        {
            animator.SetBool("trigger", true);
            if (time < Time.time)
            {
                Instantiate(bullet, shootPoint.position, shootPoint.rotation);
                time = Time.time + bulletDelay; //bullet delay time
            }
        }
    }

    //Trigger the trap by the player when enter the collision , exit to switch off
    //Turn off the collision if it is a timed type
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shoot = true;
            animator.SetBool("trigger", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shoot = false;
            animator.SetBool("trigger", false);
        }
    }
}
