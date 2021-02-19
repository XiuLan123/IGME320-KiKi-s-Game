using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExitButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Transform exitText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        exitText.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        exitText.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        exitText = transform.GetChild(0);
    }

    // Update is called once per frame
    
}
