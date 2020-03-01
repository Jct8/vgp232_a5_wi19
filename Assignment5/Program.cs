using Assignment5.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Assignment 5 - Pokemon Edition");

            PokemonReader reader = new PokemonReader();
            Pokedex pokedex = reader.Load("pokemon151.xml");

            // List out all the pokemons loaded
            foreach (Pokemon pokemon in pokedex.Pokemons)
            {
                Console.WriteLine(pokemon.Name);
            }

            // TODO: Add a pokemon bag with 2 bulbsaur, 1 charlizard, 1 mew and 1 dragonite
            // and save it out and load it back and list it out.
            PokemonBag pokemonBag = new PokemonBag();
            pokemonBag.Pokemons.Add(pokedex.GetPokemonByName("Bulbasaur").Index);
            pokemonBag.Pokemons.Add(pokedex.GetPokemonByName("Charizard").Index);
            pokemonBag.Pokemons.Add(pokedex.GetPokemonByName("Mew").Index);
            pokemonBag.Pokemons.Add(pokedex.GetPokemonByName("Dragonite").Index);
            pokemonBag.Save("Test.xml");
            pokemonBag.Pokemons.Clear();
            pokemonBag.Load("Test.xml");
            foreach (var pokemon in pokemonBag.Pokemons)
            {
                Console.WriteLine(pokedex.GetPokemonByIndex(pokemon).Name);
            }

            // TODO: Add item reader and print out all the items
            ItemsData itemsData = ItemReader.Load("itemData.xml");
            foreach (var item in itemsData.Items)
            {
                Console.WriteLine(item.Name);
            }

            // TODO: hook up item data to display with the inventory

            var source = new Inventory()
            {
                ItemToQuantity =
                    new Dictionary<object, object> { /*{ "Poke ball", 10 }, { "Potion", 10 }*/ }
            };
            foreach (var item in itemsData.Items)
            {
                source.ItemToQuantity.Add(item.Name, 10);
            }

            string inventoryFile = "inventory.xml";
            Inventory inventory = new Inventory();
            inventory = inventory.Deserialize(inventoryFile);
            foreach (var item in inventory.Items)
            {
                Console.WriteLine(item.Value);
            }

            Console.ReadKey();
        }
    }
}
