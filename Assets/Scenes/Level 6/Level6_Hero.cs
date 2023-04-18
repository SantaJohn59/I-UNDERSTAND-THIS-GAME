using UnityEngine;

public class Level6_Hero : MonoBehaviour
{
    private float speed = 3f;
    private float jumpForce = 4f;
    private bool isGrounded;

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

        IsGroundedUpate();
        if (Input.GetButtonDown("Jump") && isGrounded)
            Jump();
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask Ground;
    private float checkRadius = 0.1f;


    private void IsGroundedUpate()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }
}