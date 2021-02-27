using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proceduralBackground : MonoBehaviour
{
    public GameObject[] clouds;
    public GameObject[] birds;

    float birdBuffer = 2f; //1s-4s
    float cloudBuffer = 3f; //1s-4s

    float yLimit = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(birdBuffer <= 0)
        {
            Instantiate(birds[Random.Range(0, birds.Length)]).GetComponent<BGObj>().speed = Random.Range(20f, 30f);
            birdBuffer = Random.Range(2f, 3f);
        }
    }
}
