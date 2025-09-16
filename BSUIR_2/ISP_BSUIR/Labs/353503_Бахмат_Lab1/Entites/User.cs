using _353503_Бахмат_Lab1.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Бахмат_Lab1.Entites
{
    public class User
    {
        public string Name { get; set; }
        public MyCustomeCollection<TariffTrafficData> TrafficData { get; set; }

        public User(string name)
        {
            Name = name;
            TrafficData = new MyCustomeCollection<TariffTrafficData>();
        }

        public void AddTraffic(string tariffName, double trafficInMB)
        {
            bool found = false;
            TrafficData.Reset();
            for (int i = 0; i < TrafficData.Count; i++)
            {
                var data = TrafficData.GetCurrent();
                if (data.TariffName == tariffName)
                {
                    data.TrafficInMB += trafficInMB;
                    found = true;
                    break;
                }
                TrafficData.Next();
            }

            if (!found)
            {
                TrafficData.Add(new TariffTrafficData(tariffName, trafficInMB));
            }
        }
    }
}
