using System.Collections.Generic;

public interface IInventorySlotFinder
{
    public InventorySlot FindSlotWithItem(ItemData itemToSearch, List<InventorySlot> inventorySlots);
}
