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
    public int gold;
    public Text goldLabel;
    public delegate void OnGoldChanged();
    public OnGoldChanged onGoldChangedCallback;
    int firstStageCounter;
    public int secondStageCounter;
    public GameObject winPanel;
    public GameObject losePanel;

    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        onGoldChangedCallback += UpdateGold;
        UpdateGold();
    }

    // Update is called once per frame
    void Update()
    {
        if (firstStageCounter >= 3)
        {
            firstStage.SetActive(false);
            secondStage.SetActive(true);
            firstStageCounter = 0;
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
                    firstStageCounter++;
                }
                else if(clickedObejct.GetComponent<InventorySlot>() != null && secondStage.activeSelf && secondStageCounter != 3)
                {
                    bool tf = clickedObejct.GetComponent<InventorySlot>().SendItem();
                    if (tf)
                    {
                        secondStageCounter++;
                    }
                }
                else if (clickedObejct.GetComponent<CraftSlot>() != null && secondStage.activeSelf)
                {
                    bool tf = clickedObejct.GetComponent<CraftSlot>().SendItem();
                    if (tf)
                    {
                        secondStageCounter--;
                    }
                }
                else if (clickedObejct.GetComponent<PickUpItem>() != null && secondStage.activeSelf)
                {
                    clickedObejct.GetComponent<PickUpItem>().PickUp();
                    Destroy(clickedObejct);
                }
                else if (clickedObejct.GetComponent<PickUpItem>() != null && fourthStage.activeSelf)
                {
                    if (ChangeGold(clickedObejct.GetComponent<PickUpItem>().item.price, false))
                    {
                        clickedObejct.GetComponent<PickUpItem>().PickUp();            
                        Destroy(clickedObejct);
                    }
                }
                else if (clickedObejct.GetComponent<InventorySlot>() != null && fourthStage.activeSelf)
                {
                    if(clickedObejct.GetComponent<InventorySlot>().item != null)
                    {
                        ChangeGold(clickedObejct.GetComponent<InventorySlot>().item.price, true);
                        clickedObejct.GetComponent<InventorySlot>().RemoveItem();
                    }
                }
            }
        }
    }

    public bool ChangeGold(int value, bool addOrSub)
    {
        if (addOrSub == false && gold - value < 0)
        {
            return false;
        }
        else if (addOrSub)
        {
            gold += value;

            if (onGoldChangedCallback != null)
            {
                onGoldChangedCallback.Invoke();
            }

            return true;
        }
        else
        {
            gold -= value;

            if (onGoldChangedCallback != null)
            {
                onGoldChangedCallback.Invoke();
            }

            return true;
        }
    }

    public void UpdateGold()
    {
        goldLabel.text = ": " + gold.ToString();
    }
}
