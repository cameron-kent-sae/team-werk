using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tfloortrap : MonoBehaviour
{
    public GameObject trap;
    public GameObject triggerbutton;
    public Animator animator;

    [Range(1, 5)]
    public float delayTime;
    private float time = 0;

    public bool trigger;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Instantiaste the bullet on the arrowPrefab location and shoot, can adjust the delay in the inspector
        if (trigger == true)
        {
            animator.SetBool("Trigger", true);

            if (time < Time.time)
            {
                time = Time.time + delayTime;
            }
        }
    }

    //Trigger the trap by the player when enter the collision , exit to switch off
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            trigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            trigger = false;
        }
    }


}
