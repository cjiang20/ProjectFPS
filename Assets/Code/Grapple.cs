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
    private bool jump;
    private bool jumping;
    private float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        viewPoint = Camera.main;
        rb = GetComponent<Rigidbody>();
        jump = false;
        jumping = false;
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

    void FixedUpdate()
    {
        if(jump) {
            GetComponent<Rigidbody>().velocity = Vector3.MoveTowards(GetComponent<Rigidbody>().velocity, ((tetherPoint - transform.position).normalized) * 20f, 6.0f);
            jumping = true;
        }
        if(jumping) {
            time = time + Time.fixedDeltaTime;
            if(time > 1.0f) {
                jump = false;
                jumping = false;
                time = 0;
            }
        }
        
    }

    void grapplePhysics() {
        // Vector3 directionToGrapple = Vector3.Normalize(tetherPoint - transform.position);
        // float currentDistanceToGrapple = Vector3.Distance(tetherPoint, transform.position);

        // float speedTowardsGrapplePoint = Mathf.Round(Vector3.Dot(rb.velocity, directionToGrapple) * 100) / 100;
        // Test change

        if (Vector3.Distance(transform.position, tetherPoint) > 2.0f)  //Need to add a if grapple is not seeable, break
            {
                jump = true;
                //Add a velocity towards what you are looking at when flying
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
