using System.Collections;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 14f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;


    private Animator _animator;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 180f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 10f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;
    
    private object invoke;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    void Update()
    {

        _animator.SetBool("IsInAir", !IsGrounded());
        _animator.SetBool("IsWalking", Input.GetAxis("Horizontal") != 0);


        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        
        if (isDashing)
        {
            return;
        }
        
        horizontal = Input.GetAxisRaw("Horizontal");

        if (coyoteTimeCounter >0f && Input.GetButton("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash || Input.GetKeyDown(KeyCode.Mouse1) && canDash)
        {
            StartCoroutine(Dash());
        }

        Flip();
    }

    public void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        if (KBCounter <= 0) 
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        else
        {
            if(KnockFromRight == true )
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }
            if(KnockFromRight == false )
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }

            KBCounter -= Time.deltaTime;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}