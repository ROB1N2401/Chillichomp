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
    private bool _end;

    private float _timer;

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
        _timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_chew)
        {
            //_souce.Stop();
            _souce.PlayOneShot(Chewing, 1f);
            _chew = false;
        }
        if(_frenzy && _timer>=9f)
        {
            //_souce.Stop();
            _souce.PlayOneShot(Fire, 1f);
            _frenzy = false;
            _timer = 0;
        }
        if (_drink)
        {
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

}
