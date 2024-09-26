using UnityEngine;

namespace InventorySystem.Items
{
    public interface IItemData
    {
        public string ItemName { get; }
        public Sprite Icon { get; }
        public string UniqueID { get; }
    }
}