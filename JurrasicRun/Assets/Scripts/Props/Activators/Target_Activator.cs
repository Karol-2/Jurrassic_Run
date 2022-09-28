using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Activator : MonoBehaviour
{
    public bool activated = false;
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            anim.SetTrigger("activated");
            activated = true;
            Debug.Log(activated);
        }
    }
}
