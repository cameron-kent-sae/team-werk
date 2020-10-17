using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tshooter : MonoBehaviour
{
    public GameObject shootTrap;  //Trap Object
    public Tbullet bulletPrefab; //bullet Object
    public float bulletSpeed; //bullet speed
    private float time = 0;

    [Range(1, 5)]
    public float bulletDelay; //Delay time

    public bool fromRight = false; //filp the trap's direction
    public bool shoot; //trigger trap or keep shooting

    private Vector2 dir2; //bullet shoot direction and force

    void Start()
    {
        //using to filp the trap and the bullet direction
        if (fromRight == true)
        {
            Vector3 newScale = shootTrap.transform.localScale;
            newScale.x *= -1; //filp the object
            shootTrap.transform.localScale = newScale;

            dir2 = new Vector2(bulletSpeed, 0); //bullet shoot direction and speed
            dir2.x *= -1; //filp the object
        }
        else
        {
            dir2 = new Vector2(bulletSpeed, 0); //bullet shoot direction and speed
        }

    }

    void Update()
    {
        //Instantiaste the bullet on the arrowPrefab location and shoot, can adjust the delay in the inspector
        if (shoot == true)
        {

            if (time < Time.time)
            {
                Tbullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as Tbullet;
                bullet.dir = dir2;

                time = Time.time + bulletDelay; //bullet delay time
            }
        }
    }

    //Trigger the trap by the player when enter the collision , exit to switch off
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shoot = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shoot = false;
        }
    }
}
