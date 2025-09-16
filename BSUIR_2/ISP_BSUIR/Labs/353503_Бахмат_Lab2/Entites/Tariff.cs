using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Бахмат_Lab2.Entites
{
    public class Tariff
    {
        public string Name { get; set; }
        public double CostPerMB { get; set; }

        public Tariff(string name, double costPerMB)
        {
            Name = name;
            CostPerMB = costPerMB;
        }
    }
}
