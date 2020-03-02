using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    [XmlRoot("Pokedex")]
    public class Pokedex
    {
        [XmlArray("Pokemons")]
        [XmlArrayItem("Pokemon")]
        public List<Pokemon> Pokemons { get; set; }

        public Pokedex()
        {
            Pokemons = new List<Pokemon>();
        }

        public Pokemon GetPokemonByIndex(int index)
        {
            return Pokemons.FirstOrDefault(x => x.Index == index);
        }

        public Pokemon GetPokemonByName(string name)
        {
            return Pokemons.FirstOrDefault(x => x.Name == name);
        }

        public List<Pokemon> GetPokemonsOfType(string type)
        {
            // Note to check both Type1 and Type2
            return Pokemons.Where(x => x.Type1 == type || x.Type2 == type).ToList();
        }

        public Pokemon GetHighestHPPokemon()
        {
            return Pokemons.OrderByDescending(x => x.HP).First();
        }

        public Pokemon GetHighestAttackPokemon()
        {
            return Pokemons.OrderByDescending(x => x.Attack).First();
        }

        public Pokemon GetHighestDefensePokemon()
        {
            return Pokemons.OrderByDescending(x => x.Defense).First();
        }

        public Pokemon GetHighestMaxCPPokemon()
        {
            return Pokemons.OrderByDescending(x => x.MaxCP).First();
        }

    }
}
