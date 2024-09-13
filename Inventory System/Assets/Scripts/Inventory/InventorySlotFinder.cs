using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotFinder : IInventorySlotFinder
{
    public InventorySlot FindSlotWithItem(ItemData itemToSearch, List<InventorySlot> inventorySlots)
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.Item == itemToSearch)
            {
                return slot;
            }
        }
        return null;
    }
}
