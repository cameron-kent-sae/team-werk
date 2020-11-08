using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{

    public float FollowSpeed = 2f;

    public float leftPoint;
    public float rightPoint;
    public float topPoint;
    public float buttonPoint;


    private Transform target;

    void Start()
    {
        print(Screen.width);

    }

    // Start is called before the first frame update
    void LateUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //t = play.transform;

        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        //transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);


        if (transform.position.x <= leftPoint)
        {
            transform.position = new Vector3(leftPoint, target.position.y, -10f);
        }

        if (transform.position.x >= rightPoint)
        {
            transform.position = new Vector3(rightPoint, target.position.y, -10f);
        }

        if (transform.position.y >= topPoint)
        {
            transform.position = new Vector3(target.position.x, topPoint, -10f);
        }

        if (transform.position.y <= buttonPoint)
        {
            transform.position = new Vector3(target.position.x, buttonPoint, -10f);
        }

        if (transform.position.x <= leftPoint && transform.position.y <= buttonPoint)
        {
            transform.position = new Vector3(leftPoint, buttonPoint, -10f);
        }

        if (transform.position.x >= rightPoint && transform.position.y <= buttonPoint)
        {
            transform.position = new Vector3(rightPoint, buttonPoint, -10f);
        }

        if (transform.position.x <= leftPoint && transform.position.y >= topPoint)
        {
            transform.position = new Vector3(leftPoint, topPoint, -10f);
        }

        if (transform.position.x >= rightPoint && transform.position.y >= topPoint)
        {
            transform.position = new Vector3(rightPoint, topPoint, -10f);
        }

    }


}

