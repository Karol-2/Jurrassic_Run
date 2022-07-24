using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AzooMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [Header("Dashing")]
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;
    

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime; //ile czasu moze wisiec w powietrzu znim skoczy
    private float coyoteCounter;

    [Header("Multiple Jumps")]
    [SerializeField] private int extraJumps;
    private int jumpCounter;

    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    [Header("Dust particles")]
    [SerializeField]private ParticleSystem dust;

    private Rigidbody2D rb;
    private Animator anim;
    private CapsuleCollider2D collider;
    private float wallJumpCooldown;
    private float horizontalInput;
    private Vector3 startingScale;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;

    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider2D>();
        startingScale = transform.localScale;
       
    }

    private void Update()
    {
        if (isDashing)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        horizontalInput = Input.GetAxis("Horizontal");
       // Debug.Log(isGrounded());
        
        //Flip player when moving left-right
        if (horizontalInput > 0.01f)
            transform.localScale = startingScale;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-startingScale.x, startingScale.y,startingScale.z);

        //Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        //dash
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
        }




        //jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            CreateDust();
        }
        //adjustable jump height
        else if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2);

            
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

            if (isGrounded())
            {
                coyoteCounter = coyoteTime;
                jumpCounter = extraJumps;
            }
            else
                coyoteCounter -= Time.deltaTime;
        

    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.velocity = new Vector2((Input.GetAxisRaw("Horizontal")) * speed, rb.velocity.y);
    }

    private void Jump()
    {
        if (coyoteCounter < 0  && jumpCounter < 0) return;

        //SoundManager.instance.PlaySound(jumpSound);

        
        
        if (isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);

           // new WaitForSeconds(0.5f);
        }
           
        else
            {
                if (coyoteCounter > 0)
            {
                CreateDust();
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }
                 
                //else
                //{
                //    if (jumpCounter > 0)
                //    {
                //        body.velocity = new Vector2(body.velocity.x, jumpPower);
                //        jumpCounter--;
                //    }
                //}
            }

            coyoteCounter = 0; //avoiding double jumps

        
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


    private bool isGrounded()
    {
        float extraHeightText = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(collider.bounds.center, Vector2.down,
            collider.bounds.extents.y + extraHeightText,  groundLayer);
        Color rayColor;
        if (raycastHit.collider != null)
            rayColor = Color.green;
        else
            rayColor = Color.red;

        Debug.DrawRay(collider.bounds.center, Vector2.down * (collider.bounds.extents.y + extraHeightText), rayColor);
        
        
        return raycastHit.collider != null;
        
    }
    private bool onWall()
    {
        //RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        //return raycastHit.collider != null;
        return false;
    }
    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() ;
    }
    private void CreateDust()
    {
        dust.Play();
    }
}