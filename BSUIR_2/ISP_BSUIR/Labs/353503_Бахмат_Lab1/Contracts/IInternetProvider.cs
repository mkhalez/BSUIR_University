using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using _353503_Бахмат_Lab1.Entites;

namespace _353503_Бахмат_Lab1.Contracts
{
    public interface IInternetProvider
    {
        void AddTariff(Tariff tariff);
        void RegisterUser(User user);
        void AddTrafficData(string userName, string tariffName, double trafficInMB);
        double GetTotalCostForUser(string userName);
        User GetUserWithHighestCost();
        double GetTotalPaymentsForTariff(string tariffName);
    }
}
