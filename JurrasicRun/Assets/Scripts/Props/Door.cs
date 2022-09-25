using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private GameObject activator;
    private Animator animator;
    private AudioSource audioSource;
    private bool opened;
    private bool soundPlayed = false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    private void Update()
    {
        opened = activator.GetComponent<Lever>().activated;
        //Debug.Log(opened);
        if (opened&& !soundPlayed)
        {
            animator.SetBool("opened", true);
            audioSource.Play();
            soundPlayed = true;
        }
            
    }


}
