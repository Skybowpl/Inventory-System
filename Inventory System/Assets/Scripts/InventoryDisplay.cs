using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private Inventory inventoryToDisplay;


    public void WriteToDebug()
    {
        foreach (InventorySlot slot in inventoryToDisplay.GetInventorySpace())
        {
            Debug.Log(slot.item.name + " " + slot.itemAmmount);
        }
    }
}
