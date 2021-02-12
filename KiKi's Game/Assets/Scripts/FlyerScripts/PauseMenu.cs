using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    public Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            manager.isPaused = true;
            pauseScreen.SetActive(true);
        }
    }

    void UnpauseButton()
    {
        manager.isPaused = false;
        pauseScreen.SetActive(false);
    }
}
