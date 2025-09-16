using _353503_Бахмат_Lab3.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Бахмат_Lab3.Contracts
{
    public interface IInternetProvider
    {
        void RegisterUser(User user);
        void AddTariff(Tariff tariff);
        List<string> GetTariffNamesSortedByCost();
        double GetTotalTrafficCost();
        string GetUserWithMaxTotalCost();
        int GetUsersCountWithCostGreaterThan(double amount);
        Dictionary<string, int> GetUserCountByTariff();
    }
}
