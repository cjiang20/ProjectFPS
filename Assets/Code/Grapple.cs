using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    private bool attached = false;
    private Rigidbody rb;
    private float length;
    private Vector3 tetherPoint;
    private Camera viewPoint;

    // Start is called before the first frame update
    void Start()
    {
        viewPoint = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q")) {
            if(!attached) {
                GrappleHook();
            }
            else {
                EndGrapple();
            }
        }

        if(attached) {
            grapplePhysics();
        }
    }

    void grapplePhysics() {
        // Vector3 directionToGrapple = Vector3.Normalize(tetherPoint - transform.position);
        // float currentDistanceToGrapple = Vector3.Distance(tetherPoint, transform.position);

        // float speedTowardsGrapplePoint = Mathf.Round(Vector3.Dot(rb.velocity, directionToGrapple) * 100) / 100;

        // if (speedTowardsGrapplePoint < 0) {
        //     if (currentDistanceToGrapple > length) {
        //         rb.velocity -= speedTowardsGrapplePoint * directionToGrapple;
        //         rb.position = tetherPoint - directionToGrapple * length;
        //     }
        // }
    }

    void GrappleHook() {
        RaycastHit hit;
        if (Physics.Raycast(viewPoint.transform.position, viewPoint.transform.forward, out hit)) {
            tetherPoint = hit.point;
            attached = true;
            length = Vector3.Distance(tetherPoint, transform.position);
            print("WE GOTTEM");
            print(tetherPoint);
        }
    }
    
    void EndGrapple() {
        attached = false;
    }
}
