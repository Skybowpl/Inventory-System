using UnityEditor;
using UnityEngine;

namespace InventorySystem.Items
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Item Data")]
    public class ItemData : ScriptableObject, IItemData
    {
        [SerializeField] private string itemName;
        [SerializeField] private Sprite icon;
        [SerializeField] private string uniqueID;

        public string ItemName
        {
            get { return itemName; }
        }

        public Sprite Icon
        {
            get { return icon; }
        }

        public string UniqueID
        {
            get { return uniqueID; }
        }

#if UNITY_EDITOR
        private void Awake()
        {
            uniqueID = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(this));
        }
#endif
    }
}