using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //external references
    public Transform player;
    private Animator anim;
    public int speed;
    public bool pivot;

    //pivot
    [Header("Pivot Options")]
    public float rotateDelay;
    public Vector3[] rotateAngles;
    int rotationIndex;
    float timer;

    //patrol
    [Header("Patrol Options")]
    private NavMeshAgent agent;
    private bool isChasing = false;

    //array of positions that the enemy travels to
    public Transform[] waypoints;
    int waypointIndex;
    private float distance;

    private void Start()
    {
        
        
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if(!pivot)
        {
            waypointIndex = 0;
            transform.LookAt(waypoints[waypointIndex].position);
            agent.destination = waypoints[waypointIndex].position;
        }
        else
            anim.SetTrigger("Idle");

        //
    }

    private void Update()
    {
        //Debug.Log(transform.localEulerAngles.y);
        if(isChasing)
        {
            agent.destination = player.position;
            return;
        }
        
        if(!pivot)
        {
            distance = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
            //Debug.Log(distance);
            if(distance < 0.6f)
            {
                //Debug.Log("next point");
                IncreaseIndex();
            }
            Patrol();
        }
        else
        {

            if(timer > rotateDelay)
            {
                // Debug.Log("Rotating");
                StartCoroutine(Pivot());
                timer = 0;
            }
            else
                timer += Time.deltaTime;
            
            // if(Vector3.Distance(transform.localRotation.eulerAngles, rotateAngles[rotationIndex]) < 1f)
            // {

            // }
        }
        
        

        
    }

    public void Patrol()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
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
        
        if(collider.gameObject.tag == "Player 1")
        {
            isChasing = true;
        }
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        isChasing = false;
        Patrol();
    }
    */

    IEnumerator Pivot()
    {
        // Debug.Log(Mathf.Abs(transform.localRotation.eulerAngles.y - rotateAngles[rotationIndex].y));
        while(Mathf.Abs(transform.localRotation.eulerAngles.y - rotateAngles[rotationIndex].y) > 1f)
        {
            if(transform.localEulerAngles.y > rotateAngles[rotationIndex].y)
                transform.Rotate(new Vector3(0, -0.1f, 0), Space.Self);
            else
                transform.Rotate(new Vector3(0, 0.1f, 0), Space.Self);
        }

        rotationIndex = (rotationIndex + 1) % rotateAngles.Length;
        // Debug.Log(rotationIndex);

        timer = 0;
        yield return null;
    }

}
