using _353503_Бахмат_Lab3.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _353503_Бахмат_Lab3.Entites
{
    public class Provider : IInternetProvider
    {
        private List<User> users = new List<User>();
        private Dictionary<string, Tariff> tariffs = new Dictionary<string, Tariff>();

        public event Action<List<User>> ChangeUsersCollection;
        public event Action<Dictionary<string, Tariff>> ChangeTariffsServisecCollection;

        public void RegisterUser(User user)
        {
            users.Add(user);
            ChangeUsersCollection(users);
        }

        public void AddTariff(Tariff tariff)
        {
            tariffs[tariff.Name] = tariff;
            ChangeTariffsServisecCollection(tariffs);
        }

        public void AddTrafficData(string userName, string tariffName, double trafficInMB)
        {
            var user = FindUserByName(userName);
            var tariff = FindTariffByName(tariffName);
            if (user != null && tariff != null)
            {
                user.AddTrafic(tariff, trafficInMB);
            }
        }

        private User FindUserByName(string userName)
        {
            return users.FirstOrDefault(user => user.Name == userName);
        }

        private Tariff FindTariffByName(string tariffName)
        {
            tariffs.TryGetValue(tariffName, out var tariff);
            return tariff;
        }
        public List<string> GetTariffNamesSortedByCost()
        {
            return tariffs.Values.OrderBy(t => t.CostPerMB).Select(t => t.Name).ToList();
        }
        public double GetTotalTrafficCost()
        {
            return users.SelectMany(u => u.TraficData)
                        .Sum(td => td.TrafficInMB * td.Tariff.CostPerMB);
        }
        public string GetUserWithMaxTotalCost()
        {
            return users.OrderByDescending(u => u.TraficData.Sum(td => td.TrafficInMB * td.Tariff.CostPerMB))
                        .FirstOrDefault()?.Name;
        }
        public int GetUsersCountWithCostGreaterThan(double amount)
        {
            return users.Aggregate(0, (count, user) =>
            {
                double totalCost = user.TraficData.Sum(td => td.TrafficInMB * td.Tariff.CostPerMB);
                return totalCost > amount ? count + 1 : count;
            });
        }
        public Dictionary<string, int> GetUserCountByTariff()
        {
            return users.SelectMany(u => u.TraficData)
                        .GroupBy(td => td.Tariff.Name)
                        .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}
