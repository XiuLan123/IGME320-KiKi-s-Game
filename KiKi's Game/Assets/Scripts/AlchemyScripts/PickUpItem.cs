using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Item item;

    public void PickUp()
    {
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }
}
