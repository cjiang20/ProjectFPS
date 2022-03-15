using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("q")) {
            transform.Translate(Vector3.forward * 5 * Time.deltaTime, Space.Self);
        }
    }
}
