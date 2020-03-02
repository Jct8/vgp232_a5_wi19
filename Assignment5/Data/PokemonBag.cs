using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    /// <summary>
    /// Contains all the pokemons caught based listing them with their index
    /// </summary>
    public class PokemonBag
    {
        [XmlArray]
        public List<int> Pokemons { get; set; }

        public PokemonBag()
        {
            Pokemons = new List<int>();
        }

        public void Save(string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<int>));
                xmlSerializer.Serialize(streamWriter, Pokemons);
            }
        }

        public void Load(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new Exception(string.Format("{0} does not exist", filepath));
            }

            using (var file = new StreamReader(filepath))
            {
                var serializer = new XmlSerializer(typeof(List<int>));
                try
                {
                    Pokemons.Clear();
                    Pokemons.AddRange(serializer.Deserialize(file) as List<int>);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Unable to deserialize the {0} due to following: {1}",
                        filepath, ex.Message));
                }
            }
        }
    }
}
