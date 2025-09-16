using _353503_Бахмат_Lab1.Collections;
using _353503_Бахмат_Lab1.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Бахмат_Lab1.Entites
{
    public class Provider : IInternetProvider
    {
        private MyCustomeCollection<Tariff> tariffs = new MyCustomeCollection<Tariff>();
        private MyCustomeCollection<User> users = new MyCustomeCollection<User>();

        public void AddTariff(Tariff tariff)
        {
            tariffs.Add(tariff);
        }

        public void RegisterUser(User user)
        {
            users.Add(user);
        }

        public void AddTrafficData(string userName, string tariffName, double trafficInMB)
        {
            var user = FindUserByName(userName);
            if (user != null)
            {
                user.AddTraffic(tariffName, trafficInMB);
            }
        }

        public double GetTotalCostForUser(string userName)
        {
            var user = FindUserByName(userName);
            if (user == null) return 0;

            double totalCost = 0;
            user.TrafficData.Reset();
            for (int i = 0; i < user.TrafficData.Count; i++)
            {
                var trafficData = user.TrafficData.GetCurrent();
                var tariff = FindTariffByName(trafficData.TariffName);
                if (tariff != null)
                {
                    totalCost += tariff.CostPerMB * trafficData.TrafficInMB;
                }
                user.TrafficData.Next();
            }

            return totalCost;
        }

        public User GetUserWithHighestCost()
        {
            User maxUser = null;
            double maxCost = 0;

            users.Reset();
            for (int i = 0; i < users.Count; i++)
            {
                var user = users.GetCurrent();
                double cost = GetTotalCostForUser(user.Name);
                if (cost > maxCost)
                {
                    maxCost = cost;
                    maxUser = user;
                }
                users.Next();
            }

            return maxUser;
        }

        public double GetTotalPaymentsForTariff(string tariffName)
        {
            double totalPayments = 0;
            users.Reset();
            for (int i = 0; i < users.Count; i++)
            {
                var user = users.GetCurrent();
                user.TrafficData.Reset();
                for (int j = 0; j < user.TrafficData.Count; j++)
                {
                    var trafficData = user.TrafficData.GetCurrent();
                    if (trafficData.TariffName == tariffName)
                    {
                        var tariff = FindTariffByName(tariffName);
                        if (tariff != null)
                        {
                            totalPayments += trafficData.TrafficInMB * tariff.CostPerMB;
                        }
                    }
                    user.TrafficData.Next();
                }
                users.Next();
            }

            return totalPayments;
        }

        private Tariff FindTariffByName(string name)
        {
            tariffs.Reset();
            for (int i = 0; i < tariffs.Count; i++)
            {
                var tariff = tariffs.GetCurrent();
                if (tariff.Name == name) return tariff;
                tariffs.Next();
            }
            return null;
        }

        private User FindUserByName(string name)
        {
            users.Reset();
            for (int i = 0; i < users.Count; i++)
            {
                var user = users.GetCurrent();
                if (user.Name == name) return user;
                users.Next();
            }
            return null;
        }
    }
}
