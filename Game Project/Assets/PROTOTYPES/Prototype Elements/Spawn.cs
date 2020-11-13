using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject player;
    public Transform spawns;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (GameObject.FindWithTag("Player"))

        {
            //Debug.Log("ok");       
        }
        else
        {
            Instantiate(player, spawns.position, spawns.rotation);
        }
    }
}
