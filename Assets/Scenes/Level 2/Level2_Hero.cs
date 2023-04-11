using UnityEngine;

public class Level2_Hero : MonoBehaviour
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
    }

    private void Run()
    {
        var dirX = -1 * Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        sprite.flipX = dirX < 0;
    }
}