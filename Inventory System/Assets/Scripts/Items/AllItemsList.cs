using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace InventorySystem.Items
{
    [CreateAssetMenu(menuName = "Scriptable Objects/All Item List")]
    public class AllItemsList : ScriptableObject, IItemList
    {
        [SerializeField] private List<ItemData> itemList = new List<ItemData>();

        public List<IItemData> ItemList
        {
            get { return itemList.Cast<IItemData>().ToList(); }
        }

#if UNITY_EDITOR
        [SerializeField] private string itemsPath = "Assets/ScriptableObjects/Items";
        [ContextMenu("Create List of all items")]
        private void UpdateItemList()
        {
            itemList.Clear();
            string[] itemsGuids = AssetDatabase.FindAssets("t:ItemData", new[] { itemsPath });
            foreach (string guid in itemsGuids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                ItemData item = AssetDatabase.LoadAssetAtPath<ItemData>(path);
                itemList.Add(item);
            }
        }
#endif
    }
}