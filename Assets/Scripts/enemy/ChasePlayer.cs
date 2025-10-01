using UnityEngine;

public class MoveTowardsTarget2D : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Move towards the target using physics
        Vector2 direction = ((Vector2)target.position - rb.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        // Optional: Stop movement on collision
        enabled = false;
    }
}