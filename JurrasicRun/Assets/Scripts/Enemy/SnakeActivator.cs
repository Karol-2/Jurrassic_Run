using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeActivator : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private GameObject mainSnake;

    private void Awake()
    {
        boxCollider = this.GetComponent<BoxCollider2D>();
        mainSnake = this.transform.parent.gameObject.transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            mainSnake.GetComponent<Snake>().isActivated = true;
            Debug.Log("SNAKE IS RELEASED!");
            gameObject.SetActive(false);
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(boxCollider.bounds.center ,new Vector3(2,4,1));

    //}
}
