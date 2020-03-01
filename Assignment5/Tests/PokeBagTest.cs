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
    public class PokeBagTest
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
            saveFile = Path.Combine(myDirPath, "saveFile.xml");
            loadFile = Path.Combine(myDirPath, "Test.xml");

            pokedex = reader.Load(Path.Combine(myDirPath, "pokemon151.xml"));
        }

        [Test]
        public void TestPokeBagLoad()
        {
            PokemonBag pokeBag = new PokemonBag();

            try
            {
                pokeBag.Load(loadFile);
            }
            catch
            {
                Assert.IsTrue(false);
            }

        }

        [Test]
        public void SavePokeBagLoad()
        {
            PokemonBag pokemonBag = new PokemonBag();
            pokemonBag.Pokemons.Add(pokedex.GetPokemonByName("Bulbasaur").Index);
            pokemonBag.Pokemons.Add(pokedex.GetPokemonByName("Charizard").Index);
            pokemonBag.Pokemons.Add(pokedex.GetPokemonByName("Mew").Index);
            pokemonBag.Pokemons.Add(pokedex.GetPokemonByName("Dragonite").Index);
            pokemonBag.Save(saveFile);
            FileAssert.Exists(saveFile);
        }
    }
}
