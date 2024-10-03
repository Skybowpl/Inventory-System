using InventorySystem.Items;
using System;
using System.Collections.Generic;

namespace InventorySystem.Storage
{
    public class InventorySlotFinder : IInventorySlotFinder
    {
        public IInventorySlot FindSlotWithItem(IItemData itemToSearch, List<IInventorySlot> inventorySlots)
        {
            if(itemToSearch == null || inventorySlots==null)
            {
                throw new ArgumentNullException("Item ot slots list is null");
            }

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
}