using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grappler : MonoBehaviour
{
    // Calls scripts
    public playermovement grappleIndication;

    // Calling components from the inspector
    public LineRenderer whipRenderer;
    public DistanceJoint2D distanceJoint;

    // Setting initial grapple point
    public Transform firePoint;
    
    // Start is called before the first frame update
    void Start()
    {
        distanceJoint.enabled = false;
        whipRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Initiates whip grapple
        if (Input.GetButtonDown("Grapple"))
        {
            // Setting parameters for the line renderer
            whipRenderer.SetPosition(0, firePoint.position);
            whipRenderer.SetPosition(1, grappleIndication.grapplePoint.position);
            //setting parameters for distance joint 2D
            distanceJoint.connectedAnchor = grappleIndication.grapplePoint.position;
            distanceJoint.enabled = true;
            whipRenderer.enabled = true;
        }
        // Ends the whip grapple
        else if (Input.GetButtonUp("Grapple"))
        {
            distanceJoint.enabled = false;
            whipRenderer.enabled = false;
            // Disables this script to prevent use when its not needed
            this.enabled = false;
        }

        // Sets line renderers position during grapple
        if (distanceJoint.enabled)
        {
            whipRenderer.SetPosition(0, firePoint.position);
        }
    }
}
