using InventorySystem.Items;
using System.Collections.Generic;

namespace InventorySystem.Storage
{
    public interface IInventory
    {
        public void AddItem(IItemData itemToAdd);
        public void RemoveItem(IItemData itemToRemove);
        public List<IInventorySlot> InventorySlots { get; }

    }
}