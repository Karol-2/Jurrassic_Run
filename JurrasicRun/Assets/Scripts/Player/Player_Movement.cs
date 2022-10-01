using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Player_Movement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    [SerializeField] private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;
    private float horizontal;
    private bool isFacingRight = true;
    private bool isJumping;
 

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;


    [Header("Dashing")]
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;
    private bool canDash = true;
    private bool isDashing;


    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;
    public Pause_Menu pause;


    [Header("Dust particles")]
    [SerializeField] private ParticleSystem dust;


    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip dashSound;


    private Rigidbody2D rb;
    private Animator anim;
    private TrailRenderer tr;
    private Collider2D collider;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        tr = GetComponent<TrailRenderer>();

    }


    private void Update()
    {
        
        if (isDashing)
            return;

        if (isGrounded())
            coyoteTimeCounter = coyoteTime;
        else
            coyoteTimeCounter -= Time.deltaTime;


        //Reseting Scene
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        horizontal = Input.GetAxisRaw("Horizontal");

        anim.SetBool("run", horizontal != 0);
        anim.SetBool("grounded", isGrounded());


        //jumping
        if (Input.GetKeyDown(KeyCode.Space))
            jumpBufferCounter = jumpBufferTime;
        else
            jumpBufferCounter -= Time.deltaTime;


        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            SoundManager.instance.PlaySound(jumpSound);
            CreateDust();
            jumpBufferCounter = 0f;

            StartCoroutine(JumpCooldown());
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            CreateDust();
            coyoteTimeCounter = 0f;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        Flip();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    //private bool isGrounded()
    //{
    //    return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    //}

    private bool isGrounded()
    {
        float extraHeightText = 0.25f;
        RaycastHit2D raycastHit = Physics2D.Raycast(collider.bounds.center, Vector2.down,
            collider.bounds.extents.y + extraHeightText, groundLayer);
        Color rayColor;
        if (raycastHit.collider != null)
            rayColor = Color.green;
        else
            rayColor = Color.red;

        Debug.DrawRay(collider.bounds.center, Vector2.down * (collider.bounds.extents.y + extraHeightText), rayColor);


        return raycastHit.collider != null;

    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public bool canAttack()
    {
        //return horizontal == 0 && isGrounded()&& !pause.GamePaused;
        return horizontal == 0 &&!pause.GamePaused;
    }

    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        SoundManager.instance.PlaySound(dashSound);
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

    private void CreateDust()
    {
        dust.Play();
    }


}

