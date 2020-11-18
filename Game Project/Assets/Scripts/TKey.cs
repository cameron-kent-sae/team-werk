using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TKey : MonoBehaviour
{
    //for the portal object
    public GameObject door;

    //When player collide, active the portal object
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

            door.SetActive(true);
        }
    }
}
