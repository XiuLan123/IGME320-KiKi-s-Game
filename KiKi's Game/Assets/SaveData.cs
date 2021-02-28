using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    bool playedOnce;

    public bool PlayedOnce
    {
        get
        {
            return playedOnce;
        }
        set
        {
            playedOnce = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
