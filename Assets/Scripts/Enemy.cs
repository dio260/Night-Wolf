using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private UnityEngine.AI.NavMeshAgent agent;

    public Transform player;

    //array of positions that the enemy travels to
    public Transform[] waypoints;
    public int speed;

    int waypointIndex;
    private float distance;

    private void Start()
    {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, waypoints[waypointIndex].position);

        if(distance < 0.5f)
        {
            IncreaseIndex();
        }
        Patrol();
    }

    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }


}
