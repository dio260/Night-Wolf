using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.AI;

public class InCheck : MonoBehaviour {

    private Text text;

    private Transform enemy;
    private Transform player;

    void Awake()
    {
        //text = GameObject.Find("Text").GetComponent<Text>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        //agent.destination = player.position;
    }

    void OnTriggerExit(Collider other)
    {
        //Patrol();
    }
}
