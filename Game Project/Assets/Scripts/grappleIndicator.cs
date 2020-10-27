using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grappleIndicator : MonoBehaviour
{
    public grappler grappleRope;
    public Transform grapplePoint;
    
    // Start is called before the first frame update
    void Start()
    {
        grappleRope.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        grapplePoint = other.gameObject.transform;
        grappleRope.enabled = true;
    }
}
