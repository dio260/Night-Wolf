using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private UnityEngine.AI.NavMeshAgent agent;

    public Transform player;

    //array of positions that the enemy travels to
    public Transform[] waypoints;
    int waypointIndex;

    //allows you to know what you are colliding with
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;

    //will be uncommented when there is a model to use with animation
    //private Animation anim;

    //Patroling 
    public Vector3 target;
    bool walkPointSet;
    public float walkPointRange;

    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //states
    public float sightRange;
    public float attackRange;

    public bool playerInSightRange;
    public bool playerInAttackRange;

    private void Update()
    {

        //check that the player is in sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //makes the enemy patrol
        if (Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
        
        //if statements used to go between states
        if(playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }

        if(playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();
        }



    }

    

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {

    }

    void Start()
    {

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        UpdateDestination();

        //will be uncommented when there is a model to use with animation
        //anim = gameObject.GetComponent<Animation>();

    }


    void UpdateDestination()
    {

        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);

    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if(waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

}
