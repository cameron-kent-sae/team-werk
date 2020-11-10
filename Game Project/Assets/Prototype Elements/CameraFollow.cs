using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float offset;
    private Transform playerTransform;


    // Start is called before the first frame update
    void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //t = play.transform;
    }

    void LateUpdate()
    {
        Vector3 temp = transform.position;

        temp.x = playerTransform.position.x;

        temp.y = playerTransform.position.y;

        temp.x += offset;

        transform.position = temp;
    }

}
