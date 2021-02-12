using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemForSellGenerator : MonoBehaviour
{
    List<string> materialsStringList = new List<string>();
    List<GameObject> materialsList = new List<GameObject>();

    Object material;
    public GameObject fourthStage;

    StoreSlots[] slots;

    // Start is called before the first frame update
    void Start()
    {
        materialsStringList.Add("Frog");
        materialsStringList.Add("Butterfly");
        materialsStringList.Add("Feather");
        materialsStringList.Add("MagicCrystal");
        materialsStringList.Add("Lavender");
        materialsStringList.Add("Rose");
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
            material = Resources.Load(materialsStringList[Random.Range(0, materialsStringList.Count)]);
            GameObject materialGame = Instantiate(material, slots[i].transform) as GameObject;
            materialGame.transform.position = slots[i].transform.position;
            materialsList.Add(materialGame);
        }
    }
}
