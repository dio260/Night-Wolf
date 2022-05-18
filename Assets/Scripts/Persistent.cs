using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistent : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameObject obj;
    void Awake()
    {
        if(obj != null)
        {
            Debug.Log("Exists");
            Object.Destroy(gameObject);
        }
        else
        {
            Debug.Log("persistent");
            obj = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
