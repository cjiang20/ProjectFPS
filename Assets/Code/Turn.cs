using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Turn : MonoBehaviour
{
    public float speed = 300;
    public float minRotation = -45;
    public float maxRotation = 45;

    float XRotation;
    float YRotation;
    float ZRotation;

    public bool grounded;
    public Vector3 jump;
    public float jumpF = 2.0F;

    public GameObject target;

    Rigidbody rb;

    Vector3 stepVector;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        stepVector = speed * Vector3.forward;
        target = GameObject.Find("Global Axis");

        XRotation = 0;
        YRotation = 0;
        ZRotation = 0;

        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

    }

    void onCollisionStay() {
        grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Quits game when Escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        // Translates when using left click, forwards
        if(Input.GetKey("q")) {
            transform.Translate(Vector3.forward * 5 * Time.deltaTime, Space.Self);
        }

        // Translates when using right click, backwards
        else if(Input.GetKey("e")) {
            transform.Translate(Vector3.forward * -5 * Time.deltaTime, Space.Self);
        }

        // if(Input.GetKeyDown(KeyCode.Space) && grounded){

        //     rb.AddForce(jump * jumpF, ForceMode.Impulse);
        //     grounded = false;
        // }

        // float sideway = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        // float forward = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        // transform.Translate(sideway, transform.localPosition.y, forward);

        // This code does the rotations proper, the target.transofrm.eulerAngles.y is the Global Axis's euler angles.
        // This allows use to use the "Global Axis" in order to rotate properly.  
        XRotation = transform.eulerAngles.x + (-1 * speed * Time.deltaTime * Input.GetAxis("Mouse Y"));
        YRotation = target.transform.eulerAngles.y + (speed * Time.deltaTime * Input.GetAxis("Mouse X"));
        ZRotation = 0;

        // Lock rotation between 0-45, and 315-360
        if(XRotation > 45f && XRotation <= 180f) {
            XRotation = 45f;
        }
        if(XRotation > 180f && XRotation < 315f) {
            XRotation = 315f;
        }

        // Quaternion values, as suggested by the assignment page.
        Quaternion rots = Quaternion.Euler(XRotation, YRotation, ZRotation);

        transform.rotation = rots;


    }
}
