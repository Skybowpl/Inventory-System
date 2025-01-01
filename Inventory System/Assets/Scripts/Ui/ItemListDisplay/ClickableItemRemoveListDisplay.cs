using InventorySystem.Items;
using UnityEngine;
using UnityEngine.UI;
using InventorySystem.Storage;

namespace InventorySystem.UI
{
    public class ClickableItemRemoveListDisplay : AbstractAllItemsListDisplay
    {
        [SerializeField] protected Inventory inventory;
        [SerializeField] protected AbstractInventoryItemListDisplay inventoryDisplay;
        protected override void ConfigureSlot(IItemData itemData, GameObject listSlot)
        {
            Button button = listSlot.GetComponent<Button>();
            button.onClick.AddListener(() => inventory.RemoveItem(itemData));
            button.onClick.AddListener(() => inventoryDisplay.UpdateDisplay());
            listSlot.GetComponent<Image>().sprite = itemData.Icon;
        }
    }
}