using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 1f, moveSpeed = 2f, direction;
    [SerializeField] private AudioClip deathNoise;
    public AudioSource _audioSource;
    [SerializeField] private HealthBar healthBar;
    private float MaxHealth;
    private GameObject hp;
    bool movingRight = true;
    Rigidbody rb;
    public int leftWayPoint = 0, rightWayPoint = 0;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        MaxHealth = health;
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > rightWayPoint)
        {
            movingRight = false;
        }
        if(transform.position.x < leftWayPoint)
        {
            movingRight = true;
        }
        if(movingRight)
        {
            moveRight();
        } else {
            moveLeft();
        }
        if(transform.position.y < -10)
        {
            Turn.Reference.Kill();
            Destroy(gameObject);
        }
    }
    void moveRight()
    {
        direction = 1;
        rb.velocity = new Vector3(direction * moveSpeed, rb.velocity.y, rb.velocity.z);
    }
    void moveLeft()
    {
        direction = -1;
        rb.velocity = new Vector3(direction * moveSpeed, rb.velocity.y, rb.velocity.z);
    }
    public void TakeDamage(float damage) {
        health = health - damage;
        (hp.GetComponent(typeof(HealthBar)) as HealthBar).SetProgress(health/MaxHealth);
        if (health <= 0f) {
            Die();
        }
    }

    void Die(){
        _audioSource.PlayOneShot(deathNoise);
        Turn.Reference.Kill();
        Destroy(gameObject);
        Destroy(hp);
    }
    public void setupHP(Canvas canvas, Camera camera){
        healthBar.SetTarget(transform);
        hp = Instantiate(healthBar.gameObject, transform.position, Quaternion.identity) as GameObject;
        hp.transform.SetParent(canvas.transform);
        if (hp.TryGetComponent<FaceCamera>(out FaceCamera faceCamera)) {
            faceCamera.Camera = camera;
        }
    }
}
