using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame ()
   {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void LaunchTutorial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("AR_tutorial");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
