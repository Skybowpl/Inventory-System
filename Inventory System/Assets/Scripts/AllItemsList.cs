using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/All Item List")]
public class AllItemsList : ScriptableObject
{
    public List<ItemData> allItems = new List<ItemData>();
    [SerializeField] private string itemsPath = "Assets/ScriptableObjects/Items";

    [ContextMenu("Create List of all items")]
    private void UpdateItemList()
    {
        allItems.Clear();
        string[] itemsGuids = AssetDatabase.FindAssets("t:ItemData", new[] {itemsPath});
        foreach (string guid in itemsGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            ItemData item = AssetDatabase.LoadAssetAtPath<ItemData>(path);
            allItems.Add(item);
        }
    }
}