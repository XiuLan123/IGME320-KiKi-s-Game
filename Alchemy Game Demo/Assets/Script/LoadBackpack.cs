using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadBackpack : MonoBehaviour
{
    Backpack backPack;
    public GameObject panel;
    public GameObject MaterialPrefab;
    int baseY = 380;
    int baseX = 120;

    // Start is called before the first frame update
    void Start()
    {
        backPack = GetComponent<Backpack>();
    }

    public void Load()
    {   
        for (int i = 0; i < backPack.ownedMaterials.Count; i++)
        {
            GameObject material = Instantiate(MaterialPrefab);
            material.transform.SetParent(panel.transform);
            material.GetComponent<Text>().text = backPack.ownedMaterials[i];
            material.transform.position = new Vector3(baseX, baseY - 40 * i, 0);
        }
        panel.SetActive(true);
    }
}
