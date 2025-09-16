using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Бахмат_Lab5.Domain
{
    [Serializable]
    public class Actor : IEquatable<Actor>
    {
        public int Id { get; set; }
        public string Name { get; set; }           
        public DateTime BirthDate { get; set; }  
        public string Nationality { get; set; }

        public bool Equals(Actor other)
        {
            if (other == null) return false;
            return Id == other.Id && Name == other.Name &&
                   BirthDate == other.BirthDate && Nationality == other.Nationality;
        }

        public override bool Equals(object obj) => Equals(obj as Actor);
        public override int GetHashCode() => HashCode.Combine(Id, Name, BirthDate, Nationality);
    }
}
