using System.Collections;
using System.Collections.Generic;

public interface IInventory
{
    public void AddItem(IItemData itemToAdd);
    public void RemoveItem(IItemData itemToRemove);
    public List<IInventorySlot> InventorySlots { get; }

}
