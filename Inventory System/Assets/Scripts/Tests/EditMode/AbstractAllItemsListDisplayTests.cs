using InventorySystem.Items;
using InventorySystem.UI;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.Tests.EditMode
{
    public class AbstractAllItemsListDisplayTests
    {
        private class TestAllItemsList : AllItemsList
        {
            public void SetAllItemList(List<ItemData> testItemsToAdd)
            {
                foreach (ItemData item in testItemsToAdd)
                {
                    itemList.Add(item);
                }
            }
        }

        private class TestAbstractAllItemsListDisplay : AbstractAllItemsListDisplay
        {
            public void SimulateAwake()
            {
                Awake();
            }
            public void SetUpAllItemList(TestAllItemsList testAllitemList)
            {
                allItemsList=testAllitemList;
            }
            public void SetFields()
            {
                contentDisplay = this.gameObject;
                listSlotPrefab = new GameObject();
            }
            protected override void ConfigureSlot(IItemData itemData, GameObject listSlot)
            {
                Debug.Log("Slots Configurated");
            }
        }


        [Test]
        public void UpdateDisplay_InstantiateSlotForEveryItemFromAllItemList()
        {
            //Arrange
            GameObject displayGameObject = new GameObject();
            TestAbstractAllItemsListDisplay display = displayGameObject.AddComponent<TestAbstractAllItemsListDisplay>();
            display.SetFields();
            ItemData sword = ScriptableObject.CreateInstance<ItemData>();
            ItemData bow = ScriptableObject.CreateInstance<ItemData>();
            TestAllItemsList testAllItemsList = ScriptableObject.CreateInstance<TestAllItemsList>();
            testAllItemsList.SetAllItemList(new List<ItemData> { sword, bow });
            display.SetUpAllItemList(testAllItemsList);
            //Act
            display.SimulateAwake();
            //Assert
            Assert.AreEqual(2, display.transform.childCount, "Slots weren't instantiated correctly");
        }

        [Test]
        public void UpdateDisplay_WhenAllItemListIsEmpty_NotCreateNewSlots()
        {
            //Arrange
            GameObject displayGameObject = new GameObject();
            TestAbstractAllItemsListDisplay display = displayGameObject.AddComponent<TestAbstractAllItemsListDisplay>();
            display.SetFields();
            TestAllItemsList testAllItemsList = ScriptableObject.CreateInstance<TestAllItemsList>();
            testAllItemsList.SetAllItemList(new List<ItemData> { });
            display.SetUpAllItemList(testAllItemsList);
            //Act
            display.SimulateAwake();
            //Assert
            Assert.AreEqual(0, display.transform.childCount, "Slots shouldn't be created");
        }

    }
}