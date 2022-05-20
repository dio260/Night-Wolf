using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeOut : MonoBehaviour
{
    private bool CanTakeOut = false;
    private GameObject DestroyTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && CanTakeOut == true)
        {
            Destroy(DestroyTarget);
            CanTakeOut = false;
            DestroyTarget = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "TakeOutCollider")
        {
            CanTakeOut = true;
            DestroyTarget = other.transform.parent.gameObject;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "TakeOutCollider")
        {
            CanTakeOut = false;
            DestroyTarget = null;
        }
    }
}
