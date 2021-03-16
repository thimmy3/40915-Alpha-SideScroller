using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Main Level";
    public SceneFader sceneFader;

    public void PlayGame ()
    {
        sceneFader.FadeTo(levelToLoad);

    }

    public void PlayGameAgain()
    {
        sceneFader.FadeTo(levelToLoad);
    }


    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
