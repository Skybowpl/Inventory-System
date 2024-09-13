using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IInventory
{
    [SerializeField] private List<InventorySlot> inventorySlots = new List<InventorySlot>();
    private InventorySlotFinder inventorySlotFinder = new InventorySlotFinder();

    public List<InventorySlot> InventorySlots
    {
        get { return inventorySlots; }
    }

    public void AddItem(ItemData itemToAdd)
    {
        InventorySlot itemSlot = inventorySlotFinder.FindSlotWithItem(itemToAdd, inventorySlots);

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
        InventorySlot itemSlot = inventorySlotFinder.FindSlotWithItem(itemToRemove, inventorySlots);

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
}