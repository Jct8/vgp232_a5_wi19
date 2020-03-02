using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Assignment5.Data;
using System.IO;

namespace Assignment5.Tests
{
    public class ItemsDataTest
    {
        string saveFile = null;
        string loadFile = null;
        string myDirPath;
        ItemsData itemsData = new ItemsData();

        [SetUp]
        public void Initialization()
        {
            myDirPath = System.AppContext.BaseDirectory;
            saveFile = Path.Combine(myDirPath, "itemSaveFile.xml");
            loadFile = Path.Combine(myDirPath, "itemData.xml");
        }

        [Test]
        public void TestItemsLoad()
        {
            ItemsData itemsDataLoad = new ItemsData();
            try
            {
                itemsDataLoad = ItemReader.Load(loadFile);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [Test]
        public void TestUnlockedItemsAtLevel()
        {
            itemsData.Items.Clear();
            Item item0 = new Item();
            Item item1 = new Item();
            Item item2 = new Item();
            Item item3 = new Item();
            Item item4 = new Item();
            Item item5 = new Item();
            Item item6 = new Item();
            Item item7 = new Item();
            Item item8 = new Item();
            Item item9 = new Item();
            item0.UnlockRequirement = 10;
            item1.UnlockRequirement = 0;
            item2.UnlockRequirement = 5;
            item3.UnlockRequirement = 12;
            item4.UnlockRequirement = 13;
            item5.UnlockRequirement = 10;
            item6.UnlockRequirement = 4;
            item7.UnlockRequirement = 20;
            item8.UnlockRequirement = 18;
            item9.UnlockRequirement = 3;
            itemsData.Items.Add(item0);
            itemsData.Items.Add(item1);
            itemsData.Items.Add(item2);
            itemsData.Items.Add(item3);
            itemsData.Items.Add(item4);
            itemsData.Items.Add(item5);
            itemsData.Items.Add(item6);
            itemsData.Items.Add(item7);
            itemsData.Items.Add(item8);
            itemsData.Items.Add(item9);

            List<Item> itemsAvailable10 = itemsData.UnlockedItemsAtLevel(10);
            Assert.AreEqual(itemsAvailable10.Count, 6);
            List<Item> itemsAvailable20 = itemsData.UnlockedItemsAtLevel(20);
            Assert.AreEqual(itemsAvailable20.Count, 10);
        }

        [Test]
        public void TestFindItem()
        {
            itemsData.Items.Clear();
            Item item0 = new Item();
            Item item1 = new Item();
            Item item2 = new Item();
            Item item3 = new Item();
            Item item4 = new Item();

            item0.Name = "Potion";
            item1.Name = "Great ball";
            item2.Name = "Revive";
            item3.Name = "Premier ball";
            item4.Name = "Razz Berry";
            itemsData.Items.Add(item0);
            itemsData.Items.Add(item1);
            itemsData.Items.Add(item2);
            itemsData.Items.Add(item3);
            itemsData.Items.Add(item4);

            Item itemFound = itemsData.FindItem("Premier ball");
            Assert.AreEqual(itemFound, item3);
            Item itemFound2 = itemsData.FindItem("Master ball");
            Assert.AreEqual(itemFound2, null);
        }

    }
}
