using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpBtn : MonoBehaviour
{
    public GameObject jijiinfo;


    public void Click()
    {
        jijiinfo.SetActive(true);
    }

    public void ExitBtnClick()
    {
        jijiinfo.SetActive(false);
    }
}
