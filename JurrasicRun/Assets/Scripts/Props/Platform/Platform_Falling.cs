using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Falling : MonoBehaviour
{
    [SerializeField] private float timeToEscape;
    private Animator anim;
    private BoxCollider2D bc;
    private Coroutine coroutine;
    private bool destroyed = false;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")&&!destroyed)
        {
            destroyed = true;
            coroutine = StartCoroutine(behaviour());
        }
    }

    IEnumerator behaviour()
    {
        anim.SetTrigger("touching");
        yield return new WaitForSeconds(timeToEscape);
        anim.SetTrigger("repair");
        bc.enabled = true;
        destroyed = false;
    }

    public void turnOffCollision()
    {
        bc.enabled = false;
    }
  

}
