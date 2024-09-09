using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryListWithAmountsDisplay : AbstractInventoryItemListDisplay
{
    protected override void ConfigureSlot(ItemData itemData, GameObject listSlot)
    {
        listSlot.GetComponent<Image>().sprite = itemData.icon;
        listSlot.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text = inventoryToDisplay.FindSlotWithItem(itemData).itemAmount.ToString();
    }
}
