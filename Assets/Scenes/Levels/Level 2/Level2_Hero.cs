using UnityEngine;

public class Level2_Hero : MonoBehaviour
{
    private float speed = 3f;

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position - dir, speed * Time.deltaTime);
        sprite.flipX = -dir.x < 0.0f;

    }

    void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
    }

}