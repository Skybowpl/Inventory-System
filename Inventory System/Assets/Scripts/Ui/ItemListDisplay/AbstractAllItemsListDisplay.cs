using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAllItemsListDisplay : AbstractItemListDisplay
{
    [SerializeField] protected AllItemsList allItemsList;
    protected override void Awake()
    {
        UpdateItemList();
        base.Awake();
    }
    protected override void UpdateItemList()
    {
        itemList = allItemsList.ItemList;
    }
}
