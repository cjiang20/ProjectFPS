using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 1f;

    public void TakeDamage(float damage) {
        health = health - damage;
        if (health <= 0f) {
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }
}
