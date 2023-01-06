using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string appleGame;
    public void StartGame()
    {
        Debug.Log("Starting Game");
        SceneManager.LoadScene(appleGame);
    }

    public void OpenOptions()
    {
        Debug.Log("Opened Options");
    }

    public void CloseOptions()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
