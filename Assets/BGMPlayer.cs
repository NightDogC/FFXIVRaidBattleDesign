using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    public AudioSource BGM;

    void Start()
    {
        BGM.Stop();
    }
    public void PlayAndPause()
    {
        if (BGM.isPlaying==true)
        {
            BGM.Pause();
        }
        else
        {
            BGM.Play();
        }
    }
}
