using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemSlotFinder
{
    public InventorySlot FindSlotWithItem(ItemData itemToSearch);
}
