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
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void onMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
