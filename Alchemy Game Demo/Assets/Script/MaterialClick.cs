using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialClick : MonoBehaviour
{
    public Text materialName;
    MaterialsGenerator materialsGenerator;
    Backpack backPack;

    public void PickMaterial()
    {
        materialsGenerator = GetComponent<MaterialsGenerator>();
        backPack = GetComponent<Backpack>();

        materialName = materialsGenerator.textOne;
        backPack.ownedMaterials.Add(materialName.text);
        Debug.Log(materialName.text);
    }
}
