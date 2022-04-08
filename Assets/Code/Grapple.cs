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

        if (Vector3.Distance(transform.position, tetherPoint) > 2.0f)
            {
                Vector3 normalized = (tetherPoint - transform.position).normalized;
                GetComponent<Rigidbody>().velocity = Vector3.MoveTowards(GetComponent<Rigidbody>().velocity, normalized * 10f, 1.0f);
            }
        else
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
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
