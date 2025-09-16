using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Бахмат_Lab3.Entites
{
    public class User
    {
        public string Name { get; set; }
        public List<TariffTraficData> TraficData { get; set; }

        public User(string name)
        {
            Name = name;
            TraficData = new List<TariffTraficData>();
        }

        public void AddTrafic(Tariff tariff, double trafficInMB)
        {
            var data = TraficData.FirstOrDefault(d => d.Tariff == tariff);
            if (data != null)
            {
                data.TrafficInMB += trafficInMB;
            }
            else
            {
                TraficData.Add(new TariffTraficData(tariff, trafficInMB));
            }
            /*bool found = false;
            for(int i = 0; i < TraficData.Count(); ++i)
            {
                var data = TraficData[i];
                if (data.Tariff == tariff)
                {
                    data.TrafficInMB += trafficInMB;
                    found = true;
                    break;
                }
            }

            if (!found)
                TraficData.Add(new TariffTraficData(tariff, trafficInMB));*/
        }
    }
}
