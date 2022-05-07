using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Turn : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction move;
    private InputAction grapple;
    public GameControls playerControls;
    Vector2 moveDirection = Vector2.zero;

    public float speed = 300, jumpF = 3f;

    float XRotation, YRotation, ZRotation;

    public bool grounded;
    public Vector3 jump;

    private GameObject target;
    public static Turn Reference;
    private int KilledEnemies;
    public Clock clock;
    public Gun gun;
    public Score score;
    private int totalEnemies;
    Rigidbody rb;

    Vector3 stepVector;
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        Reference = this;
    }
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
        KilledEnemies = 0;
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
// #if UNITY_EDITOR
//             // Application.Quit() does not work in the editor so
//             // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
//             UnityEditor.EditorApplication.isPlaying = false;
// #else
//             Application.Quit();
// #endif
        }

        // Translates when using left click, forwards
        if(Input.GetKey("z")) {
            transform.Translate(Vector3.forward * 5 * Time.deltaTime, Space.Self);
        }

        // Translates when using right click, backwards
        else if(Input.GetKey("c")) {
            transform.Translate(Vector3.forward * -5 * Time.deltaTime, Space.Self);
        }

        if(playerInput.actions["Jump"].triggered){

            //rb.AddForce(jump * jumpF, ForceMode.Impulse);
            Debug.Log("Space was Pressed");
            grounded = false;
        }

        
        XRotation = 0;
        YRotation = target.transform.eulerAngles.y + (speed * Time.deltaTime * Input.GetAxis("Mouse X"));
        ZRotation = 0;

        // Quaternion values, as suggested by the assignment page.
        Quaternion rots = Quaternion.Euler(XRotation, YRotation, ZRotation);
        moveDirection = playerInput.actions["Move"].ReadValue<Vector2>();
        if(Input.GetKey(KeyCode.LeftShift)) {
            transform.rotation = rots;

            float sideway = moveDirection.x * Time.deltaTime * 30;
            float forward = moveDirection.y * Time.deltaTime * 30;

            transform.Translate(sideway, 0, forward);
        }
        else {
            transform.rotation = rots;

            float sideway = moveDirection.x * Time.deltaTime * 10;
            float forward = moveDirection.y * Time.deltaTime * 10;

            transform.Translate(sideway, 0, forward);
        }
        if(transform.position.y < -10)
        {
            ReloadLevel();
        }
        if(KilledEnemies == totalEnemies)
        {
            float time = clock.tm();
            float damage = gun.dmg();
            float accuracy = gun.accuracy();
            (int hs,int score) s = score.getScore(time, accuracy, damage);
            if (s.hs == 1) {
                PlayerPrefs.SetInt("highscoreBool", 1);
            }
            else {
                PlayerPrefs.SetInt("highscoreBool", 0);
            }
            PlayerPrefs.SetInt("currScore", s.score);
            ScoreScreen();
        }
    }
    //Fixed update called once every physics step 
    //approximately twice per frame on 25 fps
    private void FixedUpdate() {
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0) {
            return;
        }

        if (!grounded) {
            rb.AddForce(Vector3.up * jumpF, ForceMode.VelocityChange);
            grounded = true;
        }
    }
    public void setTotalEnemies(int total) {
        totalEnemies = total;
    }
    public void Kill(){
        KilledEnemies += 1;
        Debug.Log(KilledEnemies);
        Debug.Log(totalEnemies);
    }
    void ReloadLevel()
    {
        KilledEnemies = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void ScoreScreen()
    {
        PlayerPrefs.SetString("currScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("currSceneInt", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Score");
    }
}
