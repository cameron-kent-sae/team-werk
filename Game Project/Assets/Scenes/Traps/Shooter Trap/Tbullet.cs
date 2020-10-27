using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tbullet : MonoBehaviour
{

    public Rigidbody2D rb;
    public float bulletSpeed;


    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }



    // Destroy when hitting the tilemap 
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Tilemap")|| other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Damage"))
        {
            Destroy(gameObject);

        }
    }


}
