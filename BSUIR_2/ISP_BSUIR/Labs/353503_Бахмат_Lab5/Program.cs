using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using _353503_Бахмат_Lab5.Domain;
using SerializerLib;
class Program
{
    static void Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string jsonFileName = configuration.GetSection("353503_Бахмат_Lab5").GetSection("FileName").Value + ".json";
        string xmlFileName = configuration.GetSection("353503_Бахмат_Lab5").GetSection("FileName").Value + ".xml";
        string linqFileName = configuration.GetSection("353503_Бахмат_Lab5").GetSection("FileName").Value + ".linq";

        var filmCharacters = new List<FilmCharacter>
        {
            new FilmCharacter
            {
                Name = "Harry Potter",
                MovieTitle = "Harry Potter and the Philosopher's Stone",
                Actor = new Actor
                {
                    Id = 1,
                    Name = "Daniel Radcliffe",
                    BirthDate = new DateTime(1989, 7, 23),
                    Nationality = "British"
                }
            },
            new FilmCharacter
            {
                Name = "Hermione Granger",
                MovieTitle = "Harry Potter and the Philosopher's Stone",
                Actor = new Actor
                {
                    Id = 2,
                    Name = "Emma Watson",
                    BirthDate = new DateTime(1990, 4, 15),
                    Nationality = "British"
                }
            },
            new FilmCharacter
            {
               Name = "Ron Weasley",
                MovieTitle = "Harry Potter and the Philosopher's Stone",
                Actor = new Actor
                {
                    Id = 3,
                    Name = "Rupert Grint",
                    BirthDate = new DateTime(1988, 8, 24),
                Nationality = "British"
                }
            },
            new FilmCharacter
            {
                Name = "Albus Dumbledore",
                MovieTitle = "Harry Potter and the Philosopher's Stone",
                Actor = new Actor
                {
                    Id = 4,
                    Name = "Richard Harris",
                    BirthDate = new DateTime(1930, 10, 1),
                    Nationality = "Irish"
                }
            },
            new FilmCharacter
            {
                Name = "Severus Snape",
                MovieTitle = "Harry Potter and the Philosopher's Stone",
                Actor = new Actor
                {
                    Id = 5,
                    Name = "Alan Rickman",
                    BirthDate = new DateTime(1946, 2, 21),
                    Nationality = "British"
                }
            } 
        };


        ISerializer serializer = new Serializer();
        serializer.SerializeJSON(filmCharacters, jsonFileName);
        serializer.SerializeXML(filmCharacters, xmlFileName);
        serializer.SerializeByLINQ(filmCharacters, linqFileName);

        var jsonCharacters = serializer.DeSerializeJSON(jsonFileName);
        var xmlCharacters = serializer.DeSerializeXML(xmlFileName);
        var linqCharacters = serializer.DeSerializeByLINQ(linqFileName);

        bool linqMatch = filmCharacters.SequenceEqual(linqCharacters);
        bool xmlMatch = filmCharacters.SequenceEqual(xmlCharacters);
        bool jsonMatch = filmCharacters.SequenceEqual(jsonCharacters);

        Console.WriteLine($"LINQ Match: {linqMatch}");
        Console.WriteLine($"XML Match: {xmlMatch}");
        Console.WriteLine($"JSON Match: {jsonMatch}");
    }
}
