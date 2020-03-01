using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Assignment5.Data;
using System.IO;

namespace Assignment5.Test
{
    public class PokedexTest
    {
        string saveFile = null;
        string loadFile = null;
        string myDirPath;
        PokemonReader reader = new PokemonReader();
        Pokedex pokedex;

        [SetUp]
        public void Initialization()
        {
            myDirPath = System.AppContext.BaseDirectory;
            saveFile = Path.Combine(myDirPath, "pokeDexSaveFile.xml");
            loadFile = Path.Combine(myDirPath, "pokemon151.xml");
        }

        [Test]
        public void TestPokedexLoad()
        {
            try
            {
                pokedex = reader.Load(loadFile);
            }
            catch
            {
                Assert.IsTrue(false);
            }

        }

    }
}
