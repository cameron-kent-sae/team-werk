using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAct : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) ;
        print("ok");
        GetComponent<Tpathing>().enabled = true;
        GetComponent<AudioSource>().enabled = true;
    }
}
