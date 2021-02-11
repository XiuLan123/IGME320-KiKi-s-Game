using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthStage : MonoBehaviour
{
    public GameObject fourthStage;
    public GameObject firstStage;

    public void NextStage()
    {
        fourthStage.SetActive(false);
        firstStage.SetActive(true);
        firstStage.GetComponent<MaterialsGenerator>().GenerateMaterials();
        fourthStage.GetComponent<ItemForSellGenerator>().GenerateItemsForSell();
    }
}
