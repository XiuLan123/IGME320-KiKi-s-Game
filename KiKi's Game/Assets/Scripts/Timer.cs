using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    static float timeLeft;
    Text timeDisplay;

    public static float TimeLeft 
    {
        get
        {
            return timeLeft;
        }
    }

    private void Awake()
    {
        timeLeft = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeDisplay = transform.GetChild(0).GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeDisplay.text = string.Format("ETA: " + Mathf.FloorToInt(timeLeft) + "s");
        }
    }
}
