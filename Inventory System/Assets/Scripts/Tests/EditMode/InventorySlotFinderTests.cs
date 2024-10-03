using InventorySystem.Storage;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace InventorySystem.Tests.EditMode
{
    public class InventorySlotFinderTests
    {

        //Creating example items
        private ItemDataMock sword = new ItemDataMock("Sword", null, "1");
        private ItemDataMock wand = new ItemDataMock("Wand", null, "2");
        private ItemDataMock bow = new ItemDataMock("Bow", null, "3");


        [Test]
        public void FindSlotWithItem_GivenInventorySlotListAndItemExisitingInThisList_ReturnSlotWithGivenItem()
        {
            //Arrange
            InventorySlotFinder slotFinder = new InventorySlotFinder();
            //Creating item slots list with items
            List<IInventorySlot> slots = new List<IInventorySlot>() { new InventorySlot(sword, 1), new InventorySlot(wand, 1), new InventorySlot(bow, 1) };

            //Act
            IInventorySlot result = slotFinder.FindSlotWithItem(sword, slots);

            //Assert
            Assert.AreEqual(sword.UniqueID, result.Item.UniqueID, message: "Found slot does't contain item that was searched for");

        }

        [Test]
        public void FindSlotWithItem_GivenInventorySlotListAndItemNotExisitingInThisList_ReturnNull()
        {
            //Arrange
            InventorySlotFinder slotFinder = new InventorySlotFinder();
            //Creating item slots list with items
            List<IInventorySlot> slots = new List<IInventorySlot>() { new InventorySlot(wand, 1), new InventorySlot(bow, 1) };

            //Act
            IInventorySlot result = slotFinder.FindSlotWithItem(sword, slots);

            //Assert
            Assert.IsNull(result, message: "Slot was found even though it shouldn't have been");

        }

        [Test]
        public void FindSlotWithItem_GivenNullAndItem_ThrowsArgumentNullException()
        {
            //Arrange
            InventorySlotFinder slotFinder = new InventorySlotFinder();
            try
            {
                //Act
                IInventorySlot result = slotFinder.FindSlotWithItem(sword, null);
                //Assert
                Assert.Fail("Expected an ArgumentNullException to be thrown.");
            }
            catch (ArgumentNullException)
            {
                // Exception throwed as expected
            }
        }

        [Test]
        public void FindSlotWithItem_GivenInventorySlotListAndNull_ThrowsArgumentNullException()
        {
            //Arrange
            InventorySlotFinder slotFinder = new InventorySlotFinder();
            //Creating item slots list with items
            List<IInventorySlot> slots = new List<IInventorySlot>() { new InventorySlot(wand, 1), new InventorySlot(bow, 1) };
            try
            {
                //Act
                IInventorySlot result = slotFinder.FindSlotWithItem(null, slots);
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