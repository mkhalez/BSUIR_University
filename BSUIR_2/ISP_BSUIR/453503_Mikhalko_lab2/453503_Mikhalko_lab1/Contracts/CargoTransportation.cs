using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using _453503_Mikhalko_lab2.Entities;

namespace _453503_Mikhalko_lab2.Contracts
{
    internal interface CargoTransportation
    {
        void AddTariff(Tariff tariff);
        void RegisterUser(User userName);
        void Order(string userName, string direction, double volume, double cost);
        double GetTotalCostAllOrders();
        double GetTotalCostInOneDirection(string directionName);
    }
}
