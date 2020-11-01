using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItemReaction : Reactions
{
    public Item item;               // Item to be removed from the Inventory.


    private Inventory inventory;    // Reference to the Inventory component.

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();

    }
    


    protected override void ImmediateReaction()
    {
        inventory.Remove(item);
    }
}
