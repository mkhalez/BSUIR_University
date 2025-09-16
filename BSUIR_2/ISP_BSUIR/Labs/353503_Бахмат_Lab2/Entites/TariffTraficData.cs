using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Бахмат_Lab2.Entites
{
    public class TariffTrafficData
    {
        public Tariff Tariff { get; set; }
        public double TrafficInMB { get; set; }

        public TariffTrafficData(Tariff tariff, double trafficInMB)
        {
            Tariff = tariff;
            TrafficInMB = trafficInMB;
        }
    }
}
