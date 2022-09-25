using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject magic;
    public bool activated = false;
    private bool touching = false;
    private Animator animator;
    private GameObject ps;
    private AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        ps = GameObject.Find("Glitter");
        audioSource = gameObject.GetComponent<AudioSource>();
        ps.SetActive(false);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            touching = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touching = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& touching)
        {
            animator.SetTrigger("change");
            activated = !activated;

            audioSource.Play();
            
            //Debug.Log(activated);
            ps.SetActive(true);
        }
    }
}
