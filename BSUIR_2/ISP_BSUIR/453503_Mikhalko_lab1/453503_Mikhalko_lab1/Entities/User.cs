using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _453503_Mikhalko_lab1.Collections;

namespace _453503_Mikhalko_lab1.Entities
{
    internal class User
    {
        public string Name { get; set; }
        public MyCustomCollection<Tariff> Tariffs = new MyCustomCollection<Tariff>();
        public User(string name) 
        { 
            this.Name = name; 
        }

        public void AddTariff(Tariff tariff)
        {
            Tariffs.Add(tariff);
        }

        public static bool operator ==(User a, User b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            if (a.Name == b.Name) return true;
            else return false;
        }
        public static bool operator !=(User a, User b)
        {
            return !(a == b);
        }
    }
}
