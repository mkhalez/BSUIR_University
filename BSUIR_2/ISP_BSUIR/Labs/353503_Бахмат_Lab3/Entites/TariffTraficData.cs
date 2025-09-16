using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Бахмат_Lab3.Entites
{
    public class TariffTraficData
    {
        public Tariff Tariff { get; set; }
        public double TrafficInMB { get; set; }
        public TariffTraficData(Tariff tariff, double trafficInMB)
        {
            Tariff = tariff;
            TrafficInMB = trafficInMB;
        }
    }
}
