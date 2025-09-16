using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Бахмат_Lab1.Entites
{
    public class TariffTrafficData
    {
        public string TariffName { get; set; }
        public double TrafficInMB { get; set; }

        public TariffTrafficData(string tariffName, double trafficInMB)
        {
            TariffName = tariffName;
            TrafficInMB = trafficInMB;
        }
    }
}
