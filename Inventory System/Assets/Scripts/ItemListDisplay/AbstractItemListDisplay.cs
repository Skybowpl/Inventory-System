using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractItemListDisplay : MonoBehaviour
{

    [SerializeField] protected GameObject contentDisplay;
    [SerializeField] protected GameObject listSlotPrefab;
    [SerializeField] protected List<ItemData> itemList;

    public virtual void UpdateDisplay()
    {
        for (int i = contentDisplay.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(contentDisplay.transform.GetChild(i).gameObject);
        }

        foreach (ItemData item in itemList)
        {
            GameObject listSlot = Instantiate(listSlotPrefab, contentDisplay.transform);
            ConfigureSlot(item, listSlot);
        }
    }
    protected abstract void ConfigureSlot(ItemData itemData, GameObject listSlot);

}
