using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Manager : MonoBehaviour
{
    public Player kiki;
    public GameObject broom;
    public GameObject background;
    public GameObject bird;

    // Start is called before the first frame update
    void Start()
    {
        kiki = new Player();
        kiki.health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void CheckCollide()
    {

    }
}
