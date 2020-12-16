using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    //For the drop platform and rolling stone, destroy when hit the border
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Damage") || other.gameObject.CompareTag("AI"))
        {
            Destroy(gameObject);
        }
    }
}
