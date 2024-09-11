using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Inventory : MonoBehaviour, IInventory, IItemSlotFinder
{
    [SerializeField] private List<InventorySlot> inventorySlots = new List<InventorySlot>();

    public void AddItem(ItemData itemToAdd)
    {
        InventorySlot itemSlot = FindSlotWithItem(itemToAdd);

        if (itemSlot == null)
        {
            inventorySlots.Add(new InventorySlot(itemToAdd, 1));
        }
        else
        {
            itemSlot.itemAmount++;
        }
    }
    public void RemoveItem(ItemData itemToRemove)
    {
        InventorySlot itemSlot = FindSlotWithItem(itemToRemove);

        if(itemSlot != null)
        {
            if(itemSlot.itemAmount > 1)
            {
                itemSlot.itemAmount--;
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
            if (slot.item == itemToSearch)
            {
                return slot;
            }
        }
        return null;
    }
    public List<InventorySlot> GetInventorySlots()
    {
        return inventorySlots;
    }
}
