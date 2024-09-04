using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableItemAddList : MonoBehaviour
{
    [SerializeField] private List<ItemData> itemList;
    [SerializeField] private InventoryDisplay inventoryDisplay;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject butttonPrefab;
    [SerializeField] private GameObject contentDisplay;

    private void Awake()
    {
        UpdateList();
    }

    private void UpdateList()
    {
        foreach (ItemData item in itemList)
        {
            GameObject buttonGameObject = Instantiate(butttonPrefab, contentDisplay.transform);

            buttonGameObject.GetComponent<Button>().onClick.AddListener(() => inventory.AddItem(item));
            buttonGameObject.GetComponent<Button>().onClick.AddListener(() => inventoryDisplay.UpdateUi());
            buttonGameObject.GetComponent<Image>().sprite = item.icon;

        }
    }
}
