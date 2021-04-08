using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBGM : SingletonMonoBehavior<BackgroundBGM>
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        audioSource.Play();
    }
    public void Stop()
    {
        audioSource.Stop();
    }
}
