using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOnLever : MonoBehaviour
{
    [SerializeField] private GameObject activator;
    private Animator animator;
    private bool opened;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        opened = activator.GetComponent<Lever>().activated;
        Debug.Log("fire stopped");
        if (opened)
        {
            animator.SetBool("activated", true);
            gameObject.GetComponent<Firetrap>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<AudioSource>().enabled = false;
        }
           
    }
}
