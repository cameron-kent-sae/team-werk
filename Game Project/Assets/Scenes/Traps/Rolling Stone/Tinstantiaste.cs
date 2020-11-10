using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tinstantiaste : MonoBehaviour
{
    public GameObject trap; //trap Object
    public Transform trapLocation;

    private float time = 0;

    [Range(0, 5)]
    public float bulletDelay; //Delay time

    public bool shoot; //trigger trap or keep to shoot

void Update()
    {
        //Instantiaste the bullet if shoot in true
        if (shoot == true)
        {
            if (time < Time.time)
            {
                Instantiate(trap, trapLocation.position, trapLocation.rotation);
                time = Time.time + bulletDelay; //bullet delay time
            }
        }
    }
}
