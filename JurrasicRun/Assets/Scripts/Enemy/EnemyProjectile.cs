using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [Header("Arrow Specifications")]
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;

    [Header("DIRECTIONS")]
    [SerializeField] private bool Left;
    [SerializeField] private bool Up;

    private float lifetime;
    private Animator anim;
    private BoxCollider2D coll;
    private bool hit;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }
    private void Update()
    {
        if(Left)
        {
            if (hit) return;
            float movementSpeed = speed * Time.deltaTime;
            transform.Translate(movementSpeed, 0, 0);

            lifetime += Time.deltaTime;
            if (lifetime > resetTime)
                gameObject.SetActive(false);
        }
        if (Up)
        {
            if (hit) return;
            float movementSpeed = speed * Time.deltaTime;
            transform.Translate(0, movementSpeed, 0);

            lifetime += Time.deltaTime;
            if (lifetime > resetTime)
                gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
       // base.OnTriggerEnter2D(collision); //Execute logic from parent script first
        coll.enabled = false;

        if (anim != null)
            anim.SetTrigger("explode"); //When the object is a fireball explode it
        else
        {
            transform.Translate(0, 0, 0);
            anim.SetTrigger("explode");
            //gameObject.SetActive(false); //When this hits any object deactivate arrow
        }
            
    }
    private void Deactivate()
    {
        anim.SetTrigger("backToNormal");
        gameObject.SetActive(false);
    }
}
