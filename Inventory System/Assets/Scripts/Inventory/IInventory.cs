using System.Collections;
using System.Collections.Generic;

public interface IInventory
{
    public void AddItem(ItemData itemToAdd);
    public void RemoveItem(ItemData itemToRemove);
    public List<InventorySlot> InventorySlots { get; }

}
