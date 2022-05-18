using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMusicSwitcher : MonoBehaviour
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

        if(Input.GetKeyDown(KeyCode.S))
            LevelLoader.instance.LoadNextLevel();
    }
}
