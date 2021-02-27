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
    public Collider2D player;
    public Camera introCam;
    public Camera main;
    public MenuController kiki;

    private void Awake()
    {
        introCam.enabled = true;
        main.enabled = false;
    }

    private void Start()
    {
        encounterTimer = Random.Range(0f,2f);
    }

    private void Update()
    {
        if (!introCam.enabled)
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

            //if (Input.GetKeyDown(KeyCode.Alpha1))
            //{
            //    SceneManager.LoadScene(1);
            //}
            //if (Input.GetKeyDown(KeyCode.Alpha2))
            //{
            //    SceneManager.LoadScene(2);
            //}
            //if (Input.GetKeyDown(KeyCode.Alpha3))
            //{
            //    SceneManager.LoadScene(3);
            //}
            //if (Input.GetKeyDown(KeyCode.Alpha4))
            //{
            //    SceneManager.LoadScene(4);
            //}
        }
        else if(introCam.transform.position.y  == -8.83f)
        {
            introCam.enabled = false;
            main.enabled = true;
            kiki.introDone = true;
            introCam.gameObject.SetActive(false);
            player.gameObject.SetActive(true);
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
        encounterBounds.center = result;

        while (player.bounds.Intersects(encounterBounds))
        {
            result = new Vector3(Random.Range(x - width / 2 + encounterBounds.size.x, x + width / 2 - encounterBounds.size.x), Random.Range(y - height / 2 + encounterBounds.size.y, y + height / 2 - encounterBounds.size.y), 0);
            encounterBounds.center = result;
        }

        return result;
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
