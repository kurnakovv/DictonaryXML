using DictonaryXML.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DictonaryXML.Domain
{
    public class SerializeDeserializeXML
    {
        public void SerializeXML(Words words)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Words));

            using (var fs = new FileStream("Words.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, words);
            }
        }

        public Words DeserializeXML()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Words));

            using (var fs = new FileStream("Words.xml", FileMode.OpenOrCreate))
            {
                return (Words)xmlSerializer.Deserialize(fs);
            }
        }
    }
}
