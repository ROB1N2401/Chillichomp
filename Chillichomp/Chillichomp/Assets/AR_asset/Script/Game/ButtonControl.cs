using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnPause()
    {
        Time.timeScale = 0;
    }

    public void OnResume()
    {
        Time.timeScale = 1f;
    }

    public void OnRestart()
    {
        SceneManager.LoadScene("AR_prototype");
        Time.timeScale = 1f;
    }

    public void onMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
