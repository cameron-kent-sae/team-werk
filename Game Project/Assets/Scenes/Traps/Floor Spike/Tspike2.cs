using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tspike2 : MonoBehaviour
{

    //Set to trigger trap
    public bool Triggered;

    public Animator animator;

    //Time for finish the animation
    public float waitToFinish;

    void Start()
    { 
        //if trap is triggered, the animation active when start 
        if (Triggered == true)
        {
            animator.SetBool("Trigger", true);
        }
    }

    //when player stand on that tile, trap animation -> trigger
    //**Another collider actived by the animation which take damage to the player 
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Trigger", true);
            StartCoroutine(Finish());
        }
    }

    IEnumerator Finish()
    {
        //set the time for the animation to finish, then reset the trap
        yield return new WaitForSeconds(waitToFinish);
        animator.SetBool("Trigger", false);
        Start();
    }

}
