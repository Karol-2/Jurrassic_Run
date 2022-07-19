using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeFollower : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private GameObject[] waypoints;
    private int currentIndexOfWaypoint = 0;



    [Header("Movement parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;


    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;



    private void Update()
    {
        transform.Rotate(0, 0, rotateSpeed);
        //Debug.Log(currentIndexOfWaypoint);
        if (Vector2.Distance(waypoints[currentIndexOfWaypoint].transform.position,
            transform.position)< 0.1f)
        {
            currentIndexOfWaypoint++;
            if(currentIndexOfWaypoint >= waypoints.Length)
                currentIndexOfWaypoint = 0;
        }
        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[currentIndexOfWaypoint].transform.position, Time.deltaTime * speed);
    }
}
