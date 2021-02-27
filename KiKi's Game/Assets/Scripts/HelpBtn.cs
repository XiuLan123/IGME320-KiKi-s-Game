using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpBtn : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gigiSleep;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeSelf)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Unpause();
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        gigiSleep.SetActive(false);
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        pauseMenu.SetActive(false);
        gigiSleep.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ExitToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
