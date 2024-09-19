using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractItemListDisplay : MonoBehaviour, IUpdatableDisplay
{

    [SerializeField] protected GameObject contentDisplay;
    [SerializeField] protected GameObject listSlotPrefab;
    protected List<IItemData> itemList = new List<IItemData>();

    protected virtual void Awake()
    {
        UpdateDisplay();
    }

    public virtual void UpdateDisplay()
    {
        for (int i = contentDisplay.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(contentDisplay.transform.GetChild(i).gameObject);
        }

        foreach (IItemData item in itemList)
        {
            GameObject listSlot = Instantiate(listSlotPrefab, contentDisplay.transform);
            ConfigureSlot(item, listSlot);
        }
    }
    protected abstract void ConfigureSlot(IItemData itemData, GameObject listSlot);
    protected abstract void UpdateItemList();
}
