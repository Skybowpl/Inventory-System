using InventorySystem.Items;
using InventorySystem.UI;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace InventorySystem.Tests.PlayMode
{
    public class AbstractItemListDisplayTests
    {
        private class TestAbstractItemListDisplay : AbstractItemListDisplay
        {
            protected override void Awake()
            {
                contentDisplay = this.gameObject;
                listSlotPrefab = new GameObject();
                base.Awake();
            }
            protected override void ConfigureSlot(IItemData itemData, GameObject listSlot)
            {
                Debug.Log("Slot configurated");
            }

            protected override void UpdateItemList()
            {
                Debug.Log("Item List Updated");
            }
        }

        [UnityTest]
        public IEnumerator UpdateDisplay_DestroyAllGameObjectChildren()
        {
            //Arrange
            GameObject displayGameObject = new GameObject();
            GameObject exampleChildGameObject1 = new GameObject();
            GameObject exampleChildGameObject2 = new GameObject();
            exampleChildGameObject1.transform.parent = displayGameObject.transform;
            exampleChildGameObject2.transform.parent = displayGameObject.transform;
            TestAbstractItemListDisplay display = displayGameObject.AddComponent<TestAbstractItemListDisplay>();

            //Act
            display.UpdateDisplay();
            yield return null;

            //Assert
            Assert.AreEqual(0, display.transform.childCount, "Not all children were destroyed");
        }
        
    }
}
