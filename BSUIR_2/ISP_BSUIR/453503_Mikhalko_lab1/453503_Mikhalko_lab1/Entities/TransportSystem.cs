using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using _453503_Mikhalko_lab1.Tools;
using _453503_Mikhalko_lab1.Collections;
using _453503_Mikhalko_lab1.Contracts;

namespace _453503_Mikhalko_lab1.Entities
{
    internal class TransportSystem : CargoTransportation
    {
        public MyCustomCollection<Tariff> tariffs = new MyCustomCollection<Tariff>();
        public MyCustomCollection<User> users = new MyCustomCollection<User>();

        private bool IsNewTariffs(Tariff tariff)
        {
            tariffs.Reset();
            for (int i = 0; i < tariffs.Count; i++)
            {
                if (tariffs[i] == tariff) return false;
            }
            return true;
        }

        private bool IsNewUsers(User userName)
        {
            users.Reset();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i] == userName) return false;
            }
            return true;
        }
        public bool CheckInUserName(string userName)
        {
            users.Reset();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Name == userName) return true;
            }
            return false;
        }
        public bool CheckInTariffByDV(string direction, double volume, double cost)
        {
            tariffs.Reset();
            for (int i = 0; i < tariffs.Count; i++)
            {
                if (tariffs[i].Volume == volume && tariffs[i].Direction == direction && tariffs[i].Cost == cost)
                    return true;
            }
            return false;
        }



        public void AddTariff(Tariff tariff)
        {
            if (!IsNewTariffs(tariff)) return;

            tariffs.Add(tariff);
        }

        public void RegisterUser(User userName)
        {
            if (!IsNewUsers(userName)) return;

            users.Add(userName);
        }

        

        
        public void Order(string userName, string direction, double volume, double cost)
        {
            if (!CheckInUserName(userName) || !CheckInTariffByDV(direction, volume, cost)) 
                return;

            users.Reset();
            while(users.Current().Name != userName) users.MoveNext();

            tariffs.Reset();
            while (tariffs.Current().Direction != direction || tariffs.Current().Volume != volume || tariffs.Current().Cost != cost)
                tariffs.MoveNext();

            users.Current().AddTariff(tariffs.Current());
        }

        public double CostOfOrderOfUser(string userName)
        {
            if (!CheckInUserName(userName)) return 0;

            users.Reset();
            while (users.Current() != null && users.Current().Name != userName)
            {
                users.MoveNext();
            }


            if (users.Current() == null) return 0;

            double totalCost = 0;
            
            for(int i = 0; i < users.Current().Tariffs.Count; i++)
            {
                totalCost += users.Current().Tariffs[i].Cost;
            }

            return totalCost;
        }

        public double GetTotalCostInOneDirection(string directionName)
        {
            double totalCost = 0;
            for (int i = 0; i < users.Count; i++)
            {
                for (int j = 0; j < users[i].Tariffs.Count; j++)
                {
                    if (users[i].Tariffs[j].Direction == directionName)
                        totalCost += users[i].Tariffs[j].Cost;
                }
            }
            return totalCost;
        }
        public double GetTotalCostAllOrders()
        {
            double sum = 0;
            foreach (var user in users)
            {
                User currentUser = (User)user;
                Tariff totalTariff = currentUser.Tariffs.Sum();
                sum += totalTariff.Cost;
            }
            return sum;
        }
    }
}
