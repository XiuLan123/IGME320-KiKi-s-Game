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
    public Color color = new Color();

    public Item(int price, string rarity, string type)
    {
        this.price = price;
        this.rarity = rarity;
        this.type = type;
        this.color = new Color(255, 255, 255, 1);
    }
}
