using System.Collections.Generic;

public interface IInventorySlotFinder
{
    public IInventorySlot FindSlotWithItem(IItemData itemToSearch, List<IInventorySlot> inventorySlots);
}
