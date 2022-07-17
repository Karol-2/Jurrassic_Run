using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_OneWayCollision : MonoBehaviour
{
    private Collider2D _collider;
    private bool _playerOnPlatform;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.S))
        {
            Physics2D.IgnoreCollision(
                collision.gameObject.GetComponent<Collider2D>(),
                GetComponent<Collider2D>() );
        }
    }
}
