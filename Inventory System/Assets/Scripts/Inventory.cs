using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> inventorySpace;

    public void AddItem(ItemData itemToAdd)
    {
        InventorySlot itemSlot = null;
        //potencjalnie zrobiæ metode FindItem mo¿e siê przydac dla find i remove
        foreach (InventorySlot slot in inventorySpace)
        {
            if (slot.item.name == itemToAdd.name)
            {
                itemSlot = slot;
                break;
            }
        }

        if(itemSlot == null)
        {
            inventorySpace.Add(new InventorySlot(itemToAdd, 1));
        }
        else
        {
            itemSlot.itemAmmount++;
        }
    }

    public void RemoveItem(ItemData itemToRemove)
    {
        InventorySlot itemSlot = null;

        foreach (InventorySlot slot in inventorySpace)
        {
            if (slot.item.name == itemToRemove.name)
            {
                itemSlot = slot;
                break;
            }
        }

        if(itemSlot != null)
        {
            if(itemSlot.itemAmmount > 1)
            {
                itemSlot.itemAmmount--;
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
}
