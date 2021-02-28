using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpBttn : MonoBehaviour
{
    public GameObject helpPanelOne;
    public GameObject helpPanelTwo;
    public GameObject helpPanelThree;
    public GameObject helpPanelFour;
    public GameObject stageOne;
    public GameObject stageTwo;
    public GameObject stageThree;
    public GameObject stageFour;
    public GameObject exitBttn;
    public GameObject PriceBttn;
    public GameObject pricePanel;

    public void Click()
    {

        exitBttn.SetActive(true);

        if (stageOne.activeSelf)
        {
            helpPanelOne.SetActive(true);
        }
        else if (stageTwo.activeSelf)
        {
            helpPanelTwo.SetActive(true);
        }
        else if (stageThree.activeSelf)
        {
            helpPanelThree.SetActive(true);
        }
        else if (stageFour.activeSelf)
        {
            helpPanelFour.SetActive(true);
            PriceBttn.SetActive(true);
        }
    }

    public void ExitBttnClick()
    {
        helpPanelOne.SetActive(false);
        helpPanelTwo.SetActive(false);
        helpPanelThree.SetActive(false);
        helpPanelFour.SetActive(false);
        exitBttn.SetActive(false);
        PriceBttn.SetActive(false);
    }

    public void PriceBttnClick()
    {
        if (pricePanel.activeSelf)
        {
            pricePanel.SetActive(false);
        }
        else
        {
            pricePanel.SetActive(true);
        }
    }
}
