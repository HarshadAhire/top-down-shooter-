using UnityEngine;

public class bullet : MonoBehaviour
{
    int damage = 20;
 

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            health enemyHealth = collision.gameObject.GetComponent<health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                Destroy(gameObject); // Destroy the bullet after hitting the enemy
            }
        }

    }
}