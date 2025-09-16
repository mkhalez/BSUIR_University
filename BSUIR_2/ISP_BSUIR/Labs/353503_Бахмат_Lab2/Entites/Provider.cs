using _353503_Бахмат_Lab2.Collections;
using _353503_Бахмат_Lab2.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Бахмат_Lab2.Entites
{
    public class Provider : IInternetProvider
    {
        private MyCustomeCollection<Tariff> tariffs = new MyCustomeCollection<Tariff>();
        private MyCustomeCollection<User> users = new MyCustomeCollection<User>();
        public event Action<MyCustomeCollection<User>> ChangeUsersCollection;
        public event Action<MyCustomeCollection<Tariff>> ChangeTariffsServisecCollection;
        public void AddTariff(Tariff tariff)
        {
            tariffs.Add(tariff);
            ChangeTariffsServisecCollection(tariffs);
        }

        public void RegisterUser(User user)
        {
            users.Add(user);
            ChangeUsersCollection(users);
        }

        public void AddTrafficData(string userName, string tariffName, double trafficInMB)
        {
            var user = FindUserByName(userName);
            var tariff = FindTariffByName(tariffName);
            if (user != null && tariff != null)
            {
                user.AddTraffic(tariff, trafficInMB);
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
                totalCost += trafficData.TrafficInMB * trafficData.Tariff.CostPerMB;
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
            var tariff = FindTariffByName(tariffName);
            if ((tariff is not null))
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
                        if (trafficData.Tariff == tariff)
                        {
                            totalPayments += trafficData.TrafficInMB * tariff.CostPerMB;
                        }
                        user.TrafficData.Next();
                    }
                    users.Next();
                }

                return totalPayments;
            }
            return -1; 
        }

        private User FindUserByName(string userName)
        {
            users.Reset();
            for (int i = 0; i < users.Count; i++)
            {
                var user = users.GetCurrent();
                if (user.Name == userName)
                {
                    return user;
                }
                users.Next();
            }

            return null;
        }

        private Tariff FindTariffByName(string tariffName)
        {
            tariffs.Reset();
            for (int i = 0; i < tariffs.Count; i++)
            {
                var tariff = tariffs.GetCurrent();
                if (tariff.Name == tariffName)
                {
                    return tariff;
                }
                tariffs.Next();
            }

            return null;
        }

    }
}
