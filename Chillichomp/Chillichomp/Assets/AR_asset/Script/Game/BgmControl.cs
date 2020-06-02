using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmControl : MonoBehaviour
{
    private AudioSource _souce1;
    private AudioSource _souce2;
    public AudioClip _button;
    private void Start()
    {
        _souce1 = this.GetComponent<AudioSource>();
        _souce2 = GameObject.Find("Audio Source").GetComponent<AudioSource>();
    }
    public void Stop()
    {
        _souce1.Pause();
        _souce2.Pause();
    }

    public void Resume()
    {
        _souce1.Play();
        _souce2.Play();
    }

    public void ClickButton()
    {
        _souce1.PlayOneShot(_button, 1f);
    }
}
