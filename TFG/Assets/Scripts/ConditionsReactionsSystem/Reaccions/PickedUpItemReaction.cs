using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedUpItemReaction : Reactions
{
    public Item item;               // The item asset to be added to the Inventory.

    private Inventory inventory;    // Reference to the Inventory component.

    private void Start()
    {
       // inventory = Inventory.instance;
        Debug.Log("Item " + item.name);

    }


    protected override void ImmediateReaction()
    {
        Inventory.instance.Add(item);
    }
}


