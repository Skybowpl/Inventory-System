using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventorySlot
{
    public ItemData Item { get; }
    public int ItemAmount { get; set; }
}
