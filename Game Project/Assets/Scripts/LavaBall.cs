using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBall : MonoBehaviour
{
    public Rigidbody2D rb;


    void Start()
    {
        rb.velocity = transform.up * Random.Range(3.5f, 5.50f) + transform.right * Random.Range(-2.0f, 2f);
    }


    // Destroy when hitting the object 
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Tilemap") || other.gameObject.CompareTag("Damage") || other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);

        }
    }

}
