using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    //In case of the camera follower will filp together with the player when the gravity change
    //It can solved to create a empty object to follow the player
    //Attach this empty object to the camera follow instead of the player object

    public Transform player;

    void Update()
    {
        Vector3 playPro = player.transform.position;
        transform.position = new Vector3(playPro.x, playPro.y, transform.position.z);
    }
}
