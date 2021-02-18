using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Manager : MonoBehaviour
{
    public FlyerPlayer kiki; //player
    //public GameObject broom;
    public GameObject background; //background
    public GameObject birdPrefab; //prefab for bird enemy
    public GameObject treePrefab; //prefab for tree enemy
    public GameObject cloudPrefab; //prefab for cloud1 enemy
    public GameObject cloud2Prefab; //prefab for cloud2 enemy
    public List<GameObject> enemies; //list for enemies
    public GameObject gameoverScreen; //game over screen
    public GameObject screen; //screen for pausing i think
    public float timer; //timer for game win
    public float invincibleTime; //time for kiki invincibility
    public bool isInvincible; //bool for invincible
    public bool isPaused; //bool for if the game is paused

    // Start is called before the first frame update
    void Start()
    {
        //kiki.health = 3;
        timer = 60f;
        isPaused = false;
        isInvincible = false;
        enemies = new List<GameObject>();
        //background.transform() //need the background to be reset to the original position
        //gameobject.instantiate(vector 3, object, quatornian.identity (4D vector))
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            Movement();
            for(int i = 0; i <= 0; i++)
            {
                MoveEnemy(enemies[i]);
            }
            
            timer -= Time.deltaTime;
            if (kiki != null)
            {
                if (kiki.health <= 0)
                {
                    gameoverScreen.SetActive(true);
                }
            }
            if (timer <= 0)
            {
                //win code
            }
        }

        if (invincibleTime > 0 && isInvincible)
        {
            invincibleTime -= Time.deltaTime;
        }
        else if(invincibleTime <= 0)
        {
            isInvincible = false;
        }


    }



    /// <summary>
    /// Movement code for kiki
    /// </summary>
    void Movement()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            kiki.gameObject.transform.position = new Vector3(kiki.gameObject.transform.position.x, kiki.gameObject.transform.position.y + .05f);
        }
        else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            kiki.gameObject.transform.position = new Vector3(kiki.gameObject.transform.position.x, kiki.gameObject.transform.position.y - .05f);
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            kiki.gameObject.transform.position = new Vector3(kiki.gameObject.transform.position.x - .05f, kiki.gameObject.transform.position.y);
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            kiki.gameObject.transform.position = new Vector3(kiki.gameObject.transform.position.x + .05f, kiki.gameObject.transform.position.y);
        }

        if (CheckCollide())
        {
            kiki.health--;
            isInvincible = true;
            invincibleTime = 3f;
        }
    }




    /// <summary>
    /// Checks for collision between enemy and kiki
    /// </summary>
    /// <returns>Returns true if there is collision</returns>
    bool CheckCollide()
    {
        //check if kiki is not invincible
        if(!isInvincible)
        {
            Collider2D k = kiki.gameObject.GetComponent<BoxCollider2D>();
            
            for(int i = 0; i < enemies.Count; i++)
            {
                Collider2D b = enemies[i].GetComponent<BoxCollider2D>();
            }


            if (k.bounds.Intersects(b.bounds))
            {
                return true;
            }
        }

        return false;
    }


    /// <summary>
    /// Moves Enemy forward on the screen from spawn point
    /// </summary>
    /// <param name="enemy">Enemy to be moved</param>
    public void MoveEnemy(GameObject enemy)
    {
        enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y - .03f);
    }


    public void InstantiateEnemy()
    {
        enemies.Add(GameObject.Instantiate(birdPrefab, new Vector3(UnityEngine.Random.Range(-5, 5), 6), Quaternion.identity));
        enemies.Add(GameObject.Instantiate(treePrefab, new Vector3(UnityEngine.Random.Range(-5, 5), 6), Quaternion.identity));
        enemies.Add(GameObject.Instantiate(cloudPrefab, new Vector3(UnityEngine.Random.Range(-5, 5), 6), Quaternion.identity));
        enemies.Add(GameObject.Instantiate(cloud2Prefab, new Vector3(UnityEngine.Random.Range(-5, 5), 6), Quaternion.identity));
    }
}
