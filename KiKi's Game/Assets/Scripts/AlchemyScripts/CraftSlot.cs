using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftSlot : MonoBehaviour
{
    Item item;
    public Image icon;

    public void AddItem(Item newItem)
    {
        if(newItem != null)
        {
            item = newItem;

            icon.color = item.color;

            icon.sprite = item.icon;
            icon.enabled = true;
        }
    }

    public void ClearSlot()
    {
        item = null;

        icon.color = new Color();

        icon.sprite = null;
        icon.enabled = false;
    }

    public bool SendItem()
    {
        if(item != null)
        {
            Inventory.instance.Add(item);
            Craft.instance.Remove(item);
            return true;
        }
        else
        {
            return false;
        }
    }
}
