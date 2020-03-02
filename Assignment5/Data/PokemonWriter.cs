using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Data
{
    public class PokemonWriter
    {
        XmlSerializer serializer;

        /// <summary>
        /// Construtor
        /// </summary>
        public PokemonWriter()
        {
            serializer = new XmlSerializer(typeof(Pokedex));
        }

        public void Save(string fileName, Pokedex pokedex)
        {
            using (var streamWriter = new StreamWriter(fileName))
            {
                serializer.Serialize(streamWriter, pokedex);
            }
        }

    }
}
