using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdStage : MonoBehaviour
{

    public GameObject thirdStage;
    public GameObject fourthStage;
    public GameObject questOneBttn;
    public GameObject questTwoBttn;
    public GameObject questThreeBttn;

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

    public void QuestOneClick()
    {
        Item removeOne = null;
        Item removeTwo = null;
        Item removeThree = null;

        foreach (Item i in Inventory.instance.items)
        {
            if (i.rarity == "N" && i.type == "Potion" && removeOne == null)
            {
                removeOne = i;
            }
            else if (i.rarity == "N" && i.type == "Potion" && removeTwo == null)
            {
                removeTwo = i;
            }
            else
            {
                removeThree = i;
            }
        }

        if (removeOne != null && removeTwo != null && removeThree != null)
        {
            Inventory.instance.items.Remove(removeOne);
            Inventory.instance.items.Remove(removeTwo);
            Inventory.instance.items.Remove(removeThree);
            questThreeBttn.SetActive(false);
        }
    }

    public void QuestTwoClick()
    {
        Item removeOne = null;
        Item removeTwo = null;

        foreach (Item i in Inventory.instance.items)
        {

            if (i.rarity == "N" && i.type == "Potion" && removeOne == null)
            {
                removeOne = i;
            }
            else
            {
                removeTwo = i;
            }
        }

        if (removeOne != null && removeTwo != null)
        {
            Inventory.instance.items.Remove(removeOne);
            Inventory.instance.items.Remove(removeTwo);
            questThreeBttn.SetActive(false);
        }
    }

    public void QuestThreeClick()
    {
        Item removeOne = null;

        foreach (Item i in Inventory.instance.items)
        {

            if (i.rarity == "SR" && i.type == "Potion")
            {
                removeOne = i;
            }
        }

        if (removeOne != null)
        {
            Inventory.instance.items.Remove(removeOne);
            questThreeBttn.SetActive(false);
        }
    }
}
