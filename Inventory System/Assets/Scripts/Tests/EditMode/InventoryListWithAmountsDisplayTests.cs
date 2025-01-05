using InventorySystem.Items;
using InventorySystem.Storage;
using InventorySystem.UI;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem.Tests.EditMode
{
    public class InventoryListWithAmountsDisplayTests
    { 
        private class TestInventoryListWithAmountsDisplay : InventoryListWithAmountsDisplay
        {
            public void SetFields()
            {
                GameObject inventory = new GameObject();
                inventoryToDisplay = inventory.AddComponent<Inventory>();
            }
            public void AddNewItemToInventory(IItemData itemToAdd)
            {
                inventoryToDisplay.AddItem(itemToAdd);
            }
            public string GetItemAmount(IItemData item)
            {
                IInventorySlotFinder inventorySlotFinder = new InventorySlotFinder();
                return inventorySlotFinder.FindSlotWithItem(item, inventoryToDisplay.InventorySlots).ItemAmount.ToString();
            }
            public void SimulateSlotConfiguartion(IItemData itemData, GameObject listSlot)
            {
                ConfigureSlot(itemData, listSlot);
            }
        }

        [Test]
        public void ConfigureSlot_SetImage()
        {
            //Arrange
            GameObject displayGameObject = new GameObject();
            TestInventoryListWithAmountsDisplay display = displayGameObject.AddComponent<TestInventoryListWithAmountsDisplay>();
            display.SetFields();

            GameObject listSlot = new GameObject();
            listSlot.AddComponent<Image>();
            GameObject text = new GameObject();
            text.name = "Text";
            text.transform.parent = listSlot.transform;
            text.AddComponent<TextMeshProUGUI>();

            Sprite sprite = Sprite.Create(new Texture2D(1, 1), new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f));
            sprite.name = "TestSprite";

            ItemDataMock sword = new ItemDataMock("sword", sprite, "1");
            display.AddNewItemToInventory(sword);

            //Act
            display.SimulateSlotConfiguartion(sword, listSlot);

            //Assert
            Assert.AreEqual(listSlot.GetComponent<Image>().sprite.name, sprite.name, "Icon was not set correctly");

        }

        [Test]
        public void ConfigureSlot_SetItemAmountInText()
        {
            //Arrange
            GameObject displayGameObject = new GameObject();
            TestInventoryListWithAmountsDisplay display = displayGameObject.AddComponent<TestInventoryListWithAmountsDisplay>();
            display.SetFields();

            GameObject listSlot = new GameObject();
            listSlot.AddComponent<Image>();
            GameObject text = new GameObject();
            text.name = "Text";
            text.transform.parent = listSlot.transform;
            text.AddComponent<TextMeshProUGUI>();

            Sprite sprite = Sprite.Create(new Texture2D(1, 1), new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f));
            sprite.name = "TestSprite";

            ItemDataMock sword = new ItemDataMock("sword", sprite, "1");
            display.AddNewItemToInventory(sword);

            //Act
            display.SimulateSlotConfiguartion(sword, listSlot);

            //Assert
            Assert.AreEqual(display.GetItemAmount(sword), listSlot.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text, "Item Amount isn't correct");
        }
    }
}