using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimann : MonoBehaviour
{
    [Header("Idle Time")]
    [SerializeField] private float speedIdle = 30f;
    [SerializeField] private float waitTime = 2f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Chase")]
    [SerializeField] private float speedChase = 50f;
    [SerializeField] private float speedJump = 5f;
    [SerializeField] private float waitTimeChase = 1f;
    [SerializeField] private float damage;


    private Coroutine slimeStatus;
    private Rigidbody2D body;
    private CircleCollider2D CircleCollider2D;
    private BoxCollider2D bc;
    private TakingDamage takingDmg;
    private Animator anim;
    private bool chasing = false;
    private bool onTheGround;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        CircleCollider2D = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        slimeStatus = StartCoroutine(Idle());
    }

    IEnumerator Idle()
    {
        int direction = 1;
        while (true)
        {
            body.velocity = new Vector2(speedIdle * direction, 0);

            direction *= -1;

            yield return new WaitForSeconds(waitTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("in range");
            chasing = true;


            StopCoroutine(Idle());
            CircleCollider2D.enabled = false;

            slimeStatus = StartCoroutine(Agro(collision.transform));

        }
        else if (transform.position.y == collision.transform.position.y)
        {
            //Debug.Log("sometinh else in range");
            int direction  = (this.transform.position.x > collision.transform.position.x) ? 1 : -1;
            body.velocity = new Vector2(speedIdle * direction, speedJump);
        }
    }

    IEnumerator Agro(Transform player)
    {
        yield return new WaitForSeconds(1);
        takingDmg = gameObject.AddComponent<TakingDamage>();
        takingDmg.damage = damage;

        while (onTheGround == true)
        {
            

            int direction = (this.transform.position.x < player.position.x) ? 1 : -1;

            //jump
            body.velocity = (new Vector2(speedChase * direction, speedJump));
            anim.SetTrigger("jump");

            yield return new WaitForSeconds(waitTimeChase);
        }
    }

    private bool isGrounded()
    {
        float extraHeightText = 0.5f;
        RaycastHit2D raycastHit = Physics2D.Raycast(bc.bounds.center, Vector2.down,
            bc.bounds.extents.y + extraHeightText, groundLayer);
        Color rayColor;
        if (raycastHit.collider != null)
            rayColor = Color.green;
        else
            rayColor = Color.red;

        Debug.DrawRay(bc.bounds.center, Vector2.down * (bc.bounds.extents.y + extraHeightText), rayColor);


        return raycastHit.collider != null;

    }

    private void Update()
    {
        onTheGround = isGrounded();
    }

    public void death()
    {
        Destroy(gameObject);
    }


}
