using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    private bool attached = false;
    private Rigidbody rb;
    private float length;
    private Vector3 tetherPoint;
    public Camera fpsCam;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("q")) {
            GrappleHook();
        }
    }

    void GrappleHook() {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit)) {
            Target target = hit.transform.GetComponent<Target>();
        }
    }
}
