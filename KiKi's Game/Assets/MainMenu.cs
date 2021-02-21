using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    float encounterTimer;
    [SerializeField]
    GameObject[] miniGameChoices;
    [SerializeField]
    Transform origin;

    public GameObject introMessage;
    public GameObject mainMessage;

    private void Start()
    {
        encounterTimer = Random.Range(3f,6f);
    }

    private void Update()
    {
        if (!introMessage.activeSelf)
        {
            if (encounterTimer <= 0)
            {
                EncounterMinigame(Random.Range(0, 4), RandomPosOnScreen());
                encounterTimer = Random.Range(3f, 6f);
            }
            else
            {
                encounterTimer -= Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SceneManager.LoadScene(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SceneManager.LoadScene(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SceneManager.LoadScene(3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SceneManager.LoadScene(4);
            }
        }
        else
        {
            if (Input.anyKeyDown)
            {
                introMessage.SetActive(false);
                mainMessage.SetActive(true);
            }
        }
    }

    void EncounterMinigame(int gameIndex, Vector3 position)
    {
        GameObject newEncounter = Instantiate(miniGameChoices[gameIndex], position, Quaternion.identity);
    }

    Vector3 RandomPosOnScreen()
    {
        float height = Camera.main.orthographicSize * 2;
        float width = Camera.main.aspect * height;
        float x, y;
        x = origin.position.x;
        y = origin.position.y;
        Bounds encounterBounds = miniGameChoices[0].GetComponent<Collider2D>().bounds;

        Vector3 result = new Vector3(Random.Range(x - width/2 + encounterBounds.size.x, x + width/2 - encounterBounds.size.x), Random.Range(y - height / 2 + encounterBounds.size.y, y + height / 2 - encounterBounds.size.y), 0);

        return result;
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
