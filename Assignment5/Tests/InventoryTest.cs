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
    public class InventoryTest
    {
        string saveFile = null;
        string loadFile = null;
        string myDirPath;
        Inventory inventory;

        [SetUp]
        public void Initialization()
        {
            myDirPath = System.AppContext.BaseDirectory;
            saveFile = Path.Combine(myDirPath, "InventoryTest.xml");
            loadFile = Path.Combine(myDirPath, "Inventory.xml");

            inventory = new Inventory();
            inventory.ItemToQuantity =
                    new Dictionary<object, object> { { "Poke ball", 10 }, { "Potion", 10 }
                        , { "Master Ball", 10 } , { "Hyper Potion", 10 } };
            inventory.Serialize(loadFile);
        }
        [Test]
        public void TestInventoryLoad()
        {
            try
            {
                inventory = inventory.Deserialize(loadFile);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [Test]
        public void SaveInventory()
        {
            inventory = new Inventory();
            inventory = inventory.Deserialize(loadFile);
            inventory.Serialize(saveFile);
            FileAssert.Exists(saveFile);
        }

        [Test]
        public void SaveLoadInventoryTest()
        {
            inventory = new Inventory();
            inventory = inventory.Deserialize(loadFile);

            int currentCount = inventory.Items.Count;

            inventory.Items.Add(new Entry("Great ball", 10));
            inventory.Items.Add(new Entry("Ultra ball", 10));

            inventory.Serialize(saveFile);
            FileAssert.Exists(saveFile);

            inventory.Items.Clear();
            try
            {
                inventory = inventory.Deserialize(saveFile);
            }
            catch
            {
                Assert.IsTrue(false);
            }
            Assert.AreEqual(inventory.Items.Count, currentCount + 2);
        }

    }
}
