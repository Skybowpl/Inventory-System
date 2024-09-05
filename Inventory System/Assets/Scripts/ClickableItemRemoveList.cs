using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableItemRemoveList : AbstractClickableItemList
{
    protected override void ConfigureButton(GameObject buttonGameObject, ItemData item)
    {
        buttonGameObject.GetComponent<Button>().onClick.AddListener(() => inventory.RemoveItem(item));
        buttonGameObject.GetComponent<Button>().onClick.AddListener(() => inventoryDisplay.UpdateUi());
        buttonGameObject.GetComponent<Image>().sprite = item.icon;
    }
}
