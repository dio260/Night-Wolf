using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    AudioSource player;
    [SerializeField]
    private AudioClip normal;
    [SerializeField]
    private AudioClip chase;
    public static BackgroundMusic instance;
    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<AudioSource>();
        //player.clip = normal;
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    public void SwapMusic()
    {
        player.Stop();
        if(player.clip == normal)
        {
            player.clip = chase;
        }
        else
        {
            player.clip = normal;
        }
        player.Play();
    }
}
