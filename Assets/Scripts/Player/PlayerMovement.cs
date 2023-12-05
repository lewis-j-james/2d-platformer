using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    private BoxCollider2D col;

    [SerializeField] private LayerMask ground;

    public float JumpPower;
    public float MoveSpeed;

    [SerializeField] private float HangTimeMax = 0;
    private float HangTime;

    [SerializeField] private float JumpBufferMax = 0;
    private float JumpBuffer;

    private bool Grounded = false;

    private float XDirection;

    private enum MovementState { idle, running, jumping, falling }
    private MovementState state = MovementState.idle;

    [SerializeField] private AudioSource jumpSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }

    private void UpdateAnimations()
    {
        state = (Mathf.Abs(XDirection) > 0 && Mathf.Abs(rb.velocity.x) > 0.1f) ? MovementState.running : MovementState.idle;
        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }
        animator.SetInteger("State", (int)state);

        sprite.flipX = XDirection == 0 ? sprite.flipX : XDirection < 0;
    }

    private void HandleJumping()
    {
        if (Grounded)
        {
            HangTime = HangTimeMax;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            JumpBuffer = JumpBufferMax;
            // JUMP!
        }

        if (JumpBuffer > 0f && HangTime > 0f)
        {
            JumpBuffer = 0f;
            HangTime = 0f;
            rb.velocity = new Vector2(rb.velocity.x, JumpPower);

            jumpSound.Play();
        }

        JumpBuffer -= Time.deltaTime;
        HangTime -= Time.deltaTime;
    }
    
    void Update()
    {
        XDirection = Input.GetAxis("Horizontal");


        Grounded = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0, Vector2.down, 0.1f, ground);

        HandleJumping();

        UpdateAnimations();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(XDirection * MoveSpeed, rb.velocity.y);
    }
}
