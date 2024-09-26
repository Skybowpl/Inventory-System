using InventorySystem.Items;
using UnityEngine;

namespace InventorySystem.Storage
{
    public class InventorySlot : IInventorySlot
    {
        private IItemData item;
        private int itemAmount;

        public IItemData Item
        {
            get { return item; }
        }

        public int ItemAmount
        {
            get { return itemAmount; }
            set
            {
                if (value >= 0)
                {
                    itemAmount = value;
                }
                else
                {
                    Debug.LogError("Item Ammount can't be set bellow 0");
                }
            }
        }

        public InventorySlot(IItemData item, int amount)
        {
            this.item = item;
            itemAmount = amount;
        }
    }
}