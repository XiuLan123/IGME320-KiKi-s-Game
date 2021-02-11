using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Backpack : MonoBehaviour
{
    public GameObject canvas;
    GameObject clickedObejct;
    public GameObject firstStage;
    public GameObject secondStage;
    public GameObject fourthStage;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= 3)
        {
            firstStage.SetActive(false);
            secondStage.SetActive(true);
            count = 0;
        }

        if (Input.GetMouseButtonDown(0))
        {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;
            BaseRaycaster gr = canvas.GetComponent<BaseRaycaster>();
            List<RaycastResult> results = new List<RaycastResult>();
            gr.Raycast(pointerEventData, results);
            if (results.Count != 0)
            {
                clickedObejct = results[0].gameObject;
                Debug.Log(clickedObejct);

                if (clickedObejct.GetComponent<PickUpItem>() != null && firstStage.activeSelf)
                {
                    clickedObejct.GetComponent<PickUpItem>().PickUp();
                    Destroy(clickedObejct);
                    count++;
                }
                else if(clickedObejct.GetComponent<InventorySlot>() != null && secondStage.activeSelf)
                {
                    Debug.Log("Stage2");
                    clickedObejct.GetComponent<InventorySlot>().SendItem();

                }
                else if (clickedObejct.GetComponent<PickUpItem>() != null && secondStage.activeSelf)
                {
                    clickedObejct.GetComponent<PickUpItem>().PickUp();
                    Destroy(clickedObejct);
                }
                else if (clickedObejct.GetComponent<PickUpItem>() != null && fourthStage.activeSelf)
                {
                    clickedObejct.GetComponent<PickUpItem>().PickUp();
                    Destroy(clickedObejct);
                }

            }
        }
    }
}
