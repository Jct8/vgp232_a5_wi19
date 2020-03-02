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
    public class PokedexTest
    {
        string saveFile = null;
        string loadFile = null;
        string myDirPath;
        PokemonReader reader = new PokemonReader();
        Pokedex pokedex = new Pokedex();

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

        [Test]
        public void GetPokemonByNameTest()
        {
            pokedex.Pokemons.Clear();
            Pokemon pokemon1 = new Pokemon();
            Pokemon pokemon2 = new Pokemon();
            Pokemon pokemon3 = new Pokemon();
            Pokemon pokemon4 = new Pokemon();
            Pokemon pokemon5 = new Pokemon();

            pokemon1.Name = "Charizard";
            pokemon2.Name = "Weedle";
            pokemon3.Name = "Spearow";
            pokemon4.Name = "Mew";
            pokemon5.Name = "Magikarp";
            
            pokedex.Pokemons.Add(pokemon1);
            pokedex.Pokemons.Add(pokemon2);
            pokedex.Pokemons.Add(pokemon3);
            pokedex.Pokemons.Add(pokemon4);
            pokedex.Pokemons.Add(pokemon5);

            Pokemon pokemon = pokedex.GetPokemonByName("Spearow");
            Assert.AreEqual(pokemon3, pokemon);
            pokemon = pokedex.GetPokemonByName("Charizard");
            Assert.AreEqual(pokemon1, pokemon);
            pokemon = pokedex.GetPokemonByName("dsfadsfa");
            Assert.AreEqual(null, pokemon);
        }

        [Test]
        public void GetPokemonByIndexTest()
        {
            pokedex.Pokemons.Clear();
            Pokemon pokemon1 = new Pokemon();
            Pokemon pokemon2 = new Pokemon();
            Pokemon pokemon3 = new Pokemon();
            Pokemon pokemon4 = new Pokemon();
            Pokemon pokemon5 = new Pokemon();

            pokemon1.Index = 123;
            pokemon2.Index = 43;
            pokemon3.Index = 48;
            pokemon4.Index = 1;
            pokemon5.Index = 88;

            pokedex.Pokemons.Add(pokemon1);
            pokedex.Pokemons.Add(pokemon2);
            pokedex.Pokemons.Add(pokemon3);
            pokedex.Pokemons.Add(pokemon4);
            pokedex.Pokemons.Add(pokemon5);

            Pokemon pokemon = pokedex.GetPokemonByIndex(88);
            Assert.AreEqual(pokemon5, pokemon);
            pokemon = pokedex.GetPokemonByIndex(43);
            Assert.AreEqual(pokemon2, pokemon);
            pokemon = pokedex.GetPokemonByIndex(654654);
            Assert.AreEqual(null, pokemon);
        }

        [Test]
        public void GetPokemonByType()
        {
            pokedex.Pokemons.Clear();
            Pokemon pokemon1 = new Pokemon();
            Pokemon pokemon2 = new Pokemon();
            Pokemon pokemon3 = new Pokemon();
            Pokemon pokemon4 = new Pokemon();
            Pokemon pokemon5 = new Pokemon();

            pokemon1.Type1 = "Water";
            pokemon1.Type2 = "Poison";

            pokemon2.Type1 = "Water";
            pokemon2.Type2 = "Ghost";

            pokemon3.Type1 = "Grass";
            pokemon3.Type2 = "Dragon";

            pokemon4.Type1 = "Poison";
            pokemon4.Type2 = "Flying";

            pokemon5.Type1 = "Poison";
            pokemon5.Type2 = "Ghost";

            pokedex.Pokemons.Add(pokemon1);
            pokedex.Pokemons.Add(pokemon2);
            pokedex.Pokemons.Add(pokemon3);
            pokedex.Pokemons.Add(pokemon4);
            pokedex.Pokemons.Add(pokemon5);

            List<Pokemon> pokemons = pokedex.GetPokemonsOfType("Poison");
            Assert.AreEqual(pokemons.Count, 3);
            pokemons = pokedex.GetPokemonsOfType("Grass");
            Assert.AreEqual(pokemons.Count, 1);
            pokemons = pokedex.GetPokemonsOfType("Rock");
            Assert.AreEqual(pokemons.Count, 0);

        }

        [Test]
        public void GetHighestHPPokemon()
        {
            pokedex.Pokemons.Clear();
            Pokemon pokemon1 = new Pokemon();
            Pokemon pokemon2 = new Pokemon();
            Pokemon pokemon3 = new Pokemon();
            Pokemon pokemon4 = new Pokemon();
            Pokemon pokemon5 = new Pokemon();

            pokemon1.HP = 10;
            pokemon2.HP = 5;
            pokemon3.HP = 30;
            pokemon4.HP = 41;
            pokemon5.HP = 20;

            pokedex.Pokemons.Add(pokemon1);
            pokedex.Pokemons.Add(pokemon2);
            pokedex.Pokemons.Add(pokemon3);
            pokedex.Pokemons.Add(pokemon4);
            pokedex.Pokemons.Add(pokemon5);

            Pokemon highestPokemon = pokedex.GetHighestHPPokemon();
            Assert.AreEqual(pokemon4, highestPokemon);
        }

        [Test]
        public void GetHighestAttackPokemon()
        {
            pokedex.Pokemons.Clear();
            Pokemon pokemon1 = new Pokemon();
            Pokemon pokemon2 = new Pokemon();
            Pokemon pokemon3 = new Pokemon();
            Pokemon pokemon4 = new Pokemon();
            Pokemon pokemon5 = new Pokemon();

            pokemon1.Attack = 10;
            pokemon2.Attack = 51;
            pokemon3.Attack = 93;
            pokemon4.Attack = 21;
            pokemon5.Attack = 10;

            pokedex.Pokemons.Add(pokemon1);
            pokedex.Pokemons.Add(pokemon2);
            pokedex.Pokemons.Add(pokemon3);
            pokedex.Pokemons.Add(pokemon4);
            pokedex.Pokemons.Add(pokemon5);

            Pokemon highestPokemon = pokedex.GetHighestAttackPokemon();
            Assert.AreEqual(pokemon3, highestPokemon);
        }
        [Test]
        public void GetHighestDefensePokemon()
        {
            pokedex.Pokemons.Clear();
            Pokemon pokemon1 = new Pokemon();
            Pokemon pokemon2 = new Pokemon();
            Pokemon pokemon3 = new Pokemon();
            Pokemon pokemon4 = new Pokemon();
            Pokemon pokemon5 = new Pokemon();

            pokemon1.Defense = 1000;
            pokemon2.Defense = 521;
            pokemon3.Defense = 3;
            pokemon4.Defense = 221;
            pokemon5.Defense = 110;

            pokedex.Pokemons.Add(pokemon1);
            pokedex.Pokemons.Add(pokemon2);
            pokedex.Pokemons.Add(pokemon3);
            pokedex.Pokemons.Add(pokemon4);
            pokedex.Pokemons.Add(pokemon5);

            Pokemon highestPokemon = pokedex.GetHighestDefensePokemon();
            Assert.AreEqual(pokemon1, highestPokemon);
        }

        [Test]
        public void GetHighestMaxCPPokemon()
        {
            pokedex.Pokemons.Clear();
            Pokemon pokemon1 = new Pokemon();
            Pokemon pokemon2 = new Pokemon();
            Pokemon pokemon3 = new Pokemon();
            Pokemon pokemon4 = new Pokemon();
            Pokemon pokemon5 = new Pokemon();

            pokemon1.MaxCP = 100;
            pokemon2.MaxCP = 21;
            pokemon3.MaxCP = 312;
            pokemon4.MaxCP = 1221;
            pokemon5.MaxCP = 4110;

            pokedex.Pokemons.Add(pokemon1);
            pokedex.Pokemons.Add(pokemon2);
            pokedex.Pokemons.Add(pokemon3);
            pokedex.Pokemons.Add(pokemon4);
            pokedex.Pokemons.Add(pokemon5);

            Pokemon highestPokemon = pokedex.GetHighestMaxCPPokemon();
            Assert.AreEqual(pokemon5, highestPokemon);
        }

    }
}
