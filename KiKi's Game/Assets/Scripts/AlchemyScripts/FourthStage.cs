using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FourthStage : MonoBehaviour
{
    public GameObject fourthStage;
    public GameObject firstStage;
    public Text turnLabel;
    int turnCounter = 1;
    public GameObject losePanel;

    public void NextStage()
    {
        turnCounter++;
        turnLabel.text = "Turn: " + turnCounter;

        if (turnCounter > 7)
        {
            losePanel.SetActive(true);
        }

        fourthStage.SetActive(false);
        firstStage.SetActive(true);
        firstStage.GetComponent<MaterialsGenerator>().GenerateMaterials();
        fourthStage.GetComponent<ItemForSellGenerator>().GenerateItemsForSell();
    }
}
