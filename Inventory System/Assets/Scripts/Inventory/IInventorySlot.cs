using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventorySlot
{
    public IItemData Item { get; }
    public int ItemAmount { get; set; }
}
