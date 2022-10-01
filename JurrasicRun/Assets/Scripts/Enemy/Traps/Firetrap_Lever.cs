using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firetrap_Lever : MonoBehaviour
{

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;

    [Header("Parameters")]
    public float damage;

    [Header("Components")]
    [SerializeField] private GameObject light;

    private Animator anim;
    private SpriteRenderer spriteRend;
    private AudioSource audioSource;
    private Health playerHealth;

    private bool triggered;
    private bool active = true;


    private void Awake()
    {
        light.SetActive(false);
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        spriteRend = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = collision.GetComponent<Health>();

            playerHealth.TakeDamage(damage);
        }
    }


    public void LightOn()
    {
        light.SetActive(true);
    }
    public void LightOff()
    {
        light.SetActive(false);
    }
}
