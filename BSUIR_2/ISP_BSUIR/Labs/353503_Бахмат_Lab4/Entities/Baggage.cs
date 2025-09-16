using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Бахмат_Lab4.Entities
{
    public class Baggage
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public bool IsOverweight { get; set; }

        public Baggage(string name, int weight, bool isOverweight)
        {
            Name = name;
            Weight = weight;
            IsOverweight = isOverweight;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Weight: {Weight}, IsOverweight: {IsOverweight}";
        }
    }
}
