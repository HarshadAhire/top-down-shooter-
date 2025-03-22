using UnityEngine;

public class health : MonoBehaviour
{
    public float maxhealth = 100f;
    public float currenthealth;
    public Animator anim;
    public void Awake()
    {
        currenthealth = maxhealth;
    }

    public void TakeDamage(int damage)
    {
        currenthealth -= damage;

        anim.SetTrigger("hurt");

        if(currenthealth <= 0)
        {
            Die();
        }

    }
   void Die()
    {

        Destroy(gameObject);
        
     
    }
}
