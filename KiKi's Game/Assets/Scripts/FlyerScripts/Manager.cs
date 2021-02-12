using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Manager : MonoBehaviour
{
    public FlyerPlayer kiki;
    //public GameObject broom;
    public GameObject background;
    public GameObject bird;
    public GameObject gameoverScreen;
    public float timer;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        //kiki.health = 3;
        timer = 60f;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            Movement();
            MoveEnemy(bird);
            timer -= Time.deltaTime;
            if (kiki != null)
            {
                if (kiki.health <= 0)
                {
                    //game over
                }
            }
            if (timer <= 0)
            {
                //win code
            }
        }
    }

    void Movement()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            kiki.gameObject.transform.position = new Vector3(kiki.gameObject.transform.position.x, kiki.gameObject.transform.position.y + .2f);
        }
        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            kiki.gameObject.transform.position = new Vector3(kiki.gameObject.transform.position.x, kiki.gameObject.transform.position.y - .2f);
        }
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            kiki.gameObject.transform.position = new Vector3(kiki.gameObject.transform.position.x - .2f, kiki.gameObject.transform.position.y);
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            kiki.gameObject.transform.position = new Vector3(kiki.gameObject.transform.position.x + .2f, kiki.gameObject.transform.position.y);
        }

        //if (CheckCollide())
        //{
        //    kiki.health--;
        //}
    }


    bool CheckCollide()
    {
        Collider2D k = kiki.gameObject.GetComponent<BoxCollider2D>();
        Collider2D b = bird.gameObject.GetComponent<BoxCollider2D>();

        if (k.bounds.Intersects(b.bounds))
        {
            return true;
        }
        //SpriteRenderer rend1 = go1.GetComponent<SpriteRenderer>();
        //SpriteRenderer rend2 = go2.GetComponent<SpriteRenderer>();
        //Image image1 = go1.GetComponent<Image>();
        //Image image2 = go2.GetComponent<Image>();

        //if (rend1.bounds.extents.x < rend2.bounds.extents.x + image2.minWidth &&
        //    rend1.bounds.extents.x + image1.minWidth > rend2.bounds.extents.x &&
        //    rend1.bounds.extents.y < rend2.bounds.extents.y + image2.minHeight &&
        //    rend1.bounds.extents.y + image1.minHeight > rend2.bounds.extents.y)
        //{
        //    // collision detected!
        //    return true;
        //}

        return false;
    }


    public void MoveEnemy(GameObject enemy)
    {
        enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y - .03f);
    }
}
