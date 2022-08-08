using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg_Bomb : MonoBehaviour
{
    [SerializeField] private AudioClip hitsound;
    [SerializeField] protected float damage;

    public bool drop = false;

    private SpriteRenderer sprite;
    private bool onGround = false;


    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    private void Update()
    {
        if(drop)
        {
            sprite.enabled = true;
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            SoundManager.instance.PlaySound(hitsound);
            var parentGameObject = this.transform.parent.gameObject;
            drop = false;
            sprite.enabled = false;
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            gameObject.transform.position = parentGameObject.GetComponent<Transform>().position;
            
        }
        else if(collision.CompareTag("Player"))
            {
                
                SoundManager.instance.PlaySound(hitsound);
                collision.GetComponent<Health>().TakeDamage(damage);

            }
        
    }
    
}
