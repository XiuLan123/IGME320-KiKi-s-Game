using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item" )]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public int price = 0;
    public string rarity = "none";
    public string type = "none";
    public Sprite icon = null;
}
