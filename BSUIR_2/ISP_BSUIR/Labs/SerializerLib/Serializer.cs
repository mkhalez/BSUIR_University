using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Xml.Linq;
using _353503_Бахмат_Lab5.Domain;
using System.Text.Json;

namespace SerializerLib
{
    public class Serializer : ISerializer
    {
        public void SerializeByLINQ(IEnumerable<FilmCharacter> characters, string fileName)
        {
            var doc = new XDocument(
                new XElement("FilmCharacters",
                    characters.Select(character =>
                        new XElement("FilmCharacter",
                            new XAttribute("Name", character.Name),
                            new XElement("MovieTitle", character.MovieTitle),
                            new XElement("Actor",
                                new XAttribute("Id", character.Actor.Id),
                                new XElement("Name", character.Actor.Name),
                                new XElement("BirthDate", character.Actor.BirthDate.ToString("yyyy-MM-dd")),
                                new XElement("Nationality", character.Actor.Nationality)
                            )
                        )
                    )
                )
            );
            doc.Save($"{fileName}.xml");
        }

        public IEnumerable<FilmCharacter> DeSerializeByLINQ(string fileName)
        {
            var doc = XDocument.Load($"{fileName}.xml");
            return doc.Root.Elements("FilmCharacter").Select(el => new FilmCharacter
            {
                Name = el.Attribute("Name").Value,
                MovieTitle = el.Element("MovieTitle").Value,
                Actor = new Actor
                {
                    Id = int.Parse(el.Element("Actor").Attribute("Id").Value),
                    Name = el.Element("Actor").Element("Name").Value,
                    BirthDate = DateTime.Parse(el.Element("Actor").Element("BirthDate").Value),
                    Nationality = el.Element("Actor").Element("Nationality").Value
                }
            }).ToList();
        }

        public void SerializeXML(IEnumerable<FilmCharacter> characters, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<FilmCharacter>));
            using var stream = File.Create($"{fileName}.xml");
            serializer.Serialize(stream, characters.ToList());
        }

        public IEnumerable<FilmCharacter> DeSerializeXML(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<FilmCharacter>));
            using var stream = File.OpenRead($"{fileName}.xml");
            return (List<FilmCharacter>)serializer.Deserialize(stream);
        }
        public void SerializeJSON(IEnumerable<FilmCharacter> characters, string fileName)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(characters, options);
            File.WriteAllText($"{fileName}.json", jsonString);
        }


        public IEnumerable<FilmCharacter> DeSerializeJSON(string fileName)
        {
            var jsonString = File.ReadAllText($"{fileName}.json");
            return JsonSerializer.Deserialize<List<FilmCharacter>>(jsonString);
        }
    }
}

