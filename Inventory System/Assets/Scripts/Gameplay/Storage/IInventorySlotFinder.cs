using InventorySystem.Items;
using System.Collections.Generic;

namespace InventorySystem.Storage
{
    public interface IInventorySlotFinder
    {
        public IInventorySlot FindSlotWithItem(IItemData itemToSearch, List<IInventorySlot> inventorySlots);
    }
}
