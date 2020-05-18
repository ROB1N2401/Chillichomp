using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmControl : MonoBehaviour
{
    private AudioSource _souce;
    private void Start()
    {
        _souce = this.GetComponent<AudioSource>();
    }
    public void Stop()
    {
        _souce.Pause();
    }

    public void Resume()
    {
        _souce.Play();
    }
}
