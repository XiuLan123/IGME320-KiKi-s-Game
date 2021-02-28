using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemForSellGenerator : MonoBehaviour
{
    List<GameObject> materialsList = new List<GameObject>();

    GameObject[] NMaterialList;
    GameObject[] RMaterialList;
    GameObject[] SRMaterialList;
    public GameObject fourthStage;

    StoreSlots[] slots;

    // Start is called before the first frame update
    void Start()
    {
        NMaterialList = Resources.LoadAll<GameObject>("Materials/N");
        RMaterialList = Resources.LoadAll<GameObject>("Materials/R");
        SRMaterialList = Resources.LoadAll<GameObject>("Materials/SR");
        GenerateItemsForSell();
    }

    public void GenerateItemsForSell()
    {
        slots = fourthStage.transform.GetComponentsInChildren<StoreSlots>();

        foreach (GameObject materials in materialsList)
        {
            Destroy(materials);
        }

        for (int i = 0; i < 10; i++)
        {
            if (Random.Range(0, 20) == 10)
            {
                GameObject materialGame = Instantiate(SRMaterialList[Random.Range(0, SRMaterialList.Length)], slots[i].transform);
                materialGame.transform.position = slots[i].transform.position;
                materialsList.Add(materialGame);
            }
            else if (Random.Range(0, 10) == 5)
            {
                GameObject materialGame = Instantiate(RMaterialList[Random.Range(0, RMaterialList.Length)], slots[i].transform);
                materialGame.transform.position = slots[i].transform.position;
                materialsList.Add(materialGame);
            }
            else
            {
                GameObject materialGame = Instantiate(NMaterialList[Random.Range(0, NMaterialList.Length)], slots[i].transform);
                materialGame.transform.position = slots[i].transform.position;
                materialsList.Add(materialGame);
            }
        }
    }
}
