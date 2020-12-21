using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{

    //Life manager
    public LifeCounter lifeCounter;

    // Calls controller script
    public CharacterController2D controller;
    public grappler grappleRope;

    public Animator animator;
    

    // Creating transform points
    public Transform grapplePoint;
    public Transform spawn;

    public float health = 1f;

    // Adds Sound Effects
    public AudioSource dashSound;
    public AudioClip jumpSound;
    public AudioClip jetpackSound;
    public AudioClip dead;

    // Speed variables
    public float walkSpeed = 40f;
    private float runSpeed = 0f;
    private float movementSpeed;
    private float horizontalMove = 0f;

    private bool jump = false;
    private bool jumpJetpack = false;

    // Start is called before the first frame update
    void Start()
    {
        grappleRope.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        movementSpeed = walkSpeed + runSpeed;
        horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            AudioSource.PlayClipAtPoint(jumpSound, transform.position,0.1f);
            
        }
        if (Input.GetButtonDown("Jetpack"))
        {
            jumpJetpack = true;
            animator.SetBool("IsJetpacking", true);
            AudioSource.PlayClipAtPoint(jetpackSound, transform.position, 0.1f);
        }
        if (Input.GetButtonDown("Run"))
        {
            runSpeed = 40f;
            animator.SetBool("IsDashing", true);
            dashSound.Play();
        }
        else if (Input.GetButtonUp("Run"))
        {
            runSpeed = 0f;
            animator.SetBool("IsDashing", false);
            dashSound.Stop();
        }
        if (health <= 0)
        {
            //Invoke("RespawnPlayer", 2);

            health = 1;
            StartCoroutine(Dead());

        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsJetpacking", false);
    }

    private void FixedUpdate()
    {
        // Move the character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump, jumpJetpack);
        jump = false;
        jumpJetpack = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Grapple")
        {
            grapplePoint = other.gameObject.transform;
            grappleRope.enabled = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Damage") || other.gameObject.CompareTag("AI"))
        {
            AudioSource.PlayClipAtPoint(dead, transform.position, 0.1f);
            animator.SetBool("IsDead", true);
            health -= 1;
            
        }
    }

    private void RespawnPlayer()
    {
        gameObject.transform.position = spawn.position;
        animator.SetBool("IsDead", false);
        health = 1;
    }

    //when the player die, wait a sec and reload the scene
    IEnumerator Dead()
    {
        lifeCounter.LoseLife();
        yield return new WaitForSeconds(1);
        Application.LoadLevel(Application.loadedLevel); 
    }
}
