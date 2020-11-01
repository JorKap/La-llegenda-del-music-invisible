using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryData
{
    public List<Item> items = new List<Item>();

    public InventoryData(Inventory inventory)
    {
        items = inventory.items;
    }
}
