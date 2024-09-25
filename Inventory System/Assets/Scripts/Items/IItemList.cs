using System.Collections.Generic;

namespace InventorySystem.Items
{
    public interface IItemList
    {
        public List<IItemData> ItemList { get; }
    }
}