using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TKey : MonoBehaviour
{
    public GameObject door;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

            door.SetActive(true);
        }
    }
}
