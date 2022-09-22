using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private Rigidbody2D rb;
    private Transform target;
    public bool isActivated = false;
    private Vector2 moveDirection;
    private bool dead;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dead = GetComponent<Health>().dead;
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Update()
    {
        if(target)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;

        }
        //Debug.Log(health);
    }

    private void FixedUpdate()
    {
        if(target && isActivated && !dead)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
            //rb.velocity = new Vector2(moveDirection.x * speed,1) ;
        }
    }


}
