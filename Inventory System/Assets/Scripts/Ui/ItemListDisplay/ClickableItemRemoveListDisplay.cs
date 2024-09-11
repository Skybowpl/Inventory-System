using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableItemRemoveListDisplay : AbstractAllItemsListDisplay
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private AbstractInventoryItemListDisplay inventoryDisplay;
    protected override void ConfigureSlot(ItemData itemData, GameObject listSlot)
    {
        listSlot.GetComponent<Button>().onClick.AddListener(() => inventory.RemoveItem(itemData));
        listSlot.GetComponent<Button>().onClick.AddListener(() => inventoryDisplay.UpdateDisplay());
        listSlot.GetComponent<Image>().sprite = itemData.icon;
    }
}
