using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tblackbox : MonoBehaviour
{


    //When player collide, active the portal object
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

          
        }
    }
}
