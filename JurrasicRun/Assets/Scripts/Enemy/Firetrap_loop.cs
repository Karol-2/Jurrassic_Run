using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firetrap_loop : MonoBehaviour
{

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    [SerializeField] private float waitTime;
    [SerializeField] private float damage;
    [SerializeField] private GameObject light;
    private Animator anim;
    private SpriteRenderer spriteRend;
    private AudioSource audioSource;

    private bool triggered;
    private bool active;

    private Health playerHealth;



    public void LightOn()
    {
        light.SetActive(true);
    }
    public void LightOff()
    {
        light.SetActive(false);
    }

    private void Awake()
    {
        light.SetActive(false);
        audioSource=GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        StartCoroutine(ActivateFiretrap());

    }

    private void Update()
    {
        if (playerHealth != null && active)
            playerHealth.TakeDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = collision.GetComponent<Health>();

            if (active)
                collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            playerHealth = null;
    }
    
    private IEnumerator ActivateFiretrap()
    {

        triggered = true;
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(activationDelay);
        audioSource.Play();
        spriteRend.color = Color.white; 
        active = true;
        anim.SetBool("activated", true);


        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(ActivateFiretrap());
    }
}
