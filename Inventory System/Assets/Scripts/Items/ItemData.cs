using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Item Data")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite icon;

    public string ItemName
    {
        get { return itemName; }
    }

    public Sprite Icon
    {
        get { return icon; }
    }
}
