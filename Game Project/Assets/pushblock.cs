using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushblock : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask movable;
    private GameObject block;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit =  Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, distance, movable);

        /*if (hit.collider != null && hit.collider.gameObject.tag == "pushblock" && Input.GetButtonDown("MoveBlock"))
        {
            block = hit.collider.gameObject;

            block.GetComponent<FixedJoint2D>().enabled = true;
            block.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
        else if (Input.GetButtonUp("MoveBlock"))
        {
            block.GetComponent<FixedJoint2D>().enabled = false;
        }*/
        if (hit.collider != null && hit.collider.gameObject.tag == "pushblock" && Input.GetButtonDown("MoveBlock"))
        {
            block = hit.collider.gameObject;

            this.GetComponent<FixedJoint2D>().enabled = true;
            this.GetComponent<FixedJoint2D>().connectedBody = block.GetComponent<Rigidbody2D>();
        }
        else if (Input.GetButtonUp("MoveBlock"))
        {
            this.GetComponent<FixedJoint2D>().enabled = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.left * transform.localScale.x * distance);
    }
}
