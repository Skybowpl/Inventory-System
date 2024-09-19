using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotFinder : IInventorySlotFinder
{
    public IInventorySlot FindSlotWithItem(IItemData itemToSearch, List<IInventorySlot> inventorySlots)
    {
        foreach (IInventorySlot slot in inventorySlots)
        {
            if (slot.Item.UniqueID == itemToSearch.UniqueID)
            {
                return slot;
            }
        }
        return null;
    }
}
