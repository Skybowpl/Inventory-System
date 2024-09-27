using InventorySystem.Items;
using InventorySystem.Storage;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.Tests.EditMode
{
    public class InventorySlotFinderTests
    {
        private class ItemData : IItemData
        {
            public string ItemName { get; }
            public Sprite Icon { get; }
            public string UniqueID { get; }

            public ItemData(string itemName, Sprite icon, string uniqueID)
            {
                ItemName = itemName;
                Icon = icon;
                UniqueID = uniqueID;
            }
        }

        //Creating example items
        private ItemData sword = new ItemData("Sword", null, "1");
        private ItemData wand = new ItemData("Wand", null, "2");
        private ItemData bow = new ItemData("Bow", null, "3");


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

    }
}