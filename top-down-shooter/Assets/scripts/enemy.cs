using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;

    private int currentWIn = 0;
    public float detectionRange = 5f;
    public Transform player;
    public float Distance;
    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player == null) return;
        Distance = Vector2.Distance(transform.position, player.position);
    

        if (Distance < detectionRange)
        {
            chaseplayer();
        }
        else
        {
            patrol();

        }
    }

    public void chaseplayer()
    {
        if (player == null) return;
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }
    public void patrol()
    {
        if(Vector2.Distance(transform.position, waypoints[currentWIn].position) < 0.02f)
        {
            currentWIn = (currentWIn + 1) % waypoints.Length;
        }
        Vector2 direction = (waypoints[currentWIn].position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<health>().TakeDamage(50);
            }
      
       
    }


}
