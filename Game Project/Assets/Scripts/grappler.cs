using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grappler : MonoBehaviour
{
    public Transform whipTarget;
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
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            whipRenderer.SetPosition(0, mousePos);
            whipRenderer.SetPosition(1, transform.position);
            distanceJoint.connectedAnchor = mousePos;
            distanceJoint.enabled = true;
            whipRenderer.enabled = true;
        }
        else if (Input.GetButtonUp("Grapple"))
        {
            distanceJoint.enabled = false;
            whipRenderer.enabled = false;
        }
        if (distanceJoint.enabled)
        {
            whipRenderer.SetPosition(1, transform.position);
        }
    }
}
