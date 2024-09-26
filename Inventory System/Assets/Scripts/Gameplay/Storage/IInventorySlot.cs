using InventorySystem.Items;

namespace InventorySystem.Storage
{
    public interface IInventorySlot
    {
        public IItemData Item { get; }
        public int ItemAmount { get; set; }
    }
}