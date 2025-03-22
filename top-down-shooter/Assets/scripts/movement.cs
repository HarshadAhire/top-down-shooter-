using UnityEngine;

public class movement : MonoBehaviour
{
   private Rigidbody2D rb;
    public float speed = 5f;
    Vector2 move;
    Vector2 mousepos;
    public Camera cam;



    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
       move.y= Input.GetAxisRaw("Vertical");

        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void FixedUpdate()
    {

        rb.MovePosition(rb.position+move * speed * Time.fixedDeltaTime);

        Vector2 lookdir = mousepos - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
