using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushblock : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask movable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit =  Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, movable);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}
