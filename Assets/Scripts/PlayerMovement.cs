using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform target; 
    public float gravityScale = 1; 
    public float velocityBuffer = 0.1f;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        rb2d.gravityScale = gravityScale;

        CalculateInitialVelocity();
    }

    void CalculateInitialVelocity()
    {
        if (target == null) return;

        float distanceY = target.position.y - transform.position.y;

        float gravity = Mathf.Abs(Physics2D.gravity.y) * rb2d.gravityScale; 
        float initialVelocity = Mathf.Sqrt(2 * gravity * distanceY);

        rb2d.velocity = new Vector2(rb2d.velocity.x, initialVelocity);
    }

    void FixedUpdate()
    {
        if (target != null && Mathf.Abs(transform.position.y - target.position.y) < velocityBuffer)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        }
    }
}
