using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeHive : MonoBehaviour
{
    [SerializeField] private ParticleSystem bees;

    private bool activated = false;
   

    private void Start()
    {
        var em = bees.emission;
       //ees = GetComponent<ParticleSystem>();
        em.rateOverTime = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var em = bees.emission;
        if(collision.CompareTag("Player")&& activated == false)
        {
            Debug.Log("FF");
            activated = true;
            em.rateOverTime = 10f;
            PlayBees();
        }
    }
    private void PlayBees()
    {
        bees.Play();
    }
}
