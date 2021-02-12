using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftUI : MonoBehaviour
{
    public Transform itemsParent;

    Craft craft;

    CraftSlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        craft = Craft.instance;
        craft.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<CraftSlot>();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < craft.items.Count)
            {
                slots[i].AddItem(craft.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}