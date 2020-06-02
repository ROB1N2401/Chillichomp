using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class MenuControls : MonoBehaviour
{
    public Slider masterSlider;
    public Slider BGMSlider;
    public Slider SFXSlider;
    public AudioMixer audioMixer;

    [Space(5)]
    public GameObject optionsPanel;
    public GameObject creditsPanel;

    public void Awake()
    {
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }


    public void SwitchToGameScene() {
        PlayerPrefs.SetFloat("Master", LinearToDecibel(masterSlider.value));
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
    }

    public void Options()
    {
        optionsPanel.SetActive(true);
    }

    public void MainMenu()
    {
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void LateUpdate()
    {
        audioMixer.SetFloat("Master", LinearToDecibel(masterSlider.value));
        //audioMixer.SetFloat("Master", PlayerPrefs.GetFloat("Master"));
        audioMixer.SetFloat("SFX", LinearToDecibel(SFXSlider.value));
        audioMixer.SetFloat("BGM", LinearToDecibel(BGMSlider.value));
    }

    private float LinearToDecibel(float linear)
    {
        float dB;
        if (linear != 0)
            dB = 20.0f * Mathf.Log10(linear);
        else
            dB = -144.0f;
        return dB;
    }

    private float DecibelToLinear(float dB)
    {
        float linear = Mathf.Pow(10.0f, dB / 20.0f);
        return linear;
    }
}
