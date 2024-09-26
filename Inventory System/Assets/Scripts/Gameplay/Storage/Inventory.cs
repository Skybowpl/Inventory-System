using InventorySystem.Items;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.Storage
{
    public class Inventory : MonoBehaviour, IInventory
    {
        private List<IInventorySlot> inventorySlots = new List<IInventorySlot>();
        private IInventorySlotFinder inventorySlotFinder = new InventorySlotFinder();

        public List<IInventorySlot> InventorySlots
        {
            get { return inventorySlots; }
        }

        public void AddItem(IItemData itemToAdd)
        {
            IInventorySlot itemSlot = inventorySlotFinder.FindSlotWithItem(itemToAdd, inventorySlots);

            if (itemSlot == null)
            {
                inventorySlots.Add(new InventorySlot(itemToAdd, 1));
            }
            else
            {
                itemSlot.ItemAmount++;
            }
        }
        public void RemoveItem(IItemData itemToRemove)
        {
            IInventorySlot itemSlot = inventorySlotFinder.FindSlotWithItem(itemToRemove, inventorySlots);

            if (itemSlot != null)
            {
                if (itemSlot.ItemAmount > 1)
                {
                    itemSlot.ItemAmount--;
                }
                else
                {
                    inventorySlots.Remove(itemSlot);
                }
            }
            else
            {
                Debug.LogError("Item doesn't exist");
            }
        }
    }
}