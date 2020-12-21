using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tblackbox : MonoBehaviour
{
    //Life manager
    public LifeCounter lifeCounter;

    private void Start()
    {
        lifeCounter = FindObjectOfType<LifeCounter>();
    }

    //When player collide, active the portal object
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lifeCounter.AddLife();
            Destroy(gameObject);
        }
    }
}
