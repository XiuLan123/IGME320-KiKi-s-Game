using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsGenerator : MonoBehaviour
{
    List<string> materialsStringList = new List<string>();
    List<GameObject> materialsList = new List<GameObject>();

    Object material;
    public GameObject firstStage;

    // Start is called before the first frame update
    void Start()
    {
        materialsStringList.Add("Frog");
        materialsStringList.Add("Butterfly");
        materialsStringList.Add("Feather");
        materialsStringList.Add("MagicCrystal");
        materialsStringList.Add("Lavender");
        materialsStringList.Add("Rose");

        GenerateMaterials();
    }

    public void Reroll()
    {
        foreach(GameObject materials in materialsList)
        {
            Destroy(materials);
        }

        for (int i = 0; i < 3; i++)
        {
            material = Resources.Load(materialsStringList[Random.Range(0, materialsStringList.Count)]);
            GameObject materialGame = Instantiate(material, firstStage.transform) as GameObject;
            materialGame.transform.position = new Vector3(400 + 560 * i, 650, 0);
            materialsList.Add(materialGame);
        }
    }

    public void GenerateMaterials()
    {
        for (int i = 0; i < 3; i++)
        {
            material = Resources.Load(materialsStringList[Random.Range(0, materialsStringList.Count)]);
            GameObject materialGame = Instantiate(material, firstStage.transform) as GameObject;
            materialGame.transform.position = new Vector3(400 + 560 * i, 650, 0);
            materialsList.Add(materialGame);
        }
    }
}
