using UnityEngine;

public class FreeFallDuration : MonoBehaviour
{
    public float gravityScale = 1; 
    public float Prediction; 
    public float Actual; 

    private Rigidbody2D rb2d;
    private bool isFalling = false;
    private float startFallTime;
    private float fallStartHeight;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        rb2d.gravityScale = gravityScale;

        CalculateFallDurationPrediction();
    }

    void Update()
    {
        if (isFalling)
        {
            Actual = Time.time - startFallTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isFalling = false;
        }
    }

    void CalculateFallDurationPrediction()
    {
        float height = fallStartHeight = transform.position.y;

        float gravity = Mathf.Abs(Physics2D.gravity.y) * rb2d.gravityScale;

        if (gravity <= 0)
        {
            return;
        }

        Prediction = Mathf.Sqrt(2 * height / gravity);

        isFalling = true;
        startFallTime = Time.time;
    }
}
