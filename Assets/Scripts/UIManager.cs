using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject StartUI;
    public GameObject GameUI;
    public GameObject OptionsUI;
    public GameObject PauseUI;
    public GameObject DeadUI;
    public GameObject timer;
    public void GameStart()
    {
        StartUI.SetActive(false);
        GameUI.SetActive(true);
    }

    public void ClickOptions()
    {
        OptionsUI.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void Pause()
    {   
        GameUI.SetActive(false);
        PauseUI.SetActive(true);        
    }
    public void Resume()
    {
        PauseUI.SetActive(false);
        GameUI.SetActive(true);
    }
    public void Return()
    {
        OptionsUI.SetActive(false);
    }
}
