using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame ()
   {
        SceneManager.LoadScene("PrototypeScene");
   }

    //public void StartCredits()
    //{
    //    SceneManager.LoadScene("CreditsScene");
    //}

    public void QuitGame ()
    {
        Application.Quit();
    }
}
