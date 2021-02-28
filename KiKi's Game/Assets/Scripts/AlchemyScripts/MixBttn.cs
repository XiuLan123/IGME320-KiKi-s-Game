using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixBttn : MonoBehaviour
{
    Craft craft;
    GameObject[] potionList;
    public GameObject potionSlot;
    public GameObject secondStage;
    public GameObject thirdStage;
    public GameObject backPack;
    Backpack backPackScript;

    int highRareityChance = 1;

    private void Start()
    {
        craft = Craft.instance;
        potionList = Resources.LoadAll<GameObject>("Potions");
        backPackScript = backPack.GetComponent<Backpack>();
    }

    public void CreatePotion()
    {
        if(craft.items.Count ==3)
        {
            RarityCheck();

            if (Random.Range(highRareityChance,30) > 25)
            {
                GameObject potionGameObj = Instantiate(potionList[0], potionSlot.transform);
                potionGameObj.transform.position = new Vector3(potionSlot.transform.position.x, potionSlot.transform.position.y, 0);
            }
            else if (Random.Range(highRareityChance, 25) > 15)
            {
                GameObject potionGameObj = Instantiate(potionList[1], potionSlot.transform);
                potionGameObj.transform.position = new Vector3(potionSlot.transform.position.x, potionSlot.transform.position.y, 0);
            }
            else
            {
                GameObject potionGameObj = Instantiate(potionList[2], potionSlot.transform);
                potionGameObj.transform.position = new Vector3(potionSlot.transform.position.x, potionSlot.transform.position.y, 0);
            }

            for (int i = 0; i < 3; i++)
            {
                craft.Remove(craft.items[0]);
            }

            highRareityChance = 1;

            backPackScript.secondStageCounter = 0;
        }
    }

    public void NextStage()
    {
        secondStage.SetActive(false);
        thirdStage.SetActive(true);
    }

    void RarityCheck()
    {
        for(int i = 0; i < craft.items.Count; i++)
        {
            if(craft.items[i].rarity == "SR")
            {
                highRareityChance += 7;
            }
            else if(craft.items[i].rarity == "R")
            {
                highRareityChance += 4;
            }
            else
            {
                highRareityChance += 1;
            }
        }
    }
}
