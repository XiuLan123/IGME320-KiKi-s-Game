using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddBttn : MonoBehaviour
{
    public Dropdown optionOne;
    public GameObject panel;
    int baseY = 350;
    int baseX = 120;
    int count = 0;

    public void Click()
    {
        if (count >= 3)
        {
            return;
        }
        else
        {
            string myText;
            myText = optionOne.options[optionOne.value].text;
            GameObject material = Instantiate(Resources.Load(myText, typeof(GameObject))) as GameObject;
            material.transform.SetParent(panel.transform);
            material.transform.position = new Vector3(baseX + count * 100, baseY, 0);

            Debug.Log(myText);
            count++;
        }
    }
}
