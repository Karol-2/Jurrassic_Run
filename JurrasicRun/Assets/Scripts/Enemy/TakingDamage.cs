using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingDamage : MonoBehaviour
{
    [SerializeField] protected float damage;
    //[SerializeField] private AudioClip waterSound;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
           // if (gameObject.name == "Water")
                //SoundManager.instance.PlaySound(waterSound);
            collision.GetComponent<Health>().TakeDamage(damage);

        }

    }
}
