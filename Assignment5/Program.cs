using Assignment5.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // TODO: Add a pokemon bag with 2 bulbsaur, 1 charlizard, 1 mew and 1 dragonite
            // and save it out and load it back and list it out.
            PokemonBag pokemonBag = new PokemonBag();
            pokemonBag.Pokemons.Add(pokedex.GetPokemonByName("Bulbasaur").Index);
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

            Console.ReadKey();
        }
    }
}
