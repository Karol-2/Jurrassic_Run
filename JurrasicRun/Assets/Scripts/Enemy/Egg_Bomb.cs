using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg_Bomb : MonoBehaviour
{

    private SpriteRenderer sprite;
    public bool drop = false;
    


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
            var parentGameObject = this.transform.parent.gameObject;
            drop = false;
            sprite.enabled = false;
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            gameObject.transform.position = parentGameObject.GetComponent<Transform>().position;
            
        }
        
    }
    
}
