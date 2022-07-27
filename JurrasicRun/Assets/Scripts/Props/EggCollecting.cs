using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCollecting : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickupSound);
            collision.GetComponent<Eggs>().Collected();
            gameObject.SetActive(false);
        }
    }
}
