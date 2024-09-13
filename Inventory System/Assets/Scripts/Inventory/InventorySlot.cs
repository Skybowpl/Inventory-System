using UnityEngine;

public class InventorySlot : IInventorySlot
{
    private ItemData item;
    private int itemAmount;

    public ItemData Item
    {
        get { return item; }
    }

    public int ItemAmount
    {
        get { return itemAmount; }
        set
        {
            if (value >= 0)
            {
                itemAmount = value;
            }
            else
            {
                Debug.LogError("Item Ammount can't be set bellow 0");
            }
        }
    }

    public InventorySlot(ItemData item, int amount)
    {
        this.item = item;
        itemAmount = amount;
    }
}
