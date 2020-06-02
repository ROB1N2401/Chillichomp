using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class VolumeControl : MonoBehaviour
{
    public AudioSource BGM;
    public AudioSource SFX;

    public Slider MasterSlider;
    public Slider BgmSlider;
    public Slider SfxSlider;

    private void Start()
    {
        if(MasterSlider==null)
        {
            BGM.volume = PlayerPrefs.GetFloat("Master");
            SFX.volume = PlayerPrefs.GetFloat("Master");
            BGM.volume = PlayerPrefs.GetFloat("Bgm");
            SFX.volume = PlayerPrefs.GetFloat("Sfx");
        }
    }
    private void Update()
    {
        PlayerPrefs.SetFloat("Master",MasterSlider.value);
        PlayerPrefs.SetFloat("Bgm", BgmSlider.value);
        PlayerPrefs.SetFloat("Sfx", SfxSlider.value);
    }

    public void Master()
    {
        BGM.volume = PlayerPrefs.GetFloat("Master");
        SFX.volume = PlayerPrefs.GetFloat("Master");
    }
    public void Bgm()
    {
        BGM.volume = PlayerPrefs.GetFloat("Bgm");
    }
    public void Sfx()
    {
        SFX.volume = PlayerPrefs.GetFloat("Sfx");
    }
}