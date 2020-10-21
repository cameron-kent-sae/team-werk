using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tpathing : MonoBehaviour
{
    //array of path
    public Transform[] wayPoint;

    public float speed;

    //Way point number
    public int wayPointNumber;

    private int wayPointIndex = 0;


    void Start()
    {
        //trap start location
        transform.position = wayPoint[wayPointIndex].transform.position;
    }


    //Kill on touched
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("kill");
            Destroy(other.gameObject);

        }
    }


    void Update()
    {
        Move();
    }


    private void Move()
    {

        if (wayPointIndex <= wayPoint.Length - 1)
        {
            //object moves toward to the index position, 
            transform.position = Vector2.MoveTowards(transform.position, wayPoint[wayPointIndex].transform.position, speed * Time.deltaTime);

            //if object location = current location, Index +1
            if (transform.position == wayPoint[wayPointIndex].transform.position)
            {
                wayPointIndex += 1;
            }
        }

        //when object reachs the last point, reset to 0
        if (wayPointIndex == wayPointNumber) // <-- this number = number of way Point
        {
            wayPointIndex = 0;
        }
    }


}
