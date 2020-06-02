﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Tutorial()
    {
        SceneManager.LoadScene("AR_tutorial");
        Time.timeScale = 1f;
    }
    public void PlayGame ()
    {
        SceneManager.LoadScene("AR_prototype");
        Time.timeScale = 1f;
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
