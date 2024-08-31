using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> inventorySpace = new List<InventorySlot>();

    public void AddItem(ItemData itemToAdd)
    {
        InventorySlot itemSlot = FindSlotWithItem(inventorySpace, itemToAdd);

        if (itemSlot == null)
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
        InventorySlot itemSlot = FindSlotWithItem(inventorySpace, itemToRemove);

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

    public void WriteToDebug() //prze¿uciæ do innej klasy która bêdzie obs³ugiwaæ wyœwietlanie ekwipunku
    {
        foreach (InventorySlot slot in inventorySpace)
        {
            Debug.Log(slot.item.name+" "+slot.itemAmmount);
        }
    }
    private InventorySlot FindSlotWithItem(List<InventorySlot> inventorySpace, ItemData itemToSearch)
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
}
