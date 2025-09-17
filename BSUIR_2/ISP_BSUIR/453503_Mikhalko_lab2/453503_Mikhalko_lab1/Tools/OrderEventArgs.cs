using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _453503_Mikhalko_lab1.Tools
{
    internal class OrderEventArgs : EventArgs
    {
        public string NameOfUser { get; }
        public string Description { get; }
        public double Volume { get; }
        public double Cost { get; }

        public OrderEventArgs(string NameOfUser, string Description, 
            double Volume, double Cost)
        {
            this.NameOfUser = NameOfUser;
            this.Description = Description;
            this.Volume = Volume;
            this.Cost = Cost;
        }

        public string ToString()
        {
            return $"{NameOfUser} orders cargo transportation:\n" +
                $" description: {Description}, volume: {Volume}, cost: {Cost}";
        }
    }
}
