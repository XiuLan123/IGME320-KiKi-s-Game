using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject startingUI;
    public GameObject gameplayUI;
    public GameObject winScreenUI;
    public GameObject lossScreenUI;
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
                lossScreenUI.SetActive(true);
                gameplayObjects.SetActive(false);
                StartCoroutine(WaitForPress());
                yield break;
            }
            yield return null;
        }

        gameplayObjects.SetActive(false);
        gameplayUI.SetActive(false);
        winScreenUI.SetActive(true);
        StartCoroutine(WaitForPress());
    }

    IEnumerator WaitForPress()
    {
        while (!Input.anyKeyDown)
        {
            yield return null;
        }
        ExitToMain();
    }

    public void ExitToMain()
    {
        SceneManager.LoadScene(1);//0 or whatever the title scene index is
    }
}
