using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Falling : MonoBehaviour
{
    [SerializeField] private float timeToEscape;
    private Rigidbody2D rbody;
    private Animator anim;

    void Start()
    {
       
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("touching");
           // Invoke("DropPlatform", 0.2f);
            Destroy(gameObject, timeToEscape);
        }
    }

    private void DropPlatform()
    {
        rbody.isKinematic = false;
    }


}
