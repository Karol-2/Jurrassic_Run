using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool activated = false;
    private bool touching = false;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            touching = true;
        }
        else
            touching = false;
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& touching)
        {
            animator.SetTrigger("change");
            activated = !activated;

            Debug.Log(activated);
        }
    }
}
