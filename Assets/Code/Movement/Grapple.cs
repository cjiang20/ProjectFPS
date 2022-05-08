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
    private LineRenderer line;
    public Material lineMaterial;
    private bool oneTime;
    private Vector3 grapJump = new Vector3(0.0f, 5.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        viewPoint = Camera.main;
        rb = GetComponent<Rigidbody>();
        oneTime = true;
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
                oneTime = true;
            }
        }

        // if(attached) {
        //     grapplePhysics();
        // }
    }

    private void FixedUpdate() {
        if(oneTime == false) {
            GetComponent<Rigidbody>().AddForce(grapJump,ForceMode.Impulse);
            oneTime = true;
        }
        if(attached == true) {
            // StartCoroutine(stopGrav());
            line.SetPosition(0,transform.position);
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
    }

    // private IEnumerator stopGrav() {  
    //     Vector3 initialGravity = Physics.gravity;
    //     Physics.gravity = initialGravity * 0.5f;
    //     yield return new WaitForSeconds( 10f );
    //     Physics.gravity = initialGravity;
    // }

    void GrappleHook() {
        RaycastHit hit;
        if (Physics.Raycast(viewPoint.transform.position, viewPoint.transform.forward, out hit)) {
            oneTime = false;
            tetherPoint = hit.point;
            attached = true;
            length = Vector3.Distance(tetherPoint, transform.position);
            line = gameObject.AddComponent<LineRenderer>();
            line.material = lineMaterial;
            line.SetPosition(0, transform.position);
            line.startWidth = .05f;
            line.endWidth = .05f;
            line.SetPosition(1,tetherPoint);
            print("WE GOTTEM");
            print(tetherPoint);
        }
    }
    
    void EndGrapple() {
        attached = false;
        GameObject.Destroy(line);
    }
}
