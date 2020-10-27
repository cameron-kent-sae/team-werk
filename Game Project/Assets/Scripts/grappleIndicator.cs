using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grappleIndicator : MonoBehaviour
{
    public grappler grappleRope;
    public Transform firePoint;
    public Transform grappleTarget;
    public Vector2 grapplePoint;
    public float maxDistnace = 4f;
    public float grappleRange = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetGrapplePoint();
    }

    void SetGrapplePoint()
    {
        Vector2 distanceVector = grappleTarget.position;
        //if (Physics2D.Raycast(firePoint.position, distanceVector.normalized))
        if (Physics2D.Raycast(firePoint.position, distanceVector.normalized))
        {
            RaycastHit2D _hit = Physics2D.Raycast(firePoint.position, distanceVector.normalized);
            if (_hit.transform.gameObject.layer == 10)
            {
                if (Vector2.Distance(_hit.point, firePoint.position) <= maxDistnace)
                {
                    grapplePoint = _hit.point;
                    //grappleDistanceVector = grapplePoint - (Vector2)gunPivot.position;
                    grappleRope.enabled = true;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(grappleTarget.position, grappleRange);
    }
}
