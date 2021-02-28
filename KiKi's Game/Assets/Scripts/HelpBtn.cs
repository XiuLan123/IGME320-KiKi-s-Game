using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpBtn : MonoBehaviour
{
    public GameObject jijiinfo;


    public void Click()
    {
        jijiinfo.SetActive(true);
        Time.timeScale = 0;
    }

    public void ExitBtnClick()
    {
        jijiinfo.SetActive(false);
        Time.timeScale = 1f;
    }
}
