using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> inventorySpace = new List<InventorySlot>();

    public void AddItem(ItemData itemToAdd)
    {
        InventorySlot itemSlot = FindSlotWithItem(itemToAdd);

        if (itemSlot == null)
        {
            inventorySpace.Add(new InventorySlot(itemToAdd, 1));
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
                inventorySpace.Remove(itemSlot);
            }
        }
        else
        {
            Debug.LogError("Item doens't exist");
        }
    }
    public InventorySlot FindSlotWithItem(ItemData itemToSearch)
    {
        foreach (InventorySlot slot in inventorySpace)
        {
            if (slot.item == itemToSearch)
            {
                return slot;
            }
        }
        return null;
    }
    public List<InventorySlot> GetInventorySpace()
    {
        return inventorySpace;
    }
}
