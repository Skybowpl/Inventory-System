using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableItemAddList : AbstractClickableItemList
{
    protected override void ConfigureButton(GameObject buttonGameObject, ItemData item)
    {
        buttonGameObject.GetComponent<Button>().onClick.AddListener(() => inventory.AddItem(item));
        buttonGameObject.GetComponent<Button>().onClick.AddListener(() => inventoryDisplay.UpdateUi());
        buttonGameObject.GetComponent<Image>().sprite = item.icon;
    }
}
