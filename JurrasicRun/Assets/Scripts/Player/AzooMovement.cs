using UnityEngine;

public class AzooMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime; //ile czasu moze wisiec w powietrzu znim skoczy
    private float coyoteCounter;

    [Header("Multiple Jumps")]
    [SerializeField] private int extraJumps;
    private int jumpCounter;

    [Header("Wall jumping")]
    [SerializeField] private float wallJumpX; // horizontal wall jump force
    [SerializeField] private float wallJumpY; //vertical wall jump force



    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;


    private Rigidbody2D body;
    private Animator anim;
    private CapsuleCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;
    private Vector3 startingScale; 

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;

    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<CapsuleCollider2D>();
        startingScale = transform.localScale;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        
        //Flip player when moving left-right
        if (horizontalInput > 0.01f)
            transform.localScale = startingScale;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-startingScale.x, startingScale.y,startingScale.z);

        //Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        //jump
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        //adjustable jump height
        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);

        if (onWall())
        {
            body.gravityScale = 0; // teraz postac nie zjezdza ze sciany
            body.velocity = Vector2.zero;
        }
        else
        {
            body.gravityScale = 7;
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (isGrounded())
            {
                coyoteCounter = coyoteTime;
                jumpCounter = extraJumps;
            }
            else
                coyoteCounter -= Time.deltaTime;
        }

    }

    private void Jump()
    {
        if (coyoteCounter < 0 && !onWall() && jumpCounter <= 0) return;

        //SoundManager.instance.PlaySound(jumpSound);

        
        
        if (isGrounded())
            body.velocity = new Vector2(body.velocity.x, jumpPower);
        else
            {
                if (coyoteCounter > 0)
                    body.velocity = new Vector2(body.velocity.x, jumpPower);
                else
                {
                    if (jumpCounter > 0)
                    {
                        body.velocity = new Vector2(body.velocity.x, jumpPower);
                        jumpCounter--;
                    }
                }
            }

            coyoteCounter = 0; //avoiding double jumps

        
    }




    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
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
        return horizontalInput == 0 && isGrounded() && !onWall();
    }
}