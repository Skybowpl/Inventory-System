using InventorySystem.Items;
using InventorySystem.Storage;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem.UI
{
    public class ClickableItemAddListDisplay : AbstractAllItemsListDisplay
    {
        [SerializeField] protected Inventory inventory;
        [SerializeField] protected AbstractInventoryItemListDisplay inventoryDisplay;
        protected override void ConfigureSlot(IItemData itemData, GameObject listSlot)
        {
            Button button = listSlot.GetComponent<Button>();
            button.onClick.AddListener(() => inventory.AddItem(itemData));
            button.onClick.AddListener(() => inventoryDisplay.UpdateDisplay());
            listSlot.GetComponent<Image>().sprite = itemData.Icon;
        }
    }
}