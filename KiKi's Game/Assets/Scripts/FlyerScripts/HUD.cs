using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject start;
    public Manager manager;
    public bool play;

    // Start is called before the first frame update
    void Start()
    {
        start.SetActive(true);
        manager.isPaused = true;
        play = false;
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(!play)
        {
            CheckPlay();
        }
        if(manager.kiki.health == 2)
        {
            heart3.SetActive(false);
        }
        if(manager.kiki.health == 1)
        {
            heart2.SetActive(false);
        }
        if(manager.kiki.health <= 0)
        {
            heart1.SetActive(false);
        }

        //if(manager.gameoverScreen.activeSelf && Input.anyKeyDown)
        //{
        //    SceneManager.LoadScene(0);
        //}
    }


    /// <summary>
    /// Checks if the player has started the game
    /// </summary>
    public void CheckPlay()
    {
        if (Input.anyKeyDown)
        {
            start.SetActive(false);
            play = true;
            manager.isPaused = false;
        }
    }
}
