using UnityEngine;

public class Level3_Hero : MonoBehaviour
{
    private float speed = 3f;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        if (Input.GetButtonDown("Jump"))
            ChangeGravity();
    }

    private void Run()
    {
        var dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        sprite.flipX = dirX < 0;
    }

    private void ChangeGravity()
    {
        rb.gravityScale *= -1;
        sprite.flipY = !sprite.flipY;
    }
}