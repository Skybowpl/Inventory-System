using InventorySystem.Items;
using InventorySystem.Storage;
using InventorySystem.UI;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem.Tests.EditMode
{
    public class ClickableItemRemoveListDisplayTests
    {
        private class TestClickableItemRemoveListDisplay : ClickableItemRemoveListDisplay
        {
            public void SetFields()
            {
                GameObject testInventory = new GameObject();
                inventory = testInventory.AddComponent<Inventory>();
                inventoryDisplay = testInventory.AddComponent<InventoryListWithAmountsDisplay>();
            }
            public void SimulateSlotConfiguartion(IItemData itemData, GameObject listSlot)
            {
                ConfigureSlot(itemData, listSlot);
            }

        }

        [Test]
        public void ConfigureSlot_SetIconForButton()
        {
            //Arrange
            GameObject displayGameObject = new GameObject();
            TestClickableItemRemoveListDisplay display = displayGameObject.AddComponent<TestClickableItemRemoveListDisplay>();
            display.SetFields();
            GameObject listSlot = new GameObject();
            listSlot.AddComponent<Button>();
            listSlot.AddComponent<Image>();

            Sprite sprite = Sprite.Create(new Texture2D(1, 1), new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f));
            sprite.name = "TestSprite";

            ItemDataMock sword = new ItemDataMock("sword", sprite, "1");

            //Act
            display.SimulateSlotConfiguartion(sword, listSlot);

            //Assert
            Assert.AreEqual(listSlot.GetComponent<Image>().sprite.name, sprite.name, "Icon was not set correctly");
        }
    }
}