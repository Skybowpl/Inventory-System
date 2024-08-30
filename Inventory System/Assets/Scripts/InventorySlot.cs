using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot
{
    public ItemData item;
    public int itemAmmount;

    public InventorySlot(ItemData item, int ammount)
    {
        this.item = item;
        itemAmmount = ammount;
    }

}
