using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushblock : MonoBehaviour
{
    public float distance = 0.6f;
    public Transform grabCheck;
    public Transform blockHolder;
    
    
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit =  Physics2D.Raycast(grabCheck.position, Vector2.left * transform.localScale, distance);

        if (hit.collider != null && hit.collider.gameObject.tag == "pushblock")
        {
            if (Input.GetButtonDown("MoveBlock"))
            {
                hit.collider.gameObject.transform.parent = blockHolder;
                hit.collider.gameObject.transform.position = blockHolder.position;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else if (Input.GetButtonUp("MoveBlock"))
            {
                hit.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                hit.collider.gameObject.transform.parent = null;
            }
        }
    }
}
