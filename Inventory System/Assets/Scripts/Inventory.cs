using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Dictionary<ItemData, int> inventorySpace;

    public void AddItem(ItemData itemToAdd)
    {
        if(inventorySpace.ContainsKey(itemToAdd))
        {
            inventorySpace[itemToAdd] += 1;
        }
        else
        {
            inventorySpace.Add(itemToAdd, 1);
        }
    }

    public void RemoveItem(ItemData itemToRemove)
    {
        if(inventorySpace.ContainsKey(itemToRemove) && inventorySpace[itemToRemove]>1)
        {
            inventorySpace[itemToRemove] -= 1;
        }
        else if(inventorySpace.ContainsKey(itemToRemove) && inventorySpace[itemToRemove] == 1)
        {
            inventorySpace.Remove(itemToRemove);
        }
        else
        {
            Debug.LogError("This item dont exist in inventory");
        }

    }

}
