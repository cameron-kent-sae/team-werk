using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    //void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Damage") || other.gameObject.CompareTag("AI"))
        {
            Destroy(gameObject);
        }
    }
}
