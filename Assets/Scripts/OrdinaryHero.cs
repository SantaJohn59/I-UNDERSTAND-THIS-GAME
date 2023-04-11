using UnityEngine;

public class OrdinaryHero : MonoBehaviour
{
    private float speed = 3f;
    private float jumpForce = 6f;
    private bool isGrounded = false;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Run()
    {
        var dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        sprite.flipX = dirX < 0;
    }

    void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        if (Input.GetButtonDown("Jump"))
            Jump();
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;
    }
}