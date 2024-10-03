using InventorySystem.Storage;
using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.TestTools;

namespace InventorySystem.Tests.EditMode
{
    public class InventorySlotTests
    {
        private ItemDataMock sword = new ItemDataMock("Sword", null, "1");

        [Test]
        public void Constructor_GivenItemAndPositiveAmount_SetFieldsToTheseValues()
        {
            //Arrange
            int amount = 2;
            //Act
            InventorySlot inventorySlot = new InventorySlot(sword, amount);
            //Assert
            Assert.AreEqual(sword.UniqueID, inventorySlot.Item.UniqueID, message: "Different item in inventory slot than expected");
            Assert.AreEqual(amount, inventorySlot.ItemAmount, message: "Incorrect amount in inventory slot");

        }

        [Test]
        public void Constructor_GivenItemAndNegativeAmount_SetAmountFieldToZeroAndItemFieldToGivenItem()
        {
            //Arrange
            int amount = -2;
            //Act
            InventorySlot inventorySlot = new InventorySlot(sword, amount);
            //Assert
            LogAssert.Expect(LogType.Error, "Item Amount can't be set bellow 0. Setting amount to 0.");
            Assert.AreEqual(sword.UniqueID, inventorySlot.Item.UniqueID, message: "Different item in inventory slot than expected");
            Assert.AreEqual(0, inventorySlot.ItemAmount, message: "Amount is not 0 in inventory slot");
        }

        [Test]
        public void Constructor_GivenNullAsItem_ThrowsArgumentNullException()
        {
            //Arrange
            int amount = 2;
            try
            {
                //Act
                InventorySlot inventorySlot = new InventorySlot(null, amount);
                //Assert
                Assert.Fail("Expected an ArgumentNullException to be thrown.");
            }
            catch (ArgumentNullException)
            {
                // Exception throwed as expected
            }
        }

        [Test]
        public void ItemAmount_GivenNegativeAmount_AmountNotChanged()
        {
            //Arrange
            int startAmount = 2;
            int newAmount = -2;
            InventorySlot inventorySlot = new InventorySlot(sword, startAmount);
            //Act
            inventorySlot.ItemAmount = newAmount;
            //Assert
            LogAssert.Expect(LogType.Error, "Item Amount can't be set below 0. Not changed the amount of items.");
            Assert.AreEqual(startAmount, inventorySlot.ItemAmount, message: "Amount shouldn't change");
        }

        [Test]
        public void ItemAmount_GivenPositiveAmount_SetAmountToTheseValue()
        {
            //Arrange
            int startAmount = 2;
            int newAmount = 10;
            InventorySlot inventorySlot = new InventorySlot(sword, startAmount);
            //Act
            inventorySlot.ItemAmount = newAmount;
            //Assert
            Assert.AreEqual(newAmount, inventorySlot.ItemAmount, message: "Amount shouldn't change");
        }
    }
}