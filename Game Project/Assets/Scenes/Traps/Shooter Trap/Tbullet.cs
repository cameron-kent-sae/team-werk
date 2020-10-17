using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tbullet : MonoBehaviour
{

    Rigidbody2D rb;
    public Vector2 dir = new Vector2(0, 0);


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        //object move, base on variable  
        rb.velocity = dir;
    }


    // kill player on touched 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("kill");
            Destroy(other.gameObject);

        }
    }


}
