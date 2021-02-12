using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdStage : MonoBehaviour
{

    public GameObject thirdStage;
    public GameObject fourthStage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextStage()
    {
        thirdStage.SetActive(false);
        fourthStage.SetActive(true);
    }
}
