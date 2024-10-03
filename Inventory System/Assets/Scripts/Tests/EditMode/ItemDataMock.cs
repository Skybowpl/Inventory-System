using InventorySystem.Items;
using UnityEngine;

namespace InventorySystem.Tests.EditMode
{
    public class ItemDataMock : IItemData
    {
        public string ItemName { get; }
        public Sprite Icon { get; }
        public string UniqueID { get; }

        public ItemDataMock(string itemName, Sprite icon, string uniqueID)
        {
            ItemName = itemName;
            Icon = icon;
            UniqueID = uniqueID;
        }
    }
}