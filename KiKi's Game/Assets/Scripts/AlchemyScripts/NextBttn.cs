using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBttn : MonoBehaviour
{
    public GameObject stageOne;
    public GameObject stageTwo;
    public void Click()
    {
        stageOne.SetActive(false);
        stageTwo.SetActive(true);
    }
}
