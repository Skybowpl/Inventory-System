using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot
{
    public ItemData item;
    public int itemAmount;

    public InventorySlot(ItemData item, int amount)
    {
        this.item = item;
        itemAmount = amount;
    }

}
