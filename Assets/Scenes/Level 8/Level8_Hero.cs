using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level8_Hero : MonoBehaviour
{
    private float speed = 3f;
    private float jumpForce = 4f;
    private bool isGrounded;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private JumpsCountRemaining jc;
    [SerializeField] private TextMeshProUGUI textAboutJumpsCountRemaining;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        jc = new JumpsCountRemaining(7, textAboutJumpsCountRemaining);
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
        if (!jc.areJumpsOver && Input.GetButtonDown("Jump") && (++jumpsCountAfterGroundTuch < maxJumpValue))
            Jump();
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        OnJump.Invoke();
    }

    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask Ground;
    private float checkRadius = 0.1f;
    private int jumpsCountAfterGroundTuch;
    private int maxJumpValue = 2;

    private void IsGroundedUpate()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
        if (isGrounded) jumpsCountAfterGroundTuch = 0;
    }

    public static Action OnJump;

    public void ReloadLevel()
    {
        OnJump -= jc.UpdateJumpsCountRemaining;
        jc = new JumpsCountRemaining(7, textAboutJumpsCountRemaining);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
