using InventorySystem.Storage;
using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.TestTools;

namespace InventorySystem.Tests.EditMode
{
    public class InventoryTests
    {
        //ExampleItem
        private ItemDataMock sword = new ItemDataMock("Sword", null, "1");
        private ItemDataMock bow = new ItemDataMock("Bow", null, "2");

        [Test]
        public void AddItem_GivenNewItem_AddNewInventorySlotWithItemOfAmount1()
        {
            //Arrange
            GameObject gameObject = new GameObject();
            Inventory inventory = gameObject.AddComponent<Inventory>();
            //Act
            inventory.AddItem(sword);
            //Assert
            Assert.AreEqual(sword.UniqueID, inventory.InventorySlots[0].Item.UniqueID, message: "Different item in inventory slot than expected");
            Assert.AreEqual(1, inventory.InventorySlots[0].ItemAmount, message: "Incorrect amount in inventory slot");

        }

        [Test]
        public void AddItem_GivenItemExistingInInventory_Add1ToItemAmount()
        {
            //Arrange
            GameObject gameObject = new GameObject();
            Inventory inventory = gameObject.AddComponent<Inventory>();
            inventory.AddItem(sword);
            //Act
            inventory.AddItem(sword);
            //Assert
            Assert.AreEqual(1, inventory.InventorySlots.Count, message: "New item added even though it shouldn't happen");
            Assert.AreEqual(2, inventory.InventorySlots[0].ItemAmount, message: "Incorrect amount in inventory slot");

        }
        [Test]
        public void AddItem_GivenNullAsItem_ThrowsArgumentNullException()
        {
            //Arrange
            GameObject gameObject = new GameObject();
            Inventory inventory = gameObject.AddComponent<Inventory>();
            try
            {
                //Act
                inventory.AddItem(null);
                //Assert
                Assert.Fail("Expected an ArgumentNullException to be thrown.");
            }
            catch (ArgumentNullException)
            {
                // Exception throwed as expected
            }

        }
        [Test]
        public void RemoveItem_GivenItemToRemoveWhenItemAmountIsAbove1_ItemAmountDecreasesBy1()
        {
            //Arrange
            GameObject gameObject = new GameObject();
            Inventory inventory = gameObject.AddComponent<Inventory>();
            inventory.AddItem(sword);
            inventory.AddItem(sword);
            //Act
            inventory.RemoveItem(sword);
            //Assert
            Assert.AreEqual(1, inventory.InventorySlots.Count, message: "Slot with item removed even though it shouldn't happen");
            Assert.AreEqual(1, inventory.InventorySlots[0].ItemAmount, message: "Incorrect amount in inventory slot");
        }
        [Test]
        public void RemoveItem_GivenItemToRemoveWhenItemAmountIs1_ItemSlotRemoved()
        {
            //Arrange
            GameObject gameObject = new GameObject();
            Inventory inventory = gameObject.AddComponent<Inventory>();
            inventory.AddItem(sword);
            //Act
            inventory.RemoveItem(sword);
            //Assert
            Assert.AreEqual(0, inventory.InventorySlots.Count, message: "Slot with item not removed even though it shouldn't happen");
        }
        [Test]
        public void RemoveItem_GivenItemNotExistingInInventory_NothingChange()
        {
            //Arrange
            GameObject gameObject = new GameObject();
            Inventory inventory = gameObject.AddComponent<Inventory>();
            inventory.AddItem(sword);
            //Act
            inventory.RemoveItem(bow);
            //Assert
            LogAssert.Expect(LogType.Error, "Item doesn't exist");
            Assert.AreEqual(1, inventory.InventorySlots.Count, message: "Slot with item removed even though it shouldn't happen");
            Assert.AreEqual(1, inventory.InventorySlots[0].ItemAmount, message: "Incorrect amount in inventory slot");
        }
        [Test]
        public void RemoveItem_GivenNullAsItem_ThrowsArgumentNullException()
        {
            //Arrange
            GameObject gameObject = new GameObject();
            Inventory inventory = gameObject.AddComponent<Inventory>();
            inventory.AddItem(sword);
            try
            {
                //Act
                inventory.RemoveItem(null);
                //Assert
                Assert.Fail("Expected an ArgumentNullException to be thrown.");
            }
            catch (ArgumentNullException)
            {
                // Exception throwed as expected
            }
        }
    }
}