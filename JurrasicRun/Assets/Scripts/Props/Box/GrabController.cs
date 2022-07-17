using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
   [SerializeField] private Transform grabDetect;
   [SerializeField] private Transform boxHolder;
   [SerializeField] private float rayDistance;
    private bool isHolding = false;


    void Update()
    {
        Debug.Log(isHolding);
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position,
            transform.localScale, rayDistance);

        if(grabCheck.collider != null && grabCheck.collider.tag == "Box")
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isHolding = true;
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            {
                isHolding = false;
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

            }
        }
    }
}
