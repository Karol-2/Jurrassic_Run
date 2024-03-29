using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField ]private float speed = 8f;

    private bool isLadder;
    private bool isClimbing;
    private float initialGravity;
    private float vertical;

    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        initialGravity = rb.gravityScale;
    }

    private void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
            rb.gravityScale = initialGravity;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
