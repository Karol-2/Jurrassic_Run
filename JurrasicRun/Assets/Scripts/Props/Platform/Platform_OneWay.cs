using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_OneWay : MonoBehaviour
{
    private GameObject currentPlatform;
    [SerializeField] private Collider2D playerCollider;

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            if (currentPlatform != null)
                StartCoroutine(DisableCollision());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "OneWayPlatform")
            currentPlatform = collision.gameObject;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "OneWayPlatform")
            currentPlatform = collision.gameObject;
    }

    private IEnumerator DisableCollision()
    {
        Collider2D platformCollider = currentPlatform.GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(platformCollider, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(platformCollider, platformCollider,false);

    }
}
