using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Activator object")]
    [SerializeField] private GameObject activator;

    [Header("Type of activator (ONLY ONE)")]
    [SerializeField] private bool lever;
    [SerializeField] private bool target;
    [SerializeField] private bool plate;

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
        if (lever)
            opened = activator.GetComponent<Lever>().activated;
        else if (target)
            opened = activator.GetComponent<Target_Activator>().activated;
        else if (plate)
            Debug.Log("plate");

        //Debug.Log(opened);
        if (opened&& !soundPlayed)
        {
            animator.SetBool("opened", true);
            audioSource.Play();
            soundPlayed = true;
        }
            
    }


}
