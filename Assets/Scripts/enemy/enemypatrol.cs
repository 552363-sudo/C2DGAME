using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public float rayDist = 2f;
    public Transform groundDetect;
    public PlayerController playerController;

    private bool movingRight = true;

    void Update()
    {
        
        print("Enemy says; The player has " + playerController.lives + " lives");
        
       
        // Move enemy
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Cast ray downward to check for ground
        RaycastHit2D groundCheck = Physics2D.Raycast(groundDetect.position, Vector2.down, rayDist);

        // If no ground, turn around
        if (groundCheck.collider == null)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0); // Flip left
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0); // Face right
                movingRight = true;
            }
        }
    }
}
