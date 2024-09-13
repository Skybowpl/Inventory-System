using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IInventory, IItemSlotFinder
{
    [SerializeField] private List<InventorySlot> inventorySlots = new List<InventorySlot>();

    public List<InventorySlot> InventorySlots
    {
        get { return inventorySlots; }
    }

    public void AddItem(ItemData itemToAdd)
    {
        InventorySlot itemSlot = FindSlotWithItem(itemToAdd);

        if (itemSlot == null)
        {
            inventorySlots.Add(new InventorySlot(itemToAdd, 1));
        }
        else
        {
            itemSlot.ItemAmount++;
        }
    }
    public void RemoveItem(ItemData itemToRemove)
    {
        InventorySlot itemSlot = FindSlotWithItem(itemToRemove);

        if(itemSlot != null)
        {
            if(itemSlot.ItemAmount > 1)
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
            Debug.LogError("Item doens't exist");
        }
    }
    public InventorySlot FindSlotWithItem(ItemData itemToSearch)
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.Item == itemToSearch)
            {
                return slot;
            }
        }
        return null;
    }
}
