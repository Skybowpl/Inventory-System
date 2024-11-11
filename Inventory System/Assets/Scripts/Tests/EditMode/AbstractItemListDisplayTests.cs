using InventorySystem.Items;
using InventorySystem.UI;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.Tests.EditMode
{
    public class AbstractItemListDisplayTests
    {
        private class TestAbstractItemListDisplay : AbstractItemListDisplay
        {
            public void SetFields()
            {
                contentDisplay = this.gameObject;
                listSlotPrefab = new GameObject();
                UpdateItemList();
            }
            public void CreateExampleItemList()
            {
                itemList.Add(new ItemDataMock("Sword", null, "1"));
                itemList.Add(new ItemDataMock("Bow", null, "2"));
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

        [Test]
        public void UpdateDisplay_InstantiateSlotForEveryItem()
        {
            //Arrange
            GameObject displayGameObject = new GameObject();
            TestAbstractItemListDisplay display = displayGameObject.AddComponent<TestAbstractItemListDisplay>();
            display.SetFields();
            display.CreateExampleItemList();
            //Act
            display.UpdateDisplay();
            //Assert
            Assert.AreEqual(2, display.transform.childCount, "Slots weren't instantiated correctly");
        }

        [Test]
        public void UpdateDisplay_WhenItemListIsEmpty_NotCreateNewSlots()
        {
            //Arrange
            GameObject displayGameObject = new GameObject();
            TestAbstractItemListDisplay display = displayGameObject.AddComponent<TestAbstractItemListDisplay>();
            display.SetFields();
            //Act
            display.UpdateDisplay();
            //Assert
            Assert.AreEqual(0, display.transform.childCount, "Slots shouldn't be created");
        }
    }
}