using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public Transform player;

    private NavMeshAgent agent;
    private Animator anim;

    private bool isChasing = false;

    //array of positions that the enemy travels to
    public Transform[] waypoints;
    public int speed;

    int waypointIndex;
    private float distance;

    private void Start()
    {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = waypoints[waypointIndex].position;

        //anim.SetTrigger("Idle");
    }

    private void Update()
    {
        
        distance = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        //Debug.Log(distance);

        if(distance < 0.6f && isChasing == false)
        {
            //Debug.Log("next point");
            IncreaseIndex();
        }

        Patrol();

        //OnTriggerEnter("ConeCollider");
        
    }

    public void Patrol()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);\
        agent.destination = waypoints[waypointIndex].position;
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

    void OnTriggerEnter(Collider collider)
    {
        isChasing = true;
        if(collider.gameObject.tag == "Player 1")
        {
            agent.destination = player.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isChasing = false;
        Patrol();
    }



}
