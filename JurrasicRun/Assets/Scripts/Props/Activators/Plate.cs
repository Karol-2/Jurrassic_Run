using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public bool activated = false;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Ground")
        {
            Debug.Log("touch");
            animator.SetBool("active", true);
            activated = true;
        }
        else
        {
            activated = false;
        }
    }

    
}
