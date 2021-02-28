using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreUI : MonoBehaviour
{
    public Transform itemsParent;

    Store store;

    StoreSlots[] slots;

    // Start is called before the first frame update
    void Start()
    {
        store = Store.instance;
        store.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<StoreSlots>();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < store.items.Count)
            {
                slots[i].AddItem(store.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
