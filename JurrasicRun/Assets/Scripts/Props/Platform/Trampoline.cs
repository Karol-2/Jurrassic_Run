using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private AudioClip bounceSound;
    [SerializeField]private float bounce = 20f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SoundManager.instance.PlaySound(bounceSound);
            collision.gameObject.GetComponent<Rigidbody2D>()
                .AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }
}
