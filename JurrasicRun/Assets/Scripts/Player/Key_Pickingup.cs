using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Pickingup : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<GrabController>().hasKey = true;
            // animation of dissapearing
            Destroy(gameObject);        
        }
    }
}
