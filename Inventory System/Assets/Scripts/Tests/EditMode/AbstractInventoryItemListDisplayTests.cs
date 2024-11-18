using InventorySystem.Items;
using InventorySystem.Storage;
using InventorySystem.UI;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.Tests.EditMode
{
    public class AbstractInventoryItemListDisplayTests
    {
        private class TestAbstractInventoryItemListDisplay : AbstractInventoryItemListDisplay
        {
            public void SetUpInventoryWithItems(List<ItemDataMock> testItemsToAdd)
            {
                GameObject inventoryGameObject = new GameObject();
                inventoryToDisplay = inventoryGameObject.AddComponent<Inventory>();
                foreach (ItemDataMock item in testItemsToAdd)
                {
                    inventoryToDisplay.AddItem(item);
                }
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
        public void UpdateDisplay_InstantiateSlotForEveryItemFromInventory()
        {
            //Arrange
            GameObject displayGameObject = new GameObject();
            TestAbstractInventoryItemListDisplay display = displayGameObject.AddComponent<TestAbstractInventoryItemListDisplay>();
            display.SetFields();
            display.SetUpInventoryWithItems(new List<ItemDataMock> { new ItemDataMock("sword", null, "1"), new ItemDataMock("bow", null, "2") });
            //Act
            display.UpdateDisplay();
            //Assert
            Assert.AreEqual(2, display.transform.childCount, "Slots weren't instantiated correctly");

        }

        [Test]
        public void UpdateDisplay_WhenInventoryIsEmpty_NotCreateNewSlots()
        {
            //Arrange
            GameObject displayGameObject = new GameObject();
            TestAbstractInventoryItemListDisplay display = displayGameObject.AddComponent<TestAbstractInventoryItemListDisplay>();
            display.SetFields();
            display.SetUpInventoryWithItems(new List<ItemDataMock>());
            //Act
            display.UpdateDisplay();
            //Assert
            Assert.AreEqual(0, display.transform.childCount, "Slots shouldn't be created");

        }

    }
}