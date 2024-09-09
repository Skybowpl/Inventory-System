using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] List<AbstractItemListDisplay> itemListDisplays;
    private void Start()
    {
        foreach (AbstractItemListDisplay display in itemListDisplays)
        {
            display.UpdateDisplay();
        }
    }
}