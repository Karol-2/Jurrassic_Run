using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimann : MonoBehaviour
{
    [Header("Idle Time")]
    [SerializeField] private float speedIdle = 30f;
    [SerializeField] private float waitTime = 2f;

    [Header("Chase")]
    [SerializeField] private float speedChase = 50f;
    [SerializeField] private float speedJump = 5f;
    [SerializeField] private float waitTimeChase = 1f;


    private Coroutine slimeStatus;
    private Rigidbody2D body;
    private CircleCollider2D CircleCollider2D;
    private TakingDamage takingDmg;
    private bool chasing = false;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        CircleCollider2D = GetComponent<CircleCollider2D>();
        takingDmg = GetComponent<TakingDamage>();
    }

    private void Start()
    {
        slimeStatus = StartCoroutine(Idle());
        takingDmg.enabled = false;
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
            Debug.Log("in range");
            chasing = true;

            StopCoroutine(Idle());
            CircleCollider2D.enabled = false;
            takingDmg.enabled = true;
            slimeStatus = StartCoroutine(Agro(collision.transform));



        }
        else if (transform.position.y == collision.transform.position.y)
        {
            Debug.Log("sometinh else in range");
            int direction  = (this.transform.position.x > collision.transform.position.x) ? 1 : -1;
            body.velocity = new Vector2(speedIdle * direction, speedJump);
        }
        else
            Debug.Log("nothing");
    }

    IEnumerator Agro(Transform player)
    {
        while (true)
        {
            int direction = (this.transform.position.x < player.position.x) ? 1 : -1;

            //jump
            body.velocity = (new Vector2(speedChase * direction, speedJump));

            yield return new WaitForSeconds(waitTimeChase);
        }
    }



}
