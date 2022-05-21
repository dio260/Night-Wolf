using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            BackgroundMusic.instance.SwapMusic();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player 1")
            LevelLoader.instance.LoadNextLevel();
    }
}
