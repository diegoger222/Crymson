using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource BGM;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void changeBGM(AudioClip music)
    {
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }
}
