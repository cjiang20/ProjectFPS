using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 1f;
    [SerializeField] private AudioClip deathNoise;
    public AudioSource _audioSource;

    public void TakeDamage(float damage) {
        health = health - damage;
        if (health <= 0f) {
            Die();
        }
    }

    void Die(){
        _audioSource.PlayOneShot(deathNoise);
        Destroy(gameObject);
    }
}
