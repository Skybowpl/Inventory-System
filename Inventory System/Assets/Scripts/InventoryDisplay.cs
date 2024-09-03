using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private Inventory inventoryToDisplay;
    [SerializeField] private GameObject contentDisplay; //Game Object holding all items in UI
    [SerializeField] private GameObject inventorySlotDisplayPrefab; // Prefab to create inventory slot for content display

    public void UpdateUi()
    {
        for (int i = contentDisplay.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(contentDisplay.transform.GetChild(i).gameObject);
        }

        List<InventorySlot> inventorySpace = inventoryToDisplay.GetInventorySpace();

        foreach (InventorySlot inventorySlot in inventorySpace)
        {
            GameObject uiElement = Instantiate(inventorySlotDisplayPrefab, contentDisplay.transform);
            uiElement.GetComponent<Image>().sprite = inventorySlot.item.icon;
            uiElement.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text = inventorySlot.itemAmmount.ToString();
        }
    }

    public void WriteToDebug()
    {
        foreach (InventorySlot slot in inventoryToDisplay.GetInventorySpace())
        {
            Debug.Log(slot.item.name + " " + slot.itemAmmount);
        }
    }
}
