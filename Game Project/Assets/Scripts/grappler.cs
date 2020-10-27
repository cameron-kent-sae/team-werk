using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grappler : MonoBehaviour
{
    public grappleIndicator grappleIndication;
    public LineRenderer whipRenderer;
    public DistanceJoint2D distanceJoint;
    public Camera mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        distanceJoint.enabled = false;
        whipRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Grapple"))
        {
            whipRenderer.SetPosition(0, grappleIndication.firePoint.position);
            whipRenderer.SetPosition(1, grappleIndication.grapplePoint);
            distanceJoint.connectedAnchor = grappleIndication.grapplePoint;
            distanceJoint.enabled = true;
            whipRenderer.enabled = true;
        }
        else if (Input.GetButtonUp("Grapple"))
        {
            distanceJoint.enabled = false;
            whipRenderer.enabled = false;
            //grappleIndication.grappleRope.enabled = false;
        }
        if (distanceJoint.enabled)
        {
            whipRenderer.SetPosition(0, grappleIndication.firePoint.position);
        }
    }
}
