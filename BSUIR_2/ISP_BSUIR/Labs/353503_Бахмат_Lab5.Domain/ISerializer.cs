using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Бахмат_Lab5.Domain
{
    public interface ISerializer
    {
        IEnumerable<FilmCharacter> DeSerializeByLINQ(string fileName);
        IEnumerable<FilmCharacter> DeSerializeXML(string fileName);
        IEnumerable<FilmCharacter> DeSerializeJSON(string fileName);
        void SerializeByLINQ(IEnumerable<FilmCharacter> filmCharacters, string fileName);
        void SerializeXML(IEnumerable<FilmCharacter> filmCharacters, string fileName);
        void SerializeJSON(IEnumerable<FilmCharacter> filmCharacters, string fileName);
    }
}
