using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixBttn : MonoBehaviour
{
    Object potion;
    public GameObject potionSlot;
    Craft craft;
    public GameObject secondStage;
    public GameObject thirdStage;

    private void Start()
    {
        craft = Craft.instance;
    }

    public void CreatePotion()
    {
        if(craft.items.Count >=3)
        {
            potion = Resources.Load("Potion");
            GameObject potionGameObj = Instantiate(potion, potionSlot.transform) as GameObject;
            potionGameObj.transform.position = new Vector3(1920 / 2 + 30, 900, 0);

            for (int i = 0; i < 3; i++)
            {
                craft.Remove(craft.items[0]);
            }
        }
    }

    public void NextStage()
    {
        secondStage.SetActive(false);
        thirdStage.SetActive(true);
    }
}
