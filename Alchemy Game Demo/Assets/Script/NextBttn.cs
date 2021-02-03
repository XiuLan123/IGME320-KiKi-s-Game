using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextBttn : MonoBehaviour
{
    public GameObject panelOne;
    public GameObject panelTwo;
    public GameObject panelThree;
    public GameObject panelFour;

    public Dropdown optionOne;

    Backpack backPack;

    public void Click()
    {
        if(panelOne.activeSelf == true)
        {
            panelTwo.SetActive(true);
            panelOne.SetActive(false);

            backPack = GetComponent<Backpack>();

            optionOne.ClearOptions();
            if (backPack.ownedMaterials.Count > 0)
            {
                optionOne.AddOptions(backPack.ownedMaterials);
            }
        }
        else if (panelTwo.activeSelf == true)
        {
            panelThree.SetActive(true);
            panelTwo.SetActive(false);

        }
        else if (panelThree.activeSelf == true)
        {
            panelFour.SetActive(true);
            panelThree.SetActive(false);
        }
        else if (panelFour.activeSelf == true)
        {
            panelOne.SetActive(true);
            panelFour.SetActive(false);
        }
    }
}
