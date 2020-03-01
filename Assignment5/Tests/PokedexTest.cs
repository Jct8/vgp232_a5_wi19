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

        [Test]
        public void SavePokedex()
        {
            PokemonWriter pokemonWriter = new PokemonWriter();
            pokedex = new Pokedex();
            pokedex = reader.Load(loadFile);
            pokemonWriter.Save(saveFile,pokedex);
            FileAssert.Exists(saveFile);
        }

        [Test]
        public void SaveLoadPokedexTest()
        {
            PokemonWriter pokemonWriter = new PokemonWriter();
            pokedex = new Pokedex();
            pokedex = reader.Load(loadFile);

            int currentCount = pokedex.Pokemons.Count;

            Pokemon pokemon = new Pokemon();
            pokemon.Attack = 10;
            pokemon.Defense = 10;
            pokemon.HP = 10;
            pokemon.Index = 6545;
            pokemon.MaxCP = 10;
            pokemon.Type1 = "a";

            Pokemon pokemon2 = new Pokemon();
            pokemon2.Attack = 10;
            pokemon2.Defense = 10;
            pokemon2.HP = 10;
            pokemon2.Index = 6545;
            pokemon2.MaxCP = 10;
            pokemon2.Type1 = "a";

            pokedex.Pokemons.Add(pokemon);
            pokedex.Pokemons.Add(pokemon2);

            pokemonWriter.Save(saveFile,pokedex);
            FileAssert.Exists(saveFile);

            pokedex.Pokemons.Clear();
            try
            {
                pokedex = reader.Load(saveFile);
            }
            catch
            {
                Assert.IsTrue(false);
            }
            Assert.AreEqual(pokedex.Pokemons.Count, currentCount+2);
        }

    }
}
