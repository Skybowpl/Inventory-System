using InventorySystem.Storage;
using InventorySystem.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem.UI
{
    public class InventoryListWithAmountsDisplay : AbstractInventoryItemListDisplay
    {
        protected override void ConfigureSlot(IItemData itemData, GameObject listSlot)
        {
            listSlot.GetComponent<Image>().sprite = itemData.Icon;
            IInventorySlotFinder inventorySlotFinder = new InventorySlotFinder();
            listSlot.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text = inventorySlotFinder.FindSlotWithItem(itemData, inventoryToDisplay.InventorySlots).ItemAmount.ToString();
        }
    }
}