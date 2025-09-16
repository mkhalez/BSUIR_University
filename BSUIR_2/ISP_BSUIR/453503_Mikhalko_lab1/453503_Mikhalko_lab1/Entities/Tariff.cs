using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace _453503_Mikhalko_lab1.Entities
{
    internal class Tariff : IAdditionOperators<Tariff, Tariff, Tariff>
    {
        public Tariff() { }

        public double Volume { get; set; }
        public string Direction { get; set; }

        public double Cost { get; set; }

        public Tariff(double volume, string directionName, double cost)
        {
            Volume = volume;
            Direction = directionName;
            Cost = cost;
        }

        public static bool operator ==(Tariff a, Tariff b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            if (a.Volume == b.Volume && a.Direction == b.Direction && a.Cost == b.Cost)
                return true;
            else return false;
        }

        public static bool operator !=(Tariff a, Tariff b)
        {
            return !(a == b);
        }

        public static Tariff operator +(Tariff left, Tariff right)
        {
            return new Tariff(left.Volume + right.Volume, 
                left.Direction + " " + right.Direction, left.Cost + right.Cost);
        }
    }
}
