using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Saw : MonoBehaviour
{
    public float rotateSpeed;
    public float speed;
    public Transform right;
    public Transform left;
    bool turnback;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed);
        if (transform.position.x >= right.position.x)
            turnback = true;
        if(transform.position.x <= left.position.x)
            turnback=false;
        if (turnback)
            transform.position = Vector2.MoveTowards(transform.position, left.position, speed * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, right.position, speed * Time.deltaTime);
    }
}
