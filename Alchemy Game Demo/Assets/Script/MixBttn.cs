using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixBttn : MonoBehaviour
{
    public GameObject panel;

    public void Click()
    {
        GameObject material = Instantiate(Resources.Load("Potion", typeof(GameObject))) as GameObject;

        material.transform.SetParent(panel.transform);
        material.transform.position = new Vector3(600, 350, 0);
    }
}
