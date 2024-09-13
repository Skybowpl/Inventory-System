using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInventoryItemListDisplay : AbstractItemListDisplay
{
    [SerializeField] protected Inventory inventoryToDisplay;

    public override void UpdateDisplay()
    {
        itemList.Clear();
        foreach (InventorySlot slot in inventoryToDisplay.InventorySlots)
        {
            itemList.Add(slot.Item);
        }
        base.UpdateDisplay();
    }
}
