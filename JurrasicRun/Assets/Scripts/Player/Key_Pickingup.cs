using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Pickingup : MonoBehaviour
{
    [SerializeField] private AudioClip keySound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SoundManager.instance.PlaySound(keySound);
            collision.gameObject.GetComponent<GrabController>().hasKey = true;
            gameObject.GetComponent<Animator>().SetTrigger("Taken");
            //Destroy(gameObject);
        }
    }
    public void Disappear()
    {
        Destroy(gameObject);
    }
}
