using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractClickableItemList : MonoBehaviour
{
    [SerializeField] protected List<ItemData> itemList;
    [SerializeField] protected InventoryDisplay inventoryDisplay;
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected GameObject buttonPrefab;
    [SerializeField] protected GameObject contentDisplay;

    protected void Awake()
    {
        UpdateList();
    }

    protected void UpdateList()
    {
        foreach (ItemData item in itemList)
        {
            GameObject buttonGameObject = Instantiate(buttonPrefab, contentDisplay.transform);
            ConfigureButton(buttonGameObject, item);
        }
    }

    protected abstract void ConfigureButton(GameObject buttonGameObject, ItemData item);
}
