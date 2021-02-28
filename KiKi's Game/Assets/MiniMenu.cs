using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniMenu : MonoBehaviour
{
    
    public bool JijiOpen = false;

    public void OpenOrCloseMinu()
    {
        if(JijiOpen)
        {
            CloseMinu();
        } else
        {
            OpenMinu();
        }
    }

    public void OpenMinu()
    {
        GameObject.Find("Bstay").SetActive(true);
        GameObject.Find("Bleave").SetActive(true);
        JijiOpen = true;
    }

    public void CloseMinu()
    {
        GameObject.Find("Bstay").SetActive(false);
        GameObject.Find("Bleave").SetActive(false);
        JijiOpen = false;
    }

    public void ReturnHome()
    {
        SceneManager.LoadScene("DevMenu");
    }

}
