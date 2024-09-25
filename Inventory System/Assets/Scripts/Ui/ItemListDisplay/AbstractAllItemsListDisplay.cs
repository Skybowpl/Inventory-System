using InventorySystem.Items;
using UnityEngine;

namespace InventorySystem.UI
{
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
}