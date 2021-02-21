﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Manager : MonoBehaviour
{
    public FlyerPlayer kiki; //player

    public GameObject background; //background

    public GameObject birdPrefab; //prefab for bird enemy
    public GameObject treePrefab; //prefab for tree enemy
    public GameObject cloudPrefab; //prefab for cloud1 enemy
    public GameObject cloud2Prefab; //prefab for cloud2 enemy
    public List<GameObject> enemies; //list for enemies

    public GameObject gameoverScreen; //game over screen
    public GameObject winScreen;
    public Text countdown;
    //public GameObject screen; //screen for pausing i think
    public float timer; //timer for game win

    public float invincibleTime; //time for kiki invincibility
    public bool isInvincible; //bool for invincible
    public bool isPaused; //bool for if the game is paused

    // Start is called before the first frame update
    void Start()
    {
        //kiki.health = 3;
        timer = 60f;
        countdown.text = "Time Left: " + timer; 
        isPaused = false;
        isInvincible = false;
        enemies = new List<GameObject>();
        winScreen.SetActive(false);
        gameoverScreen.SetActive(false);
        //background.transform() //need the background to be reset to the original position
        //gameobject.instantiate(vector 3, object, quatornian.identity (4D vector))
    }

    // Update is called once per frame
    void Update()
    { 
        
        //if the game isnt paused
        if (!isPaused && !gameoverScreen.activeSelf && !winScreen.activeSelf)
        {


            //instantiate enemies
            if (UnityEngine.Random.Range(0f, 100f) < .5)
            {
                InstantiateEnemy();
            }

            //screenstuff method
            ScreenStuff();

            //movement method
            Movement();

            //move the enemies
            for(int i = 0; i < enemies.Count; i++)
            {
                MoveEnemy(enemies[i]);
            }
            

            if (kiki != null)
            {
                if (kiki.health <= 0)
                {
                    gameoverScreen.SetActive(true);
                }

                if(kiki.health > 0 && timer <= 0)
                {
                    winScreen.SetActive(true);
                }
            }

            //count down the timer
            timer -= Time.deltaTime;
            countdown.text = "Time Left: " + (int)timer;
        }


        //timing to keep kiki invincible
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
        //input for wasd and arrow controls
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


        //check collide for kiki and enemies
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

                if (k.bounds.Intersects(b.bounds))
                {
                    return true;
                }
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



    /// <summary>
    /// Method that holds instantiating enemies into the enemy list
    /// </summary>
    public void InstantiateEnemy()
    {
        switch(UnityEngine.Random.Range(1,5))
        {
            case 1:
                enemies.Add(GameObject.Instantiate(birdPrefab, new Vector3(UnityEngine.Random.Range(-7, 7), 6), Quaternion.identity));
                break;
            case 2:
                enemies.Add(GameObject.Instantiate(treePrefab, new Vector3(UnityEngine.Random.Range(-7, 7), 6), Quaternion.identity));
                break;
            case 3:
                enemies.Add(GameObject.Instantiate(cloudPrefab, new Vector3(UnityEngine.Random.Range(-7, 7), 6), Quaternion.identity));
                break;
            case 4:
                enemies.Add(GameObject.Instantiate(cloud2Prefab, new Vector3(UnityEngine.Random.Range(-7, 7), 6), Quaternion.identity));
                break;
        } 
    }


    /// <summary>
    /// Method that holds information about screen wrapping and enemy despwaning
    /// </summary>
    public void ScreenStuff()
    {
        if (kiki.gameObject.transform.position.y > 4.0)
        {
            kiki.gameObject.transform.position = new Vector3(kiki.gameObject.transform.position.x, 4.0f);
        }

        if (kiki.gameObject.transform.position.y < -4.0)
        {
            kiki.gameObject.transform.position = new Vector3(kiki.gameObject.transform.position.x, -4.0f);
        }

        if (kiki.gameObject.transform.position.x > 10.0)
        {
            kiki.gameObject.transform.position = new Vector3(-10, kiki.gameObject.transform.position.y);
        }

        if (kiki.gameObject.transform.position.x < -10.0)
        {
            kiki.gameObject.transform.position = new Vector3(10, kiki.gameObject.transform.position.y);
        }


        //remove enemies after they pass the lower bounds of the screen
        for(int i = 0; i < enemies.Count; i++)
        {
            if(enemies[i].transform.position.y < -4.5)
            {
                GameObject temp = enemies[i];
                enemies.Remove(temp);
                Destroy(temp);
            }
        }
    }
}
