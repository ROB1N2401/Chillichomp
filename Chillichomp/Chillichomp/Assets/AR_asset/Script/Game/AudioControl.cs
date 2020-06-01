using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    private AudioSource _souce;
    private bool _chew;
    private bool _frenzy;
    private bool _drink;
    private bool _increase;
    private bool _warn;
    private bool _finish;


    //audio resource
    public AudioClip Chewing;
    public AudioClip Fire;
    public AudioClip Water;
    public AudioClip IncreaseWarning;
    public AudioClip Warning;
    public AudioClip End;
    // Start is called before the first frame update
    void Start()
    {
        _souce = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_chew)
        {
            _souce.PlayOneShot(Chewing, 0.7f);
            _chew = false;
        }
        if(_frenzy)
        {
            _souce.Stop();
            _souce.PlayOneShot(Fire, 1f);
            _frenzy = false;
        }
        if (_drink)
        {
            _souce.Stop();
            _souce.PlayOneShot(Water, 1f);
            _drink = false;
        }
        if(_increase)
        {
            _souce.PlayOneShot(IncreaseWarning, 1f);
            _increase = false;
        }
        if (_warn)
        {
            _souce.PlayOneShot(Warning, 1f);
            _warn = false;
        }
        if(_finish)
        {
            _souce.Stop();
            _souce.PlayOneShot(End, 1f);
            _finish = false;
        }
    }


    public void EatFood()
    {
        _chew = true;
    }
    public void HitRoof()
    {
        _frenzy = true;
    }
    public void DrinkWater()
    {
        _drink = true;
    }
    public void IncreaseScore()
    {
        _increase = true;
    }
    public void Warn()
    {
        _warn = true;
    }
    public void Final()
    {
        _finish = true;
    }
}
