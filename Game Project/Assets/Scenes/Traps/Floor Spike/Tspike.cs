using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tspike : MonoBehaviour
{
    public Transform playerDetection;

    public Animator animator;


    void Update()
    {
        RaycastHit2D playerdetect = Physics2D.Raycast(playerDetection.position, Vector2.right, 0.5f);

        if (playerdetect != null)
        {
            if (playerdetect.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("hit");
                animator.SetBool("Trigger", true);
            }
            else
            {
                animator.SetBool("Trigger", false);
            }
        }
            

    }
    //Trigger the trap by the player when enter the collision , exit to switch off
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}
