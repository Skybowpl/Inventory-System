using InventorySystem.Items;
using System;
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
                    Debug.LogError("Item Amount can't be set below 0. Not changed the amount of items.");
                }
            }
        }

        public InventorySlot(IItemData item, int amount)
        {
            
            if (item == null)
            {
                throw new ArgumentNullException("Item data can't be null.");
            }
            else
            {
                this.item = item;
            }
            if (amount >= 0)
            {
                itemAmount = amount;
            }
            else
            {
                itemAmount=0;
                Debug.LogError("Item Amount can't be set bellow 0. Setting amount to 0.");
            }
        }
    }
}