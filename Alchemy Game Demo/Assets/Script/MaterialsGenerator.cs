using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialsGenerator : MonoBehaviour
{
    public Button bttnOne;
    public Button bttnTwo;
    public Button bttnThree;
    public Button bttnFour;
    public Text textOne;
    public Text textTwo;
    public Text textThree;
    public Text textFour;

    public List<string> materialList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        bttnOne = GameObject.Find("MaterialOne").GetComponent<Button>();
        bttnTwo = GameObject.Find("MaterialTwo").GetComponent<Button>();
        bttnThree = GameObject.Find("MaterialThree").GetComponent<Button>();
        bttnFour = GameObject.Find("MaterialFour").GetComponent<Button>();

        textOne = bttnOne.transform.Find("Text").GetComponent<Text>();
        textTwo = bttnTwo.transform.Find("Text").GetComponent<Text>();
        textThree = bttnThree.transform.Find("Text").GetComponent<Text>();
        textFour = bttnFour.transform.Find("Text").GetComponent<Text>();

        materialList.Add("Copper");
        materialList.Add("Silver");
        materialList.Add("Gold");
        materialList.Add("Garlic");
        materialList.Add("Clover");
        materialList.Add("Crocus");

        RandomMaterial();
    }

    void RandomMaterial()
    {
        textOne.text = materialList[Random.Range(0, materialList.Count)];
        textTwo.text = materialList[Random.Range(0, materialList.Count)];
        textThree.text = materialList[Random.Range(0, materialList.Count)];
        textFour.text = materialList[Random.Range(0, materialList.Count)];
    }
}
