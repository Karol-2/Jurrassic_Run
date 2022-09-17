using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
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
        Debug.Log(opened);
        if (opened)
            animator.SetBool("opened", true);
    }


}
