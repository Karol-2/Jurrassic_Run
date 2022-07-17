using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Falling : MonoBehaviour
{
    [SerializeField] private float timeToEscape;
    private Rigidbody2D rbody;
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("DropPlatform", 0.5f);
            Destroy(gameObject, timeToEscape);
        }
    }

    private void DropPlatform()
    {
        rbody.isKinematic = false;
    }


}
