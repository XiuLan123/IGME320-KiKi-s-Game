﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject startingUI;
    public GameObject gameplayUI;
    public GameObject winScreenUI;
    public GameObject lossScreenUI;
    public GameObject button;
    public GameObject gameplayObjects;

    public static bool packageDropped;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Starting());
        packageDropped = false;
    }

    //displays gameplay UI after the opening animation
    IEnumerator Starting()
    {
        yield return new WaitForSeconds(3);
        startingUI.SetActive(false);
        gameplayUI.SetActive(true);
        gameplayObjects.SetActive(true);
        StartCoroutine(GameLoop());
    }

    //displays end screen UI after time runs out
    IEnumerator GameLoop()
    {
        while (Timer.TimeLeft > 0)
        {
            if (packageDropped)
            {
                gameplayUI.SetActive(false);
                button.SetActive(true);
                lossScreenUI.SetActive(true);
                gameplayObjects.SetActive(false);
                yield break;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ExitToMain();
            }
            yield return null;
        }

        gameplayObjects.SetActive(false);
        gameplayUI.SetActive(false);
        winScreenUI.SetActive(true);
        button.SetActive(true);
    }

    public void ExitToMain()
    {
        SceneManager.LoadScene(0);//0 or whatever the title scene index is
    }
}