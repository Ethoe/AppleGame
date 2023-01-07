using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string appleGame;
    public GameObject optionsMenu;

    void Start()
    {
        optionsMenu.SetActive(false);
    }

    public void StartGame()
    {
        Debug.Log("Starting Game");
        SceneManager.LoadScene(appleGame);
    }

    public void OpenOptions()
    {
        Debug.Log("Opened Options");
        if (optionsMenu.activeSelf)
        {
            optionsMenu.SetActive(false);
        }
        else
        {
            optionsMenu.SetActive(true);
        }
    }

    public void CloseOptions()
    {
        Debug.Log("Closed Options");
        optionsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
