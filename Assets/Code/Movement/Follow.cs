using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float speed = 200;
    public float minRotation = -45;
    public float maxRotation = 45;

    public GameObject target;

    Vector3 stepVector;

    float XRotation;
    float YRotation;
    float ZRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        stepVector = speed * Vector3.forward;
        target = GameObject.Find("Player Character");

        XRotation = 0;
        YRotation = 0;
        ZRotation = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //This code follows the Me object, keeping the same position, but keeping 
        //the y axis parrallel to the ground (i.e. the global y axis)
        //This allows the Me object to rotate on the "global axis."
        transform.position = target.transform.position;

        XRotation = 0;
        YRotation = target.transform.eulerAngles.y;
        ZRotation = 0;

        Quaternion rots = Quaternion.Euler(XRotation, YRotation, ZRotation);

        transform.rotation = rots;
    }
}
