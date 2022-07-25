using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour
{
    [SerializeField] private AudioClip unlockSound;
    private SpriteRenderer sprite;
    private BoxCollider2D bc;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>(); ;
        bc = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<GrabController>().hasKey)
        {
            SoundManager.instance.PlaySound(unlockSound);
            collision.gameObject.GetComponent<GrabController>().hasKey = false;
            sprite.enabled = false;
            bc.enabled = false;
        }
            
    }
}
