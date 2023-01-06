using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void MainMenu()
    {
        Debug.Log("Going To Main Menu");
        SceneManager.LoadScene("MainMenu");
    }
    public void StartGame()
    {
        Debug.Log("Restarting Game");
    }

    public void StartGameSameSeed()
    {
        Debug.Log("Restarting Game With Same Seed");
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
