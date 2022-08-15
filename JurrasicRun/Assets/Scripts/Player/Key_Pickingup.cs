using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Pickingup : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] private AudioClip keySound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SoundManager.instance.PlaySound(keySound);
            collision.gameObject.GetComponent<GrabController>().hasKey = true;
            gameObject.GetComponent<Animator>().SetTrigger("Taken");
        }
    }
    public void Disappear()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
