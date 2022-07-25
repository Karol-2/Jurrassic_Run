using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private AudioClip fireballSound;
    [Header("Fire particles")]
    [SerializeField] private ParticleSystem fire;

    private Animator anim;
    private Player_Movement playerMovement;
    private GrabController grabController;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {

        anim = GetComponent<Animator>();
        playerMovement = GetComponent<Player_Movement>();
        grabController = GetComponent<GrabController>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) 
            && cooldownTimer > attackCooldown 
            && playerMovement.canAttack() 
            && grabController.isHolding == false)
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        CreateFire();
        //SoundManager.instance.PlaySound(fireballSound);
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        
        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
    private void CreateFire()
    {
        fire.Play();
    }
        
        
}
