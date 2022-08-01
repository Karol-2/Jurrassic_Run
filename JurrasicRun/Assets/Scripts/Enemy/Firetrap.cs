using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firetrap : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    [SerializeField] private GameObject light;
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered; 
    private bool active;

    private Health playerHealth;

    [Header("SFX")]
    [SerializeField] private AudioClip fireSound;

    private void Awake()
    {
        light.SetActive(false);
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
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

            if (!triggered)
                StartCoroutine(ActivateFiretrap());

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
        //spriteRend.color = Color.red;
        yield return new WaitForSeconds(activationDelay);
        SoundManager.instance.PlaySound(fireSound);
        //spriteRend.color = Color.white; 
        active = true;
        anim.SetBool("activated", true);

        
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
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
