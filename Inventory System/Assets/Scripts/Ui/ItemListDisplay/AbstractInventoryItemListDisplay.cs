using InventorySystem.Storage;
using UnityEngine;

namespace InventorySystem.UI
{
    public abstract class AbstractInventoryItemListDisplay : AbstractItemListDisplay
    {
        [SerializeField] protected Inventory inventoryToDisplay;

        public override void UpdateDisplay()
        {
            UpdateItemList();
            base.UpdateDisplay();
        }
        protected override void UpdateItemList()
        {
            itemList.Clear();
            foreach (IInventorySlot slot in inventoryToDisplay.InventorySlots)
            {
                itemList.Add(slot.Item);
            }
        }
    }
}