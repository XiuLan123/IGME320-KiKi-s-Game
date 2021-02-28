using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsGenerator : MonoBehaviour
{
    List<GameObject> materialsList = new List<GameObject>();

    GameObject[] NMaterialList;
    GameObject[] RMaterialList;
    GameObject[] SRMaterialList;

    int rerollCounter = 0;

    public GameObject firstStage;
    public GameObject rerollBttn;

    public GameObject slotOne;
    public GameObject slotTwo;
    public GameObject slotThree;

    GameObject[] slots = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        NMaterialList = Resources.LoadAll<GameObject>("Materials/N");
        RMaterialList = Resources.LoadAll<GameObject>("Materials/R");
        SRMaterialList = Resources.LoadAll<GameObject>("Materials/SR");
        slots[0] = slotOne;
        slots[1] = slotTwo;
        slots[2] = slotThree;
        GenerateMaterials();
    }

    public void Reroll()
    {

        foreach (GameObject materials in materialsList)
        {
            Destroy(materials);
        }

        for (int i = 0; i < 3; i++)
        {
            if (Random.Range(0, 20) == 10)
            {
                GameObject materialGame = Instantiate(SRMaterialList[Random.Range(0, SRMaterialList.Length)], firstStage.transform);
                materialGame.transform.position = slots[i].transform.position;
                materialsList.Add(materialGame);
            }
            else if (Random.Range(0, 10) == 5)
            {
                GameObject materialGame = Instantiate(RMaterialList[Random.Range(0, RMaterialList.Length)], firstStage.transform);
                materialGame.transform.position = slots[i].transform.position;
                materialsList.Add(materialGame);
            }
            else
            {
                GameObject materialGame = Instantiate(NMaterialList[Random.Range(0, NMaterialList.Length)], firstStage.transform);
                materialGame.transform.position = slots[i].transform.position;
                materialsList.Add(materialGame);
            }
        }

        rerollCounter++;

        if (rerollCounter == 3)
        {
            rerollBttn.SetActive(false);
        }
    }

    public void GenerateMaterials()
    {
        rerollCounter = 0;
        rerollBttn.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            if(Random.Range(0,20) == 10)
            {
                GameObject materialGame = Instantiate(SRMaterialList[Random.Range(0, SRMaterialList.Length)], firstStage.transform);
                materialGame.transform.position = slots[i].transform.position;
                materialsList.Add(materialGame);
            }
            else if (Random.Range(0, 10) == 5)
            {
                GameObject materialGame = Instantiate(RMaterialList[Random.Range(0, RMaterialList.Length)], firstStage.transform);
                materialGame.transform.position = slots[i].transform.position;
                materialsList.Add(materialGame);
            }
            else
            {
                GameObject materialGame = Instantiate(NMaterialList[Random.Range(0, NMaterialList.Length)], firstStage.transform);
                materialGame.transform.position = slots[i].transform.position;
                materialsList.Add(materialGame);
            }
        }
    }
}
